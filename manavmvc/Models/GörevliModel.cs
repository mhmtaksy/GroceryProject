using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace manavmvc.Models
{
    public class GörevliModel
    {
        public int görevliID { get; set; }
        public string görevliAdi { get; set; }
        public bool görevliCinsiyet{ get; set; }
        public DateTime dogumTarihi {get; set; }
        public string Unvan {get; set; }

    }
}