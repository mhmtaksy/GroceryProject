using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace manavmvc.Models
{
    public class MeyveModel
    {
        public int meyveID { get; set; }
        public string meyveAdi { get; set; }
        public DateTime meyveSonKullanma{ get; set; }
        public string meyveAdres {get; set; }
        public string meyveStok { get; set; }

    }
}