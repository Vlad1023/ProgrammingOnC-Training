using FuncProgrammingProjectDOTNET.LessonsViewModels;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FuncProgrammingProjectDOTNET.LessonsViews
{
    /// <summary>
    /// Interaction logic for Lesson4.xaml
    /// </summary>
    public partial class Lesson4 : Window
    {
        public Lesson4()
        {
            DataContext = new Lesson4ViewModel();
            InitializeComponent();
        }

        private void Button_OnClick1(object sender, RoutedEventArgs e)
        {
            var writeableBitmap = CreateImage(900, 500);
            UpdateImage1(writeableBitmap);
            Image1.Source = writeableBitmap;
        }

        private void Button_OnClick2(object sender, RoutedEventArgs e)
        {
            var writeableBitmap = CreateImage(900, 500);
            UpdateImage2(writeableBitmap);
            Image2.Source = writeableBitmap;
        }

        private void Button_OnClick3(object sender, RoutedEventArgs e)
        {
            var writeableBitmap = CreateImage(900, 500);
            UpdateImage3(writeableBitmap);
            Image3.Source = writeableBitmap;
        }

        private void Button_OnClick4(object sender, RoutedEventArgs e)
        {
            var writeableBitmap = CreateImage(900, 500);
            UpdateImage4(writeableBitmap);
            Image4.Source = writeableBitmap;
        }

        private WriteableBitmap CreateImage(int width, int height)
        {
            var writeableBitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, BitmapPalettes.Halftone256Transparent);
            return writeableBitmap;
        }

        private void UpdateImage1(WriteableBitmap writeableBitmap)
        {
            int width = (int)writeableBitmap.Width,
                height = (int)writeableBitmap.Height;
            writeableBitmap.Lock();
            var skImageInfo = new SKImageInfo()
            {
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888,
                AlphaType = SKAlphaType.Premul,
                ColorSpace = SKColorSpace.CreateSrgb()
            };

            using (var surface = SKSurface.Create(skImageInfo, writeableBitmap.BackBuffer))
            {
                SKCanvas canvas = surface.Canvas;
                canvas.Clear(new SKColor(130, 130, 130));
                canvas.DrawText("SkiaSharp in Wpf!", 50, 200, new SKPaint() { Color = new SKColor(0, 0, 0), TextSize = 100 });
            }
            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            writeableBitmap.Unlock();
        }

        private void UpdateImage2(WriteableBitmap writeableBitmap)
        {
            int width = (int)writeableBitmap.Width,
                height = (int)writeableBitmap.Height;
            writeableBitmap.Lock();
            var skImageInfo = new SKImageInfo()
            {
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888,
                AlphaType = SKAlphaType.Premul,
                ColorSpace = SKColorSpace.CreateSrgb()
            };

            using (var surface = SKSurface.Create(skImageInfo, writeableBitmap.BackBuffer))
            {
                SKCanvas canvas = surface.Canvas;
                canvas.Clear(new SKColor(130, 130, 130));
                canvas.DrawRect(width / 2 - 600 / 2, height / 2 - 300 / 2, 600, 300, new SKPaint { Color = SKColor.FromHsl(0, 100, 50) });
            }
            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            writeableBitmap.Unlock();
        }

        private void UpdateImage3(WriteableBitmap writeableBitmap)
        {
            int width = (int)writeableBitmap.Width,
                height = (int)writeableBitmap.Height;
            writeableBitmap.Lock();
            var skImageInfo = new SKImageInfo()
            {
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888,
                AlphaType = SKAlphaType.Premul,
                ColorSpace = SKColorSpace.CreateSrgb()
            };

            using (var surface = SKSurface.Create(skImageInfo, writeableBitmap.BackBuffer))
            {
                SKCanvas canvas = surface.Canvas;
                canvas.Clear(new SKColor(130, 130, 130));
                canvas.DrawCircle(new SKPoint(width / 2, height / 2), Math.Min(width, height) / 2, new SKPaint { Color = SKColor.FromHsl(0, 100, 50) });
            }

            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            writeableBitmap.Unlock();
        }

        private void UpdateImage4(WriteableBitmap writeableBitmap)
        {
            int width = (int)writeableBitmap.Width,
                height = (int)writeableBitmap.Height;
            writeableBitmap.Lock();
            var skImageInfo = new SKImageInfo()
            {
                Width = width,
                Height = height,
                ColorType = SKColorType.Bgra8888,
                AlphaType = SKAlphaType.Premul,
                ColorSpace = SKColorSpace.CreateSrgb()
            };

            using (var surface = SKSurface.Create(skImageInfo, writeableBitmap.BackBuffer))
            {
                SKCanvas canvas = surface.Canvas;
                canvas.Clear(new SKColor(130, 130, 130));
                canvas.DrawOval(new SKRect(width / 2 - 600 / 2, height / 2 - 300 / 2, 600, 300), new SKPaint { Color = SKColor.FromHsl(0, 100, 50) });
            }

            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            writeableBitmap.Unlock();
        }
    }
}
