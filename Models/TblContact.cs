using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MHR.API.ApimAutomation;

[Table("tblContact", Schema = "Customer")]
public partial class TblContact
{
    [Key]
    public int ContactId { get; set; }

    public int? CustomerId { get; set; }

    public int? AddressId { get; set; }

    [Column("ContactFName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ContactFname { get; set; }

    [Column("ContactMName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ContactMname { get; set; }

    [Column("ContactLName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ContactLname { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? ContactEmail { get; set; }

    [StringLength(15)]
    public string? ContactFax { get; set; }

    [StringLength(15)]
    public string? ContactPhone1 { get; set; }

    [StringLength(15)]
    public string? ContactPhone2 { get; set; }

    [StringLength(15)]
    public string? ContactMobile { get; set; }

    [StringLength(10)]
    public string? ContactType { get; set; }

    public bool? IsDeleted { get; set; }

    [StringLength(10)]
    public string? CreatedBy { get; set; }

    [StringLength(10)]
    public string? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
