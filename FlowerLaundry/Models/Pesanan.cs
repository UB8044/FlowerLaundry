using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowerLaundry.Models
{
    public partial class Pesanan
    {
        public int NoPesanan { get; set; }

        [Required(ErrorMessage = "Berat tidak boleh kosong...")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public double? Berat { get; set; }

        [Required(ErrorMessage = "Pelayanan belum dipilih...")]
        public string Pelayanan { get; set; }

        [Required(ErrorMessage = "Masukkan harga total...")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Hanya boleh diisi oleh angka")]
        public string HrgTotal { get; set; }

        [Required(ErrorMessage = "Tanggal order belum dipilih...")]
        public DateTime? TglOrder { get; set; }

        [Required(ErrorMessage = "Nama karyawan belum dipilih...")]
        public int? IdKaryawan { get; set; }

        [Required(ErrorMessage = "Nama customer belum dipilih...")]
        public int? IdCustomer { get; set; }

        public Customer IdCustomerNavigation { get; set; }
        public Karyawan IdKaryawanNavigation { get; set; }
    }
}
