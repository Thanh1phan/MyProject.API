using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyProject.API.Commom;
using MyProject.API.Data.Entities;
using MyProject.API.Models.Dto;
using MyProject.API.Repository;
using MyProject.API.Repository.IRepository;
using MyProject.API.Services.IService;
using MyProject.API.UOW;
using MyProject.API.UOW.IUOW;
using MyProject.API.Utility;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace MyProject.API.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _includeTables = "B03T,K11T,K02T";
        
        public ProductService(IMapper mapper, IProductUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ServiceResponseDto<ProductCreateDto>> CreateProduct(ProductCreateDto model)
        {
            var response = new ServiceResponseDto<ProductCreateDto>();
            var m01cId = Guid.NewGuid();
            M01C m01C = new M01C()
            {
                Id = m01cId,
                Name = model.Name,
                B3Id = model.B3Id,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            var urls = new List<string>();
            foreach (var image in model.ListUrlImage)
            {
                var url = SolutionModule.ProcessImage(image);
                urls.Add(url);
            }
            var count = 0;
            var k02ts = urls.Select(x => new K02T
            {
                M01CId = m01cId,
                Seq = count++,
                Url = x,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            });


            var k11t = new K11T()
            {
                M01CId = m01cId,
                ZOBAIKA = model.ZOBAIKA,
                ZIBAIKA = model.ZOBAIKA,
                UpdateDate = DateTime.Now,
                CreateDate = DateTime.Now
            };

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.M01C.CreateAsync(m01C);
                await _unitOfWork.K11T.CreateAsync(k11t);
                await _unitOfWork.K02T.CreateRangeAsync(k02ts);
                
                await _unitOfWork.CommitAsync();
                response.Result = model;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();

                response.Iscucess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponseDto<ProductDto>> DeleteProduct(Guid id)
        {
            var response = new ServiceResponseDto<ProductDto>();
            var product = await _unitOfWork.M01C.GetAsync(x => x.Id == id);
            if (product != null)
            {
                await _unitOfWork.BeginTransactionAsync();

                try
                { 
                    var k11t = await _unitOfWork.K11T.GetAsync(x => x.M01CId == id);
                    response.Result = _mapper.Map<ProductDto>(product);
                    await _unitOfWork.M01C.RemoveAsync(product);
                    await _unitOfWork.K11T.RemoveAsync(k11t);
                    await _unitOfWork.K02T.RemoveRangeAsync(x => x.M01CId == id);
                    await _unitOfWork.CommitAsync();
                }
                catch(Exception ex) 
                {
                    await _unitOfWork.RollbackAsync();
                    response.Iscucess = false;
                    response.Message = ex.Message;
                }
                return response;
            }
            response.Iscucess = false;
            response.Message = CConstant.NotFound;
            return response;
        }

        public async Task<ServiceResponseDto<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var response = new ServiceResponseDto<IEnumerable<CategoryDto>>();
            var result = await _unitOfWork.B03T.GetListAsync();
            if (result == null)
            {
                response.Iscucess = false;
                response.Message = CConstant.NotFound;
                return response;
            }

            var listData = result.Select(x => new CategoryDto { Id = x.Id, Name = x.Name});
            response.Result = listData;
            return response;
        }

        /// <summary>
        /// GetDetailProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponseDto<DetailProductDto>> GetProductToUpdate(Guid id)
        {
            var response = new ServiceResponseDto<DetailProductDto>();
            var result = await _unitOfWork.M01C.GetAsync(x => x.Id == id, false, _includeTables);

            if (result == null)
            {
                response.Iscucess = false;
                response.Message = CConstant.NotFound;
                return response;
            }

            var categoryList = await _unitOfWork.B03T.GetListAsync();

            var data = new DetailProductDto()
            {
                Id = result.Id,
                Name = result.Name,
                Categories = categoryList.Select(x => new CategoryDto { Id = x.Id, Name = x.Name}).ToList(),
                B3Id = result.B3Id,
                ZIBAIKA = result.K11T.ZIBAIKA,
                ZOBAIKA = result.K11T.ZOBAIKA,
                ListUrlImage = result.K02T.OrderBy(x => x.Seq).Select(x => x.Url).ToList()
            };

            response.Result = data;
            return response;
        }

        /// <summary>
        /// GetInfoProduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponseDto<InfoProductDto>> GetInfoProduct(Guid id)
        {
            var response = new ServiceResponseDto<InfoProductDto>();

            var result = await _unitOfWork.M01C.GetAsync(x => x.Id == id, false, _includeTables);
            if(result == null)
            {
                response.Iscucess = false;
                response.Message = CConstant.NotFound;
                return response;
            }

            var data = new InfoProductDto()
            {
                M01CId = result.Id,
                Name = result.Name,
                B3Name = result.B03T.Name,
                ZIBAIKA = result.K11T.ZIBAIKA,
                ZOBAIKA = result.K11T.ZOBAIKA,
                ListUrlImage = result.K02T.OrderBy(x=>x.Seq).Select(x => x.Url)
            };

            response.Result = data;
            return response;
        }

        /// <summary>
        /// GetInfoProducts
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<ServiceResponseDto<IEnumerable<InfoProductDto>>> GetInfoProducts(int pageSize = 0, int pageNumber = 1, string keyword = null)
        {
            var response = new ServiceResponseDto<IEnumerable<InfoProductDto>>();

            //var result = await _ProductRepository.GetInfoProduct(pageSize, pageNumber, keyword);
            IEnumerable<M01C> result;
            if (string.IsNullOrEmpty(keyword))
            {
                result = await _unitOfWork.M01C.GetListAsync(orderBy: x => x.OrderBy(o => o.Name), includeProperties: _includeTables, pageSize: pageSize, pageNumber: pageNumber);
            }
            else
            {
                result = await _unitOfWork.M01C.GetListAsync(x => x.Name.Contains(keyword), orderBy: x => x.OrderBy(o => o.Name), includeProperties: _includeTables, pageSize: pageSize, pageNumber: pageNumber);
            }

            var data = result.Select(x => new InfoProductDto()
            {
                M01CId = x.Id,
                Name = x.Name,
                B3Name = x.B03T.Name,
                ZIBAIKA = x.K11T.ZIBAIKA,
                ZOBAIKA = x.K11T.ZOBAIKA,
                ListUrlImage = x.K02T.OrderBy(x=>x.Seq).Select(x => x.Url),
            });
            response.Result = data;
            return response;
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ServiceResponseDto<ProductUpdateDto>> UpdateProduct(ProductUpdateDto model)
        {
            var response = new ServiceResponseDto<ProductUpdateDto>();
            var urls = new List<string>();

            M01C m01C = new M01C()
            {
                Id = model.Id,
                Name = model.Name,
                B3Id = model.B3Id,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            var k11t = new K11T()
            {
                M01CId = model.Id,
                ZOBAIKA = model.ZOBAIKA,
                ZIBAIKA = model.ZOBAIKA,
                UpdateDate = DateTime.Now,
                CreateDate = DateTime.Now
            };

            //Begin Transaction
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.M01C.UpdateAsync(m01C);
                _unitOfWork.K11T.Update(k11t);

                //Handle add/replace/delete image
                for(var i = 0; i < model.ListUrlImage.Count; i++)
                {
                    if (model.RemoveImageIndexes[i])
                    {
                        var itemRemove = await _unitOfWork.K02T.GetAsync(x => x.Url == model.ListUrlImage[i]);
                        for (var j = 0; j < model.ReplaceImageIndexes?.Count; j++)
                        {
                            if (model.ReplaceImageIndexes[j] == i)
                            {
                                model.ReplaceImageIndexes.RemoveAt(j);
                            }   
                        }
                        await _unitOfWork.K02T.RemoveAsync(itemRemove);
                    }  
                }

                var listReplaceK02T = new List<K02T>();
                for (var i = 0; i < model.ReplaceImageIndexes?.Count; i++)
                {
                    var seq = model.ReplaceImageIndexes[i];
                    var itemReplace = await _unitOfWork.K02T.GetAsync(x => x.Url == model.ListUrlImage[i]);

                    if (itemReplace != null)
                    {
                        var fileName = itemReplace.Url.Replace(CConstant.BaseUrl, string.Empty);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), CConstant.FolderImage, fileName);
                        SolutionModule.DeleteImage(filePath);

                        var url = SolutionModule.ProcessImage(model.ReplaceImages[i]);
                        itemReplace.Url = url;
                        listReplaceK02T.Add(itemReplace);
                    }
                }

                if (listReplaceK02T.Count > 0)
                {
                    await _unitOfWork.K02T.UpdateRangeAsync(listReplaceK02T);
                }


                if (model.NewImages != null)
                {
                    foreach (var image in model.NewImages)
                    {
                        var url = SolutionModule.ProcessImage(image);
                        urls.Add(url);
                    }
                }

                var list = await _unitOfWork.K02T.GetListAsync(x => x.M01CId == model.Id);
                var count = list.Select(x => x.Seq).Max() + 1;
                var k02ts = urls.Select(x => new K02T
                {
                    M01CId = model.Id,
                    Seq = count++,
                    Url = x,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                });

                await _unitOfWork.K02T.CreateRangeAsync(k02ts);

                // Commit transaction
                await _unitOfWork.CommitAsync();
                response.Result = model;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                response.Iscucess = false;
                response.Message = ex.Message;
                foreach (var url in urls)
                {
                    SolutionModule.DeleteImage(url);
                }
            }
            return response;
        }
    }
}
