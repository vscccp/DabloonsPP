using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace DabloonsPP
{
    abstract class IGameObject
    {
        public Point position;
        public Rectangle hitbox;
        private Image image;
        private Canvas gameCanva;

        #region Getter and Setters
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }

        public Image Image
        {
            get { return image; }
        }

        public Canvas GameCanvas
        {
            get { return gameCanva; }
        }

        #endregion

        // Constructor that initializes fields using parameters
        public IGameObject(int width, int height, int x, int y, string path, Canvas canva)
        {
            position = new Point(x, y);
            hitbox = new Rectangle(x, y, width, height);
            image = new Image();
            gameCanva = canva;
            SetImage(path, height, width);
        }

        public void SetImage(string path, int height, int width)
        {
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + path));
            image.Height = height;
            image.Width = width;
        }
    }
}
