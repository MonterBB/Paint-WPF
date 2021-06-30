using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_WPF
{
    /// <summary>
    /// Класс отвечающий за выбор фигуры.
    /// </summary>
    public static class Figure
    {
        /// <summary>
        /// Выбирает нужную фигуру.
        /// </summary>
        /// <param name="Shapes">Текущая фигура</param>
        /// <param name="FirstPoint">Точки первого и последнего касания.</param>
        /// <param name="DrawC">Цвет кисти.</param>
        public static void FormSelection(string Shapes, Point FirstPoint, Brush DrawC)                                                    
        {
            switch (Shapes)
            {
                case "Линия":
                    Transfer.inkCanvas.EditingMode = InkCanvasEditingMode.None;
                    Lines.DrawLine(FirstPoint, FirstPoint, DrawC);
                    break;
                case "Прямоугольник":
                    Transfer.inkCanvas.EditingMode = InkCanvasEditingMode.None;
                    CubeAndEllipse.DrawRectangle(FirstPoint.X, FirstPoint.Y, DrawC);
                    break;
                case "Овал":
                    Transfer.inkCanvas.EditingMode = InkCanvasEditingMode.None;
                    CubeAndEllipse.DrawEllipse(FirstPoint.X, FirstPoint.Y, DrawC);
                    break;
                case "Полигон":
                    Transfer.inkCanvas.EditingMode = InkCanvasEditingMode.None;
                    if (Transfer.tPolygon)
                    {
                        PolygonD.FinishPolygon(FirstPoint);
                    }
                    else PolygonD.DrawPolygon(FirstPoint, DrawC);
                    break;
                case "Полилиния":
                    Transfer.inkCanvas.EditingMode = InkCanvasEditingMode.None;
                    if (Transfer.tPolyline)
                    {
                        PolyLineD.FinishPolyLine(FirstPoint);
                    }
                    else PolyLineD.DrawPolyLine(FirstPoint, DrawC);
                    break;
            }
        }
        public static void RenderingShapes(string Shapes, Point MovePoint, Point MousePoint)
        {
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
    }
}
