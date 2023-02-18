using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Uyeler
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string VatandaslikNo { get; set; }
        public string TokenAdres { get; set; }
        public decimal Bakiye { get; set; }
    }
}
