using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Core
{
    public class Book
    {
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string AuthorName { get; set; }
        [Required]
        public string BookName { get; set; }

        public Categories Categories { get; set; }
    }
}
