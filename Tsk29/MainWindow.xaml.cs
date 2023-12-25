using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tsk29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _lastPosition;
        private double _angle;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double scaleFactor = e.NewValue;
            scaleTransform.ScaleX = scaleFactor;
            scaleTransform.ScaleY = scaleFactor;
        }

        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double scaleFactor = e.Delta > 0 ? 1.1 : 0.9;
            if (scaleTransform.ScaleX * scaleFactor >= 0.1 && scaleTransform.ScaleX * scaleFactor <= 2)
            {
                scaleTransform.ScaleX *= scaleFactor;
                scaleTransform.ScaleY *= scaleFactor;
            }
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _lastPosition = e.GetPosition(image);
            image.CaptureMouse();
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (image.IsMouseCaptured)
            {
                Point currentPosition = e.GetPosition(image);
                double deltaX = currentPosition.X - _lastPosition.X;
                double deltaY = currentPosition.Y - _lastPosition.Y;

                double newAngle = _angle + deltaX;

                rotateTransform.Angle = newAngle;

                _angle = newAngle;
                _lastPosition = currentPosition;
            }
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            image.ReleaseMouseCapture();
        }

        //private void img_MouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    Point centerPoint = e.GetPosition(root);
        //    this.sfr.CenterX = centerPoint.X;
        //    this.sfr.CenterY = centerPoint.Y;
        //    if (sfr.ScaleX < 0.3 && sfr.ScaleY < 0.3 && e.Delta < 0)
        //    {
        //        return;
        //    }
        //    sfr.ScaleX += (double)e.Delta / 3500;
        //    sfr.ScaleY += (double)e.Delta / 3500;
        //}
    }
}