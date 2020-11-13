using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicalog_App.Models
{
    public class AlbumModel
    {
        public int Albumid { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public int Stock { get; set; }
        public string Type { get; set; }
    }
}