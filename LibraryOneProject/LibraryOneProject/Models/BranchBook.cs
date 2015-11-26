using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryOneProject.Models
{
    public class BranchBook
    {
        //Class to track individual books and what branch they are at
        public int ID { get; set; }

        //FKs
        public int BookID { get; set; }
        public int BranchID { get; set; }
        //public int? ReservationID { get; set; }

        //Navigation Properties
        public virtual Book Book { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
