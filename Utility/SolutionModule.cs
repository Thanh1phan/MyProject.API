using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.API.Commom;
using MyProject.API.Models.Dto;
using System.Data.SqlTypes;

namespace MyProject.API.Utility
{
    public static class SolutionModule
    {
        public static string ProcessImage(IFormFile image)
        {
            if (image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string filePath = CConstant.FolderImage + fileName;

                var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);

                DeleteImage(directoryLocation);

                using (var fileStream = new FileStream(directoryLocation, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                var url = CConstant.BaseUrl + fileName;
                return url;

            }
            else
            {
                return "https://placehold.co/600x400";
            }
        }

        public static void DeleteImage(string path)
        {
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
