using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Byte[] FileContent { get; set; }
        public string filePath { get; set; }
    }
}