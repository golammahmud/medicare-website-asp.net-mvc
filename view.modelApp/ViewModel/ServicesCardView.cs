using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view.modelApp.ViewModel
{
    public class ServicesCardView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }


        public string? Content { get; set; }

        [Display(Name = "Choose services Image")]
        [Required]
        [NotMapped]
        public IFormFile? ServicesPhoto { get; set; }

        public string? ServicesPhotoUrl { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; }
    }
}
