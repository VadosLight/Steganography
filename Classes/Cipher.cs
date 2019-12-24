using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LZWLib;

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
            List<byte> img_comment = new List<byte>();

            var img_BIN = File.ReadAllBytes(imgPath);
            byte[] comment = new byte[10];

            //Добавляем комментарий
            img_comment.AddRange(img_BIN);
            img_comment.Add(0xFF);
            img_comment.Add(0xFE);

            LZWEncoder encoder = new LZWEncoder();
            var buffer = encoder.EncodeToByteList(text);

            img_comment.AddRange(buffer);

            byte[] c = img_comment.ToArray();
            File.WriteAllBytes(@"C:\Users\Vadim\Desktop\123.jpg", c);
            


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

    class DeCipher
    {

    }
}
