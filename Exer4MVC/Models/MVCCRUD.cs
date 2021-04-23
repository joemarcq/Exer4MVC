using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exer4MVC.Models
{
    public class MVCCRUD
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required, StringLength(1)]
        public string MI { get; set; }
        [Required]
        public string Emailaddress { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, Range(18, 99)]
        public int Age { get; set; }
        [Required, StringLength(11)]
        public string Contact { get; set; }
    }
}
