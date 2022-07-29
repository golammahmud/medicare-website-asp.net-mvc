using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.App.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        [Display(Name = "Choose Banner Cover Photo")]
        [Required]
        [NotMapped]
        public IFormFile? CoverPhoto { get; set; }
        public string? CoverImageUrl { get; set; }

        public DateTime? createdAt { get; set; }
    }
}
