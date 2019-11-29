using System;
using System.Collections;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;

namespace Steganography.Classes
{
    class Cipher
    {
        private string text, imgPath, typeOfImage;

        public Cipher(string text, string imgPath, string typeOfImage)
        {
            this.text = text;
            this.imgPath = imgPath;
            this.typeOfImage = typeOfImage;
            Switch();
        }
        private void Switch()
        {
            switch (typeOfImage)
            {
                case ("jpg"):
                    Cipher_JPG();
                    break;
                case ("jpeg"):
                    Cipher_JPG();
                    break;
                case ("png"):
                    Cipher_PNG();
                    break;
                case ("bmp"):
                    Cipher_BMP();
                    break;
            }
        }
        private void Cipher_JPG()
        {
            string img_HEX = BitConverter.ToString(File.ReadAllBytes(imgPath));
            var index = img_HEX.IndexOf("FF-DA");   //HEX format is XX-XX-XX-XX-XX-XX...

            
            MessageBox.Show(index.ToString());      //delete this
            MessageBox.Show(img_HEX.Substring(index + 42 ,5)); //too 1584 - начало отсчета для картинки => 1584 - 1542= 42
        }
        private void Cipher_PNG()
        {

        }
        private void Cipher_BMP()
        {


        }



    }
}
