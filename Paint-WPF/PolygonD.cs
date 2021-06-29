using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_WPF
{
    /// <summary>
    /// Класс отвечающий за рисование многоугольника.
    /// </summary>
    public static class PolygonD
    {

        /// <summary>
        /// Создаёт объект - многоугольник.
        /// </summary>
        /// <param name="FirstPoint">Точки с координатами первого касания мыши.</param>
        /// <param name="DrawC">Цвет кисти.</param>
        public static void DrawPolygon(Point FirstPoint, Brush DrawC)                                          
        {
            Transfer.tPolygon = true;
            Transfer.PointC = new PointCollection
            {
                FirstPoint
            };
            Polygon myPolygon = new Polygon
            {
                Stroke = DrawC,
                StrokeThickness = Transfer.Size
            };
            myPolygon.Points = Transfer.PointC;
            Transfer.inkCanvas.Children.Add(myPolygon);
        }

        /// <summary>
        /// Добавляет новые вершины в многоугольник.
        /// </summary>
        /// <param name="FirstPoint">Точки с координатами подъёма ЛКМ.</param>
        public static void FinishPolygon(Point FirstPoint)                                                
        {
            Polygon Poly = (Polygon)Transfer.inkCanvas.Children[Transfer.inkCanvas.Children.Count - 1];
            Poly.Points.Add(FirstPoint);
        }

        /// <summary>
        /// Отображает рисуемую фигуру на холсте в реальном времени.
        /// </summary>
        /// <param name="MovePoints"></param>
        public static void RenderingPolygon(Point MovePoints)
        {
            var RenPolygon = (Polygon)Transfer.inkCanvas.Children[Transfer.inkCanvas.Children.Count - 1];
            if (RenPolygon.Points.Count == 1)
            {
                RenPolygon.Points.Add(MovePoints);  
            }
            else
            {
                RenPolygon.Points[RenPolygon.Points.Count - 1] = MovePoints;  
            }
        }
    }
}
