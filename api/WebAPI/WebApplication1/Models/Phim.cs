using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Phim
    {
        public int MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string Trailer { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public string Slogan { get; set; }
        public int ThoiLuong { get; set; }
    }
}