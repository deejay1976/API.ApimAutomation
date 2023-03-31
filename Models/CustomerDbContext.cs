using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MHR.API.ApimAutomation;

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
        => optionsBuilder.UseSqlServer("Server=MSL2988;Database=CustomerDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAddress>(entity =>
        {
            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasComment("Auto generated id");
            entity.Property(e => e.Address1).HasComment("First line of address");
            entity.Property(e => e.Address2).HasComment("Second line of address");
            entity.Property(e => e.Address3).HasComment("Third line of address");
            entity.Property(e => e.AddressType)
                .IsFixedLength()
                .HasComment("Whether address is for head office, operational office or registered office");
            entity.Property(e => e.ContactId).HasComment("Contact associated with the given address");
            entity.Property(e => e.Country).HasComment("Country like England");
            entity.Property(e => e.CreatedBy).HasComment("User who has created this record");
            entity.Property(e => e.CreatedDate).HasComment("the date when this record was created");
            entity.Property(e => e.CustomerId).HasComment("Which customer is associated with this address.");
            entity.Property(e => e.IsDeleted).HasComment("Is this a deleted record");
            entity.Property(e => e.Location).HasComment("location is important because one company can have multiple building at a place, hence building name can be taken as location.");
            entity.Property(e => e.ModifiedBy).HasComment("User who has modified the record last time");
            entity.Property(e => e.ModifiedDate).HasComment("The date when this record was last modified");
            entity.Property(e => e.PostCode)
                .IsFixedLength()
                .HasComment("postal code of the address");
            entity.Property(e => e.Region).HasComment("Region like East Midland, West Midland");
            entity.Property(e => e.SubRegion).HasComment("Sub Region of the address like county");
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.ContactFax).IsFixedLength();
            entity.Property(e => e.ContactMobile).IsFixedLength();
            entity.Property(e => e.ContactPhone1).IsFixedLength();
            entity.Property(e => e.ContactPhone2).IsFixedLength();
            entity.Property(e => e.ContactType).IsFixedLength();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.ModifiedBy).IsFixedLength();
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Auto Generated System Id");
            entity.Property(e => e.CustCategory)
                .IsFixedLength()
                .HasComment("Category of the customer");
            entity.Property(e => e.CustCode)
                .IsFixedLength()
                .HasComment("Customer Code from old system");
            entity.Property(e => e.CustGroup).HasComment("Group of Companies Name of the customer(Can be null)");
            entity.Property(e => e.CustName).HasComment("Name of the Customer");
            entity.Property(e => e.CustType)
                .IsFixedLength()
                .HasComment("Customer Type");
            entity.Property(e => e.Version).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
