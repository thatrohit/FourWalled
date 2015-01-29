using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FourWalled.Models
{
    public class ImageModel
    {
        private BitmapImage thumbnailWall;

        public BitmapImage ThumbnailWall
        {
            get { return thumbnailWall; }
            set { thumbnailWall = value; }
        }

        private Uri link;

        public Uri Link
        {
            get { return link; }
            set { link = value; }
        }

        public ImageModel(BitmapImage _thumbnail, Uri _link)
        {
            this.ThumbnailWall = _thumbnail;
            this.link = _link;
        }
    }
}
