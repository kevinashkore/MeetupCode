using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOneProject.Models
{
    public class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //Navigation Properties
        //public ICollection<BranchBook> BranchBooks { get; set; }
    }
}
