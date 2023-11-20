using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace manavmvc.Models
{
    public class SebzeModel
    {
        public int sebzeID { get; set; }
        public string sebzeAdi { get; set; }    
        public DateTime sebzeSonKullanma { get; set; }
        public string sebzeAdres {get; set; }
        public string sebzeStok {get; set; }
    }
}