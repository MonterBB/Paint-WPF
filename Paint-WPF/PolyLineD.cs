using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_WPF
{
    /// <summary>
    /// Класс отвечающий за рисование многолинейника.
    /// </summary>
    public static class PolyLineD
    {
        /// <summary>
        /// Создаёт объект - многолинейник.
        /// </summary>
        /// <param name="FirstPoint">Точка первого нажатия ЛКМ.</param>
        /// <param name="DrawC">Цвет кисти.</param>
        public static void DrawPolyLine(Point FirstPoint, Brush DrawC)                                             
        {
            Transfer.tPolyline = true;
            Transfer.PointC = new PointCollection
            {
                FirstPoint
            };
            Polyline myPolyline = new Polyline
            {
                Stroke = DrawC,
                StrokeThickness = Transfer.Size
            };
            myPolyline.Points = Transfer.PointC;
            Transfer.inkCanvas.Children.Add(myPolyline);
        }

        /// <summary>
        /// Добавляет новые вершины в многолинейник.
        /// </summary>
        /// <param name="FirstPoint">Точка нажатия ЛКМ.</param>
        public static void FinishPolyLine(Point FirstPoint)                                              
        {
            Polyline Poly = (Polyline)Transfer.inkCanvas.Children[Transfer.inkCanvas.Children.Count - 1];
            Poly.Points.Add(FirstPoint);
        }

        /// <summary>
        /// Отображает многолинейник на холсте в реальном времени.
        /// </summary>
        /// <param name="MovePoint">Точки перемещения мыши</param>
        public static void RenderingPolyLine(Point MovePoint)
        {
            var last = (Polyline)Transfer.inkCanvas.Children[Transfer.inkCanvas.Children.Count - 1];
            if (last.Points.Count == 1)
            {
                last.Points.Add(MovePoint);  
            }
            else
            {
                last.Points[last.Points.Count - 1] = MovePoint;  
            }
        }
    }
}
