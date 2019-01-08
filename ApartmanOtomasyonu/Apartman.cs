using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanOtomasyonu
{
   
    class Gelir 
    {
        public int GelirID { get; set; }
        public int DaireNo { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
    class Gider 
    {
        public int ID { get; set; }
        public GiderTuru GiderTuru { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }

    enum GiderTuru
    {
        Elektrik,
        Su,
        Asansör,
        Temizlik
    }
}
