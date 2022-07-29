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
    public class Doctors
    {
        [Key]
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string DoctorDesignation { get; set; }

        public string DoctorMessage { get; set; }


        [Display(Name = "Choose About Cover Photo")]
        [Required]
        [NotMapped]
        public IFormFile? ProfilePhoto { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
