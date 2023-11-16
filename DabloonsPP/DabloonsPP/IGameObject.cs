using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace DabloonsGG1
{
    abstract class IGameObject
    {
        public Point Position;
        public Rectangle Hitbox;
        private BitmapImage image;
        private Canvas GameCanva;



        protected void SetImage(string path)
        {

        }
    }
}
