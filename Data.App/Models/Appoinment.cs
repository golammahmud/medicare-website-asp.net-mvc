using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.App.Models
{
    public class Appoinment
    {
        [Key]
        public int AppoinmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
       
        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
