using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryOneProject.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        //FKs
        public int AuthorID { get; set; }

        //Navigation Properties
        public virtual Author Author { get; set; }

        public virtual ICollection<BranchBook> BranchBooks { get; set; }
    }
}