using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Provinsi
    {
        [Key]
        public int idProvinsi { set; get; }
        public string namaProvinsi { set; get; }
    }
}
