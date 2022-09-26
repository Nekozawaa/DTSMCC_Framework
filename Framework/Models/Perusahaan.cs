using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Models
{
    public class Perusahaan
    {
        [Key]
        public int idPerusahan { set; get; }
        public string tipePerusahaan { set; get; }
    }
}
