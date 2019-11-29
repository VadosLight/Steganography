using System;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Steganography.Classes;


namespace Steganography
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string typeOfFile = "";
        public string imagePath = "";
        public string copyPath = "";

        private void Btn_ImportImage_Click(object sender, RoutedEventArgs e)
        {
            LoadImage();
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

        private void LoadImage()
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
              
            }
        }

        public string TypeOfFile(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }

        
    }
}
