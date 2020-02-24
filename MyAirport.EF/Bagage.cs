using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBO.MyAiport.EF
{
    public class Bagage
    {
        [Key]
        public int BagageID { get; set; }
        [ForeignKey("Vol")]
        public int VolID { get; set; }
        public string CodeIata { get; set; }
        public DateTime DateCreation { get; set; }
        public string Classe { get; set; }
        public bool Prioritaire { get; set; }
        public string Sta { get; set; }
        public string Ssur { get; set; }
        public string Destination { get; set; }
        public string Escale { get; set; }
    }
}
