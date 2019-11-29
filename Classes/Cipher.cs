using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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
                case ("jpg"): Cipher_JPG();
                    break;
                case ("jpeg"):Cipher_JPEG();
                    break;
                case ("png"): Cipher_PNG();
                    break;
                case ("bmp"): Cipher_BMP();
                    break;
            }
        }

        private void Cipher_JPG()
        {

        }
        private void Cipher_JPEG()
        {

        }
        private void Cipher_PNG()
        {

        }
        private void Cipher_BMP()
        {

        }

    }
}
