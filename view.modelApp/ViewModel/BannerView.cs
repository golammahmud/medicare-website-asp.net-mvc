using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view.modelApp
{
    public class BannerView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Banner Cover Photo")]
        public IFormFile? CoverPhoto { get; set; }

        public string? BannerCoverImage { get; set; }
       
        public DateTime? createdAt { get; set; }
    }
}
