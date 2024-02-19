using Microsoft.AspNetCore.Http;

namespace Debat.Common.Helpers
{
    public static class Extensions
    {
        public async static Task<string> CreateImage(this IFormFile imageFile, string webRootPath, string target = null)
        {
            string fileName = imageFile.FileName;

            if (fileName.Length > 219)
            {
                fileName = fileName.Substring(fileName.Length - 219, 219);
            }

            fileName = Guid.NewGuid().ToString() + fileName;

            string filePath = "";

            if (target == "UserImage")
            {
                filePath = Path.Combine(webRootPath, "uploads", "images", "user", fileName);
            }
            else if (target == "CommunityImage")
            {
                filePath = Path.Combine(webRootPath, "uploads", "images", "community", fileName);
            }
            else if (string.IsNullOrEmpty(target))
            {
                filePath = Path.Combine(webRootPath, "uploads", "images", "mixed", fileName);
            }
            else
            {
                filePath = Path.Combine(webRootPath, "uploads", "images", "mixed", fileName);
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}