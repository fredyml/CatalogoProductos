using CatalogoProductos.Aplication.Interfaces;

namespace CatalogoProductos.Aplication.Handlers
{
    public class ImageValidator : IImageValidator
    {
        public bool IsValidImageExtension(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var extension = Path.GetExtension(imageUrl).ToLower();
                var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                return validExtensions.Contains(extension);
            }

            return true;
        }
    }
}
