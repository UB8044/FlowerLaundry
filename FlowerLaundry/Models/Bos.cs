using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerLaundry.Models
{
    public partial class Bos
    {
        public string IdBos { get; set; }

        [Required(ErrorMessage = "Nama bos tidak boleh kosong...")]
        public string NamaBos { get; set; }

        [Required(ErrorMessage = "No HP tidak boleh kosong...")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public string NoHp { get; set; }

        [Required(ErrorMessage = "Email tidak boleh kosong...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong...")]
        [MinLength(6, ErrorMessage = "No hp minimal 6 angka")]
        [MaxLength(20, ErrorMessage = "No hp maksimal 20 angka")]
        public string Password { get; set; }
    }
}
