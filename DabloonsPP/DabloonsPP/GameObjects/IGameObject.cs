using DabloonsPP.HelperClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace DabloonsPP
{
    abstract class IGameObject
    {
        public MyCircle hitbox;
        protected Image image;
        private Canvas gameCanva;
        private PlaneProjection planeProjection;

        #region Getter and Setters
        public Point Position
        {
            get { return hitbox.getPosition(); }
            set { hitbox.setPosition(value); }
        }

        public MyCircle Hitbox
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
            planeProjection = new PlaneProjection();

            Point position = new Point(x, y);
            Ellipse eli = new Ellipse();
            eli.Width = width;
            eli.Height = width;
            hitbox = new MyCircle(position, eli);

            image = new Image();
            gameCanva = canva;

            Canvas.SetLeft(image, hitbox.getPosition().X);
            Canvas.SetTop(image, hitbox.getPosition().Y);
            gameCanva.Children.Add(image);

            SetImage(path, height, width);
        }

        public IGameObject(int width, int height, int x, int y, Canvas canva)
        {
            planeProjection = new PlaneProjection();

            Point position = new Point(x, y);
            Ellipse eli = new Ellipse();
            eli.Width = width;
            eli.Height = width;
            hitbox = new MyCircle(position, eli);

            image = new Image();
            gameCanva = canva;

            Canvas.SetLeft(image, hitbox.getPosition().X);
            Canvas.SetTop(image, hitbox.getPosition().Y);
            gameCanva.Children.Add(image);
        }

        protected void Draw()
        {
            Canvas.SetLeft(image, hitbox.getPosition().X);
            Canvas.SetTop(image, hitbox.getPosition().Y);
        }

        protected void Undraw()
        {
            gameCanva.Children.Remove(image);
            gameCanva.Children.Remove(hitbox.getCircle());
        }

        protected void SetImage(string path, int height, int width)
        {
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + path));
            image.Height = height;
            image.Width = width;
        }

        protected void RotateImage(float angle)
        {
            // Create PlaneProjection
            planeProjection.RotationZ = angle; // Set your desired rotation angle here

            // Set Image.Projection
            image.Projection = planeProjection;
        }
    }
}
