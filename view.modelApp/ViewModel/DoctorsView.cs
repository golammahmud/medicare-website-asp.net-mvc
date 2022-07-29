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
    public class DoctorsView
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100,MinimumLength =5)]
        public string DoctorName { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string DoctorDesignation { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 25)]
        public string DoctorMessage { get; set; }


        [Display(Name = "Choose About Cover Photo")]
        [Required]
        [NotMapped]
        public IFormFile? ProfilePhoto { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        public DateTime? createdAt { get; set; }
    }
}
