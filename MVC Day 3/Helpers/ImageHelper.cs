namespace MVC_Day_3.Helpers
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageHelper(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public string SaveImage(IFormFile imageFile)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            string newFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath, "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return "/images/" + newFileName;
        }

        public void DeleteImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fullPath = Path.Combine(wwwRootPath, imagePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }

        public string UpdateImage(IFormFile newImageFile, string existingImagePath)
        {
            if (!string.IsNullOrEmpty(existingImagePath))
            {
                DeleteImage(existingImagePath);
            }
            return SaveImage(newImageFile);
        }
    }

}



