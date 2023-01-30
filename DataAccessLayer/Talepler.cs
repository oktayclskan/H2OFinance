using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Talepler
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public string UyeAdi { get; set; }
        public int YoneticiID { get; set; }
        public string YoneticiAdi { get; set; }
        public decimal Miktar { get; set; }
        public DateTime TalepTarih { get; set; }
        public DateTime OnayTarih { get; set; }
        public Byte Durum { get; set; }
    }
}
