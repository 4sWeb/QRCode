using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Base64Project.IRepo
{
  
    public interface IMainc
    {
        string convertTagToHexa(int tagValue, string all);
        string convertLengthToHexa(int lengthValue, string all);
        string convertContentToHexa(string[] ContentArray, int i, string all);
        string EncodingFun(string phrase);
        string HexToBase64(string strInput);
        byte[] GenerateQRCode(string Base64);
        void DrawImage(string FilePath, byte[] QRcode);
    }
}
