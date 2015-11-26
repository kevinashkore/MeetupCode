using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryOneProject.Models
{
    public class Checkout
    {
        public int ID { get; set; }
        public DateTime DateCheckedOut { get; set; }

        //FKs
        public int BranchBookID { get; set; }
        //Navigation Properties
        public virtual BranchBook BranchBook { get; set; }
    }
}