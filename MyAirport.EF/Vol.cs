using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GBO.MyAiport.EF
{
    public class Vol
    {
        [Key]
        public int VolID { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Cie { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Lig { get; set; }

        [AllowNull]
        public DateTime? Dhc { get; set; }

        [AllowNull]
        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        [AllowNull]
        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        [AllowNull]
        public short? Pax { get; set; }

        [AllowNull]
        [Column(TypeName = "char(3)")]
        public string? Des { get; set; }

        public List<Bagage> Bagages { get; set; }
    }
}
