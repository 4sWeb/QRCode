using Base64Project.IRepo;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Base64Project.Repo
{

    public class Mainc:IMainc
    {









        public string convertContentToHexa(string[] ContentArray, int i, string all)
        {
            foreach (char letter in ContentArray[i])
            {
                int value2 = Convert.ToInt32(letter);
                string hexOutput2 = String.Format("{0:x}", value2);
                all += hexOutput2;
            };
            return all;
        }

        public string convertLengthToHexa(int lengthValue, string all)
        {
            string hexOutput1 = null;
            if (lengthValue < 15)
                hexOutput1 = String.Format("{0:x}", lengthValue);
            else hexOutput1 = String.Format("{0:X}", lengthValue);
            if (lengthValue <= 15)
                all += 0 + hexOutput1;
            else all += hexOutput1;

            return all;
        }

        public string convertTagToHexa(int tagValue, string all)
        {
            string hexOutput = String.Format("{0:X}", tagValue);

            return all += 0 + hexOutput;
        }

        public void DrawImage(string FilePath, byte[] QRcode)
        {
            Image image;
            MemoryStream ms;
            using (ms = new MemoryStream(QRcode))
            {
                image = Image.FromStream(ms);

            }
            File.WriteAllBytes(FilePath, QRcode);
        }

        public string EncodingFun(string phrase)
        {
            string AllCode = null;


            string[] words = phrase.Split('@');
            string Tags = words[0];
            string[] TagArray = Tags.Split(',');
            string Length = words[1];
            string[] LengthArray = Length.Split(',');
            string Content = words[2];
            string[] ContentArray = Content.Split(',');

            for (int i = 0; i <= TagArray.Length - 1; i++)
            {
                string all = null;

                string TagResult = convertTagToHexa(Convert.ToInt32(TagArray[i]), all);
                string TagLengthResult = convertLengthToHexa(Convert.ToInt32(LengthArray[i].ToString()), TagResult);
                string ContentTagLength = convertContentToHexa(ContentArray, i, TagLengthResult);

                AllCode += ContentTagLength;

            }
            return AllCode;
        }

        public byte[] GenerateQRCode(string Base64)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Base64, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(30);
            byte[] QRcode = Convert.FromBase64String(qrCodeImageAsBase64);
            return QRcode;
        }

        public string HexToBase64(string strInput)
        {
            try
            {
                var bytes = new byte[strInput.Length / 2];
                for (var i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(strInput.Substring(i * 2, 2), 16);
                }
                return Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                return "-1";
            }
        }


}
    }

