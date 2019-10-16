using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BlowOut.Models;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [Required]
        public int InstrumentID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey("Client")]
        public int? ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}