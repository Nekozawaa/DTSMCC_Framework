using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Penempatan
    {
        [Key]
        public int idPenempatan { set; get; }
        public string namaPerusahaan { set; get; }

        public Perusahaan Perusahaan { set; get; }
        [ForeignKey("Perusahaan")]
        public int idPerusahaan { set; get; }

        public Provinsi Provinsi { set; get; }
        [ForeignKey("Provinsi")]
        public int idProvinsi { set; get; }
    }
}
