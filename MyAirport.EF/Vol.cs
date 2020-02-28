using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBO.MyAiport.EF
{
    public class Vol
    {
        [Key]
        public int VolID { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Cie { get; set; } = null!;

        [Column(TypeName = "varchar(5)")]
        public string Lig { get; set; } = null!;

        public DateTime? Dhc { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        public short? Pax { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Des { get; set; }

        public ICollection<Bagage> Bagages { get; set; } = null!;
    }
}
