using System;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Steganography.Classes;

using System.Drawing;
using System.Drawing.Imaging;

namespace Steganography
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            Image jpg = new Bitmap(@"C:\Users\Vadim\Desktop\1.jpg");
            jpg.Save(@"C:\Users\Vadim\Desktop\2.bmp", ImageFormat.Bmp);

            Image bmp = new Bitmap(@"C:\Users\Vadim\Desktop\2.bmp");
            bmp.Save(@"C:\Users\Vadim\Desktop\3.jpg", ImageFormat.Jpeg);
            */

        }

        public string typeOfFile = "";
        public string imagePath = "";
        public string imagePath2 = "";

        public string copyPath = "";

        private void Btn_ImportImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                typeOfFile = TypeOfFile(imagePath).ToLower();

                copyPath = AppDomain.CurrentDomain.BaseDirectory + "\\tmp." + typeOfFile;

                imgsource.Source = new BitmapImage(new Uri(imagePath));

                File.Copy(imagePath, copyPath, true);
                btn_Cipher.IsEnabled = true;
            }
        }

        private void Btn_Cipher_Click(object sender, RoutedEventArgs e)
        {
            Cipher cipher = new Cipher(text_source.Text, copyPath, typeOfFile);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try{ File.Delete(copyPath); }
            catch{}
            Environment.Exit(0);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            try { File.Delete(copyPath); }
            catch { }
            Environment.Exit(0);
        }

        public string TypeOfFile(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }

        private void Btn_DeCipher_Click(object sender, RoutedEventArgs e)
        {
            DeCipher deCipher = new DeCipher();
            text_source2.Text = deCipher.DeCipher_img(imagePath2);
        }
        private void Btn_ImportImage2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp";


            if (openFileDialog.ShowDialog() == true)
            {
                imagePath2 = openFileDialog.FileName;
                typeOfFile = TypeOfFile(imagePath2).ToLower();

                copyPath = AppDomain.CurrentDomain.BaseDirectory + "\\tmp2." + typeOfFile;

                imgsource2.Source = new BitmapImage(new Uri(imagePath2));

                File.Copy(imagePath2, copyPath, true);
                btn_DeCipher.IsEnabled = true;
            }
        }
    }
}
