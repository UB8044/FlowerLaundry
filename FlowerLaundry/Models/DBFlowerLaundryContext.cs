using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlowerLaundry.Models
{
    public partial class DBFlowerLaundryContext : DbContext
    {
        public DBFlowerLaundryContext()
        {
        }

        public DBFlowerLaundryContext(DbContextOptions<DBFlowerLaundryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bos> Bos { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Karyawan> Karyawan { get; set; }
        public virtual DbSet<Pesanan> Pesanan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bos>(entity =>
            {
                entity.HasKey(e => e.IdBos);

                entity.Property(e => e.IdBos)
                    .HasColumnName("ID_Bos")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.NamaBos)
                    .HasColumnName("Nama_Bos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_Hp")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasColumnName("Nama_Customer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_Hp")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Karyawan>(entity =>
            {
                entity.HasKey(e => e.IdKaryawan);

                entity.Property(e => e.IdKaryawan).HasColumnName("ID_Karyawan");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.JnsKelamin)
                    .HasColumnName("Jns_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKaryawan)
                    .HasColumnName("Nama_Karyawan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_Hp")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pesanan>(entity =>
            {
                entity.HasKey(e => e.NoPesanan);

                entity.Property(e => e.NoPesanan).HasColumnName("No_Pesanan");

                entity.Property(e => e.HrgTotal)
                    .HasColumnName("Hrg_Total")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdKaryawan).HasColumnName("ID_Karyawan");

                entity.Property(e => e.Pelayanan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TglOrder)
                    .HasColumnName("Tgl_Order")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Pesanan)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK__Pesanan__ID_Cust__173876EA");

                entity.HasOne(d => d.IdKaryawanNavigation)
                    .WithMany(p => p.Pesanan)
                    .HasForeignKey(d => d.IdKaryawan)
                    .HasConstraintName("FK__Pesanan__ID_Kary__164452B1");
            });
        }
    }
}
