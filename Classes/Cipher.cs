using System;
using System.Collections;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using System.Linq;

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
            var img_BIN = File.ReadAllBytes(imgPath);
            //MessageBox.Show(img_BIN[0].ToString());
            //ff da  = 255 218
            int FFDA=0; //Индекс начала байта флага начала изображения!!! Не забыть сделать смещение после флага
            int END_FFDA=0;
            //ff d9 = 255 217
            int FFD9=0; //Индекс метки - конец изображения

            //Поиск флагов
            for (int i = 0; i < img_BIN.Length; i++)
            {
                if (img_BIN[i] == 255 && img_BIN[i + 1] == 218)
                {
                    FFDA = i;
                    END_FFDA = i + 14;
                }

                if (img_BIN[i] == 255 && img_BIN[i + 1] == 217)
                {
                    FFD9 = i;
                    break;
                }                  
            }
            //8a 28 a0 02  == 138 40 160 2
            //51 45 14 00
            //51 40 05 14  
            //45 14 50 01  
            //a2 80 0a 28  
            //0a 28 a2
            for (int i = END_FFDA; i+2 < FFD9;)
            {
                if (img_BIN[i] != 0x0a && img_BIN[i+1] != 0x28 && img_BIN[i+2] != 0xa2 && img_BIN[i+3] != 0x8a ||
                    img_BIN[i] != 0x51 && img_BIN[i + 1] != 0x45 && img_BIN[i + 2] != 0x14 && img_BIN[i + 3] != 0x00 ||
                    img_BIN[i] != 0x51 && img_BIN[i + 1] != 0x40 && img_BIN[i + 2] != 0x05 && img_BIN[i + 3] != 0x14 ||
                    img_BIN[i] != 0x45 && img_BIN[i + 1] != 0x14 && img_BIN[i + 2] != 0x50 && img_BIN[i + 3] != 0x01)
                {
                    if (img_BIN[i] == 255)
                        img_BIN[i]--;
                    else
                        img_BIN[i]++;
                    i++;
                }
                else
                {
                    i += 4;
                }
            }

            File.WriteAllBytes(@"C:\Users\Vadim\Desktop\123.jpg", img_BIN);


        }
        private void Cipher_PNG()
        {

        }
        private void Cipher_BMP()
        {


        }


        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}
