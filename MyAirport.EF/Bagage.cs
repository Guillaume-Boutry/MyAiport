using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBO.MyAirport.EF
{
    /// <summary>
    /// Bagage description
    /// </summary>
    public class Bagage
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public Bagage()
        {
            CodeIata = "";

        }
        
        /// <summary>
        /// Primary Key, Bagage ID
        /// </summary>
        [Key]
        public int BagageID { get; set; }

        /// <summary>
        /// Associated Vol, navigation property
        /// </summary>
        public virtual Vol? Vol { get; set; }

        /// <summary>
        /// CodeIata
        /// </summary>
        [Column(TypeName = "char(12)")]
        public string CodeIata { get; set; }

        /// <summary>
        /// DateCreation
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Passenger class
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string? Classe { get; set; }

        /// <summary>
        /// Is prioritized ?
        /// </summary>
        public bool Prioritaire { get; set; } = false;

        /// <summary>
        /// Sta
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string? Sta { get; set; }

        /// <summary>
        /// Ssur
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Ssur { get; set; }

        /// <summary>
        /// Vol destination
        /// </summary>
        [Column(TypeName = "varchar(3)")]
        public string? Destination { get; set; }

        /// <summary>
        /// Vol escale
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Escale { get; set; }

    }
}
