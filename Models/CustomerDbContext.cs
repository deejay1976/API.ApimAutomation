using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MHR.API.ApimAutomation.Models;

public partial class CustomerDbContext : DbContext
{
    public CustomerDbContext()
    {
    }

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAddress> TblAddresses { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSL2988;Database=CustomerDB;TrustServerCertificate=true; Trusted_Connection=SSPI; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("tblAddress", "Customer");

            entity.Property(e => e.AddressId).ValueGeneratedNever();
            entity.Property(e => e.Address1).HasMaxLength(50);
            entity.Property(e => e.Address2).HasMaxLength(50);
            entity.Property(e => e.Address3).HasMaxLength(50);
            entity.Property(e => e.AddressType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PostCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubRegion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("tblContact", "Customer");

            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ContactFax)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.ContactFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ContactFName");
            entity.Property(e => e.ContactLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ContactLName");
            entity.Property(e => e.ContactMname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ContactMName");
            entity.Property(e => e.ContactMobile)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.ContactPhone1)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.ContactPhone2)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.ContactType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.ToTable("tblCustomer", "Customer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CustCategory)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CustCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CustGroup)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Version)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
