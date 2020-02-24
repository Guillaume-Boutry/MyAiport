﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBO.MyAiport.EF
{
    public class Bagage
    {

        [Key]
        public int BagageID { get; set; }

        [ForeignKey("Vol")]
        [Required]
        public int VolID { get; set; }

        public Vol Vol { get; set; }

        [Column(TypeName = "char(12)")]
        [Required]
        public string CodeIata { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        [Column(TypeName = "char(1)")]
        public string Classe { get; set; }
        public bool Prioritaire { get; set; }

        [Column(TypeName = "char(1)")]
        public string Sta { get; set; }
        [Column(TypeName = "char(3)")]
        public string Ssur { get; set; }
        [Column(TypeName = "varchar(3)")]

        public string Destination { get; set; }

        [Column(TypeName = "char(3)")]
        public string Escale { get; set; }
    }
}