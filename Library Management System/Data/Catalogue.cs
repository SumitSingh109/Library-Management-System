using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class Catalogue
    {
        [Key]
        public int Book_ID { get; set; }

        public string Book_Name { get; set; }

        public string Book_Author { get; set; }

        public DateTime Book_Registration { get; set; }

        public string Book_Category { get; set; }

        public string Book_Description { get; set; }
    }
}
