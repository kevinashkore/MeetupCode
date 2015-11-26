using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryOneProject.Models
{
    public class Reservation
    {
        //
        //public int ID { get; set; }
        public DateTime DateReserved { get; set; }

        //FKs
        [Key]
        [ForeignKey("BranchBook")]
        public int BranchBookID { get; set; }
        public int PatronID { get; set; }
        //Navigation Properties
        public virtual BranchBook BranchBook { get; set; }
        public Patron Patron { get; set; }
    }
}