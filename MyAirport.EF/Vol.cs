using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBO.MyAirport.EF
{
    /// <summary>
    /// Vol description
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Vol()
        {
            Cie = "";
            Lig = "";
            Bagages = new List<Bagage>();
        }

        /// <summary>
        /// Primary key, Vol ID
        /// </summary>
        [Key]
        public int VolID { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        [Column(TypeName = "varchar(5)")]
        public string Cie { get; set; }

        /// <summary>
        /// Airline
        /// </summary>
        [Column(TypeName = "varchar(5)")]
        public string Lig { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime? Dhc { get; set; }

        /// <summary>
        /// Pkg
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        /// <summary>
        /// Imm
        /// </summary>
        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        /// <summary>
        /// Pax
        /// </summary>
        public short? Pax { get; set; }

        /// <summary>
        /// Des
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Des { get; set; }

        /// <summary>
        /// All bagages associated to Vol
        /// </summary>
        public virtual ICollection<Bagage> Bagages { get; set; }
    }
}
