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
    public class AboutView
    {

        [Key]
        public int Id { get; set; }


        [StringLength(100, ErrorMessage = "Do not enter more than 250 characters")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Choose About Cover Photo")]      
        public IFormFile? ImgFile { get; set; }


        [Display(Name = " Cover Photo")]
        public string? AboutViewImage { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; }

    }
}
