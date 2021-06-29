using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Paint_WPF
{
    /// <summary>
    /// Класс отвечающий за сохранение и открытие файла.
    /// </summary>
    public static class SaveAndOpen
    {
        /// <summary>
        /// Сохранение файла.
        /// </summary>
        /// <param name="InkCwidth">Текущая ширина холста.</param>
        /// <param name="InkCheight">Текущая высота холста.</param>
        public static void SaveAs(double InkCwidth, double InkCheight)
        {
            var saveFileDialog = new SaveFileDialog() { DefaultExt = "png" };
            saveFileDialog.Filter = "PNG files|*.png";
            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {

                    using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        RenderTargetBitmap bmp = new RenderTargetBitmap((int)InkCwidth, (int)InkCheight, 1 / 96, 1 / 96, PixelFormats.Default);
                        bmp.Render(Transfer.inkCanvas);
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bmp));
                        encoder.Save(fs);
                    }
                }
            }
            catch { MessageBox.Show("Ошибка, не удалось сохранить файл."); }

        }

        /// <summary>
        /// Открытие файла.
        /// </summary>
        public static void Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "NewFile";
            open.RestoreDirectory = true;
            open.DefaultExt = ".png";
            open.Filter = "Jpeg Files|*.jpg|Bmp Files|*.bmp|PNG Files|*.png|Tiff Files|*.tif|Gif Files|*.gif";
            if (open.ShowDialog() == true)
            {
                string t = open.FileName;
                Image img = new Image();
                ImageSource imgSrc = new BitmapImage(new Uri(t));
                img.Source = imgSrc;
                img.Height = Transfer.inkCanvas.Height;
                img.Width = Transfer.inkCanvas.Width;
                Transfer.inkCanvas.Strokes.Clear();
                Transfer.inkCanvas.Children.Clear();
                Transfer.inkCanvas.Children.Add(img);
            }
        }
    }
}
