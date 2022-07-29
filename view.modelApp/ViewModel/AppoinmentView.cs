using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view.modelApp.ViewModel
{
    public class AppoinmentView
    {

        [Key]
        public int AppoinmentId { get; set; }

        [Required]
        [StringLength(100, MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string EmailAddress { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }


        [Required]
        [MaxLength(80)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string? Message { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? CreatedDate { get; set; }
    }
    
}
