using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GBO.MyAiport.EF
{
    public class Bagage
    {

        [Key]
        public int BagageID { get; set; }

        [AllowNull]
        public Vol? Vol { get; set; }

        [Column(TypeName = "char(12)")]
        [Required]
        public string CodeIata { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        [AllowNull]
        [Column(TypeName = "char(1)")]
        public string? Classe { get; set; }

        [AllowNull]
        public bool? Prioritaire { get; set; }

        [AllowNull]
        [Column(TypeName = "char(1)")]
        public string? Sta { get; set; }

        [AllowNull]
        [Column(TypeName = "char(3)")]
        public string? Ssur { get; set; }

        [AllowNull]
        [Column(TypeName = "varchar(3)")]
        public string? Destination { get; set; }

        [AllowNull]
        [Column(TypeName = "char(3)")]
        public string? Escale { get; set; }
    }
}
