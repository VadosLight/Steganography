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
            Cipher_img();
        }
        
        private void Cipher_img()
        {
            List<byte> img_comment = new List<byte>();

            var img_BIN = File.ReadAllBytes(imgPath);
           
            //Добавляем метку комментария
            img_comment.AddRange(img_BIN);
            img_comment.Add(0xFF);
            img_comment.Add(0xFE);

            byte[] buffer = Encoding.UTF8.GetBytes(text);

            img_comment.AddRange(buffer);

            byte[] c = img_comment.ToArray();

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllBytes(sfd.FileName + '.' + typeOfImage, c);
            }
        }
    }

    class DeCipher
    {
        public DeCipher()
        {

        }

        public string DeCipher_img(string imgPath)
        {
            var img_BIN = File.ReadAllBytes(imgPath);
            List<byte> comment = new List<byte>();

            int FFFE = 0;

            for (int i = 0; i < img_BIN.Length; i++)
            {
                if(i == img_BIN.Length)
                {
                    MessageBox.Show("В изображении не найдено сокрытого текста");
                    return "";
                }

                if(img_BIN[i] == 0xFF && img_BIN[i + 1] == 0xFE)
                {
                    FFFE = i;
                    break;
                }
            }

            for(int i = FFFE+2; i < img_BIN.Length; i++)
            {
                comment.Add(img_BIN[i]);
            }
            byte[] byte_comment = comment.ToArray();

            var text = Encoding.UTF8.GetString(byte_comment, 0, byte_comment.Length);

            
            return text;
        }
    }
}
