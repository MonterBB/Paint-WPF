using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_WPF
{
    /// <summary>
    /// Класс реализующий рисование прямоугольника и эллипса.
    /// </summary>
    public static class CubeAndEllipse
    {
        /// <summary>
        /// Рисование прямоугольника.
        /// </summary>
        /// <param name="X">Координата мыши по оси X.</param>
        /// <param name="Y">Координата мыши по оси Y.</param>
        /// <param name="DrawC">Цвет кисти.</param>
        public static void DrawRectangle(double X, double Y, Brush DrawC)                                            
        {
            Rectangle myRectangle = new Rectangle()
            {
                Stroke = DrawC,
                Margin = new Thickness(X, Y, 0, 0),
                StrokeThickness = Transfer.Size,
                Height = 1,
                Width = 1
            };
            Transfer.inkCanvas.Children.Add(myRectangle);
        }

        /// <summary>
        /// Рисование эллипса.
        /// </summary>
        /// <param name="X">Координата мыши по оси X.</param>
        /// <param name="Y">Координата мыши по оси Y.</param>
        /// <param name="DrawC">Цвет кисти.</param>
        public static void DrawEllipse(double X, double Y, Brush DrawC)                                               
        {
            Ellipse myEllipse = new Ellipse()
            {
                Stroke = DrawC,
                Margin = new Thickness(X, Y, 0, 0),
                StrokeThickness = Transfer.Size,
                Height = 1,
                Width = 1
            };
            Transfer.inkCanvas.Children.Add(myEllipse);
        }

        /// <summary>
        /// Отображение прямоугольника или эллипса в реальном времени.
        /// </summary>
        /// <param name="MovePoint">Точки перемещения мыши.</param>
        /// <param name="FirstPoint">Первая и последняя точка.</param>
        public static  void RenderingShape(Point MovePoint, Point FirstPoint)
        {
            Shape newShape = (Shape)Transfer.inkCanvas.Children[Transfer.inkCanvas.Children.Count - 1];       
            double tempX, tempY;
            if (((MovePoint.X) - FirstPoint.X) > 0)
            {
                newShape.Width = (MovePoint.X) - FirstPoint.X;
                tempX = FirstPoint.X;
            }
            else
            {
                newShape.Width = FirstPoint.X - MovePoint.X;
                tempX = MovePoint.X;
            }
            if (((MovePoint.Y) - FirstPoint.Y) > 0)
            {
                newShape.Height = (MovePoint.Y) - FirstPoint.Y;
                tempY = FirstPoint.Y;
            }
            else
            {
                newShape.Height = FirstPoint.Y - MovePoint.Y;
                tempY = MovePoint.Y;
            }
            newShape.Margin = new Thickness(tempX, tempY, 0, 0);
        }
    }
}
