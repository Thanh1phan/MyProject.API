using MyProject.API.Repository;
using MyProject.API.Repository.IRepository;
using MyProject.API.Services;
using MyProject.API.Services.IService;
using MyProject.API.UnitOfWork;
using MyProject.API.UnitOfWork.IUOW;
using MyProject.API.UOW;
using MyProject.API.UOW.IUOW;

namespace MyProject.API.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddScoped<IM01CRepository, M01CRepository>();
            services.AddScoped<IK01TRepository, K01TRepository>();
            services.AddScoped<IK02TRepository, K02TRepository>();
            services.AddScoped<IK11TRepository, K11TRepository>();
            services.AddScoped<IM02TRepository, M02TReporsitory>();
            services.AddScoped<IB03TRepository, B03TRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ID03TRepository, D03TRepository>();
            services.AddScoped<ID03THRepository, D03THRepository>();
            services.AddScoped<IK03TRepository, K03TRepository>();

            services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
            services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddAutoMapper(typeof(MappingConfig));
            
            return services;
        }
    }
}
