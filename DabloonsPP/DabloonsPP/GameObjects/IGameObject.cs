using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace DabloonsPP
{
    abstract class IGameObject
    {
        public Point position;
        public Ellipse hitbox;
        private Image image;
        private Canvas gameCanva;

        #region Getter and Setters
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public Ellipse Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
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
            hitbox = new Ellipse();
            hitbox.Width = width;
            hitbox.Height = height;
            image = new Image();
            gameCanva = canva;
            SetImage(path, height, width);
        }

        protected void Draw()
        {
            Canvas.SetLeft(image, position.X);
            Canvas.SetTop(image, position.Y);

            gameCanva.Children.Add(image);
        }

        protected void SetImage(string path, int height, int width)
        {
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + path));
            image.Height = height;
            image.Width = width;
        }
    }
}
