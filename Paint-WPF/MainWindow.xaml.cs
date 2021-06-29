using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double zoom = 1;
        private const double zoomMax = 5;
        private const double zoomMin = 1;
        private const double zoomSpeed = 0.001;
        public Point MousePoint;                                           
        public string Shapes = "";
        double Size;

        public ColorRGB mcolor;

        public Color clr;

        private Brush DrawC;

        public bool isPressed = false;

        double DefaultWidth, DefaultHeight;


        public MainWindow()
        {
            InitializeComponent();
            mcolor = new ColorRGB();
            mcolor.red = 0;
            mcolor.green = 0;
            mcolor.blue = 0;
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
            lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            this.WindowState = WindowState.Maximized;
            MyInkCanvas.EditingMode = InkCanvasEditingMode.None;
            DrawC = Brushes.Black;
            Transfer.inkCanvas = MyInkCanvas;
            DefaultWidth = Transfer.inkCanvas.Width;
            DefaultHeight = Transfer.inkCanvas.Height;

        }

        private void Board_Clear_Click(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.Strokes.Clear();
            MyInkCanvas.Children.Clear();
            Transfer.tPolyline = false;
            Transfer.tPolygon = false;
            MyInkCanvas.Background = new SolidColorBrush(Colors.White);
            Transfer.inkCanvas.Width = DefaultWidth;
            Transfer.inkCanvas.Height = DefaultHeight;

        }
        private void WandHBoard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tempWidth = Convert.ToInt16(TextBox_Width.Text);
                int tempHeight = Convert.ToInt16(TextBox_Height.Text);
                MyInkCanvas.Height = tempHeight;
                MyInkCanvas.Width = tempWidth;
            }
            catch
            {
                MessageBox.Show("Высота и ширина могут быть только целыми числами");
            }
        }

        private void Board_Fill_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(clr);
            MyInkCanvas.Background = solidColorBrush;
        }

        private void Pencil_Click(object sender, RoutedEventArgs e)
        {
            Transfer.mode = "Карандаш";
            Shapes = "";
            MyInkCanvas.DefaultDrawingAttributes.Color = clr;
            Pencil.Pencil_Drawing();
        }

        private void Eraser_Click(object sender, RoutedEventArgs e)
        {
            Transfer.mode = "Стёрка";
            Shapes = "";
            Eraser.Erases_Canvas();
        }

        private void Brush_Click(object sender, RoutedEventArgs e)
        {
            Transfer.mode = "Перо";
            Shapes = "";
            MyInkCanvas.DefaultDrawingAttributes.Color = clr;
            BrushPen.BrushPen_Drawing();
        }
        private void Select_btn_Click(object sender, RoutedEventArgs e)
        {
            Shapes = "";
            MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAndOpen.SaveAs(MyInkCanvas.ActualWidth, MyInkCanvas.ActualHeight);
        }

        private void OpenAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAndOpen.Open();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyInkCanvas.Children.RemoveAt(MyInkCanvas.Children.Count - 1);
            }
            catch { };
            try
            {
                MyInkCanvas.Strokes.RemoveAt(MyInkCanvas.Strokes.Count - 1);
            }
            catch { };
        }
        private void Line_bnt_Click(object sender, RoutedEventArgs e)
        {
            Shapes = "Линия";
            Transfer.tPolygon = false;
            Transfer.tPolyline = false;
        }

        private void Cube_bnt_Click(object sender, RoutedEventArgs e)
        {
            Shapes = "Прямоугольник";
            Transfer.tPolygon = false;
            Transfer.tPolyline = false;
        }

        private void Ellipse_bnt_Click(object sender, RoutedEventArgs e)
        { 
            Shapes = "Овал";
            Transfer.tPolygon = false;
            Transfer.tPolyline = false;
        }

        private void Polygon_bnt_Click(object sender, RoutedEventArgs e)
        {
            Shapes = "Полигон";
            Transfer.tPolyline = false;
        }

        private void Polyline_bnt_Click(object sender, RoutedEventArgs e)
        {
            Shapes = "Полилиния";
            Transfer.tPolygon = false;
        }

        /// <summary>
        /// Настройка прозрачности холста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Transparency_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double tempValue = Convert.ToDouble(CopacityValue.Text);
                MyInkCanvas.Opacity = tempValue;
            }
            catch
            {
                MessageBox.Show("Не правильно введено значение, убедитесь, что стоит от 0,1 до 1\nПроверьте стоит ли запятая, а не точка");
            }
        }

        private void MyInkCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            zoom += zoomSpeed * e.Delta;

            if (zoom < zoomMin)
                zoom = zoomMin;
            if (zoom > zoomMax)
                zoom = zoomMax;

            var mousePos = e.GetPosition(Transfer.inkCanvas);

            if (zoom > 1)
                Transfer.inkCanvas.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y);
            else
                Transfer.inkCanvas.RenderTransform = new ScaleTransform(zoom, zoom);
        }

        private void MyInkCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MousePoint = new Point(e.GetPosition(MyInkCanvas).X, e.GetPosition(MyInkCanvas).Y);
            Figure.FormSelection(Shapes, MousePoint, DrawC);
            isPressed = true;
        }

        private void MyInkCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (Shapes == "")
            {
                return;
            }
            if (isPressed == false)
            {
                return;
            }
            Point MovePoint = new Point()
            {
                X = e.GetPosition(MyInkCanvas).X,
                Y = e.GetPosition(MyInkCanvas).Y
            };
            switch (Shapes)
            {
                case "Линия":
                    Transfer.mode = "";
                    Lines.RenderingLine(MovePoint);
                    break;
                case "Прямоугольник":
                    CubeAndEllipse.RenderingShape(MovePoint, MousePoint);
                    break;
                case "Овал":
                    CubeAndEllipse.RenderingShape(MovePoint, MousePoint);
                    break;
                case "Полигон":
                    PolygonD.RenderingPolygon(MovePoint);
                    break;
                case "Полилиния":
                    PolyLineD.RenderingPolyLine(MovePoint);
                    break;
                default:
                    break;
            }
        }

        private void MyInkCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MousePoint = new Point(e.GetPosition(MyInkCanvas).X, e.GetPosition(MyInkCanvas).Y);
            isPressed = false;
        }

        private void TextBox_Thickness_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Size = Convert.ToDouble(TextBox_Thickness.Text);
                Transfer.Size = Size;
                if (Size > 30)
                {
                    Size = 30;
                }
                if (Size < 0)
                {
                    Size = 0.1;
                }
            }
            catch { }
        }

        /// <summary>
        /// Настройка цвета исходя из RGB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sld_Color_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            string crlName = slider.Name;
            double value = slider.Value; 

            if (crlName =="sld_RedColor")
            {
                mcolor.red = Convert.ToByte(value);
            }
            if (crlName =="sld_GreenColor")
            {
                mcolor.green = Convert.ToByte(value);
            }
            if (crlName == "sld_BlueColor")
            {
                mcolor.blue = Convert.ToByte(value);
            }
 
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
            lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            MyInkCanvas.DefaultDrawingAttributes.Color = clr;
            DrawC = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
        }
    }
}
