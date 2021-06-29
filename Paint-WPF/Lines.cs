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
    public static class Lines
    {
        
        /// <summary>
        /// Рисование линии.
        /// </summary>
        /// <param name="p1">Точка нажатия ЛКМ.</param>
        /// <param name="p2">Точка подъёма ЛКМ.</param>
        /// <param name="DrawC">Цвет кисти.</param>
        public static void DrawLine(Point p1, Point p2, Brush DrawC)                                                 
        {
            Line myLine = new Line
            {
                Stroke = DrawC,
                X1 = p1.X,
                X2 = p2.X,
                Y1 = p1.Y,
                Y2 = p2.Y,
                StrokeThickness = Transfer.Size
            };
            Transfer.inkCanvas.Children.Add(myLine);
        }
        
        /// <summary>
        /// Отображает рисуемую линию в реальном времени.
        /// </summary>
        /// <param name="MovePoint">Точки перемещения мыши.</param>
        public static void RenderingLine(Point MovePoint)                                            
        {
            Line newLine = (Line)Transfer.inkCanvas.Children[Transfer.inkCanvas.Children.Count - 1];
            newLine.X2 = MovePoint.X;
            newLine.Y2 = MovePoint.Y;
        }
    }
}
