using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerLaundry.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Pesanan = new HashSet<Pesanan>();
        }

        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Nama customer tidak boleh kosong...")]
        public string NamaCustomer { get; set; }

        [Required(ErrorMessage = "No HP tidak boleh kosong...")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public string NoHp { get; set; }

        [Required(ErrorMessage = "Alamat tidak boleh kosong...")]
        public string Alamat { get; set; }

        public ICollection<Pesanan> Pesanan { get; set; }
    }
}
