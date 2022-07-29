using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view.modelApp.ViewModel
{
    public class DoctorsMainView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? createdAt { get; set; }
    }
}
