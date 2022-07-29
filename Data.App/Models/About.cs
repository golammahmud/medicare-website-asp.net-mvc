using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.App.Models
{
    public class About
    {
        [Key]
        public int Id {get;set;}

        [Required]
        public string Content {get;set;}

        [Display(Name = "Choose About Cover Photo")]
        [Required]
        [NotMapped]
        public IFormFile? CoverPhoto { get; set; }
        public string? AboutDataImage { get; set; }
            
        public DateTime? createdAt { get; set; }


    }
}
