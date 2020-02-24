using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GBO.MyAiport.EF
{
    public class Vol
    {
        [Key]
        public int VolID { get; set; }
        public string Cie { get; set; }
        public string Lig { get; set; }
        public DateTime Dhc { get; set; }
        public string Pkg { get; set; }
        public string Imm { get; set; }
        public short Pax { get; set; }
        public string Des { get; set; }
    }
}
