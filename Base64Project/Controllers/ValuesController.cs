using Base64Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base64Project.Repo;
using Base64Project.IRepo;
using Microsoft.AspNetCore.Authorization;

namespace Base64Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IMainc Repo;
        public ValuesController(IMainc _Repo)
        {
            Repo = _Repo;    
        }

        [HttpGet]
        [AllowAnonymous]
        public string EncodingVB(string phrase)
        {
            string filePATH = @"D:\bin\MyImage.png";
            string CODE = null;
                string AllCode = Repo.EncodingFun(phrase);
                CODE = Repo.HexToBase64(AllCode);
            byte[] QRcode = Repo.GenerateQRCode(CODE);
            Repo.DrawImage(filePATH, QRcode);
            return CODE;
        }
    }
}

