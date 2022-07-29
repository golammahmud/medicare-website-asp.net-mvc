using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view.modelApp.ViewModel
{
    public class CustomerSupportView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? CreatedAt { get; set; }
    }
}
