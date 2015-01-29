using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourWalled.Models;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Xna.Framework.Media;

namespace FourWalled.Utils
{
    public static class CommonStuff
    {
        public static IsolatedStorageSettings appStorage = IsolatedStorageSettings.ApplicationSettings;
        //tags=&board=&width_aspect=1280x150&searchstyle=exact&sfw=0&search=random
        public static readonly string initParams = "tags=&board=&width_aspect=&searchstyle=exact&sfw=0&search=random";
        public static List<ImageModel> randomImageModels = new List<ImageModel>();
        public static ImageModel selectedImage;

        public static void SaveToMediaLibrary(this WriteableBitmap wb, string fileName)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            var tempName = Guid.NewGuid().ToString();
            using (var fileStream = store.CreateFile(tempName))
            {
                Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
            }
            using (var fileStream = store.OpenFile(tempName, FileMode.Open, FileAccess.Read))
            {
                var library = new MediaLibrary();
                var pic = library.SavePicture(fileName, fileStream);
            }
        }
    }
}
