using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Game.Model
{
    public class RtnGoogle
    {
        public string ImgSrc { get; set; }
        public string GoogleSg { get; set; }
    }

    public class RtnImg
    {
        public IFormFile formFile { get; set; }
        public string OpenId { get; set; }
        public string UlangKey { get; set; }
    }
}
