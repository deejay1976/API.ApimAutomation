using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MHR.API.ApimAutomation;

[Table("tblAddress", Schema = "Customer")]
public partial class TblAddress
{
    /// <summary>
    /// Auto generated id
    /// </summary>
    [Key]
    public int AddressId { get; set; }

    /// <summary>
    /// location is important because one company can have multiple building at a place, hence building name can be taken as location.
    /// </summary>
    [StringLength(50)]
    public string? Location { get; set; }

    /// <summary>
    /// Which customer is associated with this address.
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// Contact associated with the given address
    /// </summary>
    public int? ContactId { get; set; }

    /// <summary>
    /// Whether address is for head office, operational office or registered office
    /// </summary>
    [StringLength(10)]
    public string? AddressType { get; set; }

    /// <summary>
    /// First line of address
    /// </summary>
    [StringLength(50)]
    public string? Address1 { get; set; }

    /// <summary>
    /// Second line of address
    /// </summary>
    [StringLength(50)]
    public string Address2 { get; set; } = null!;

    /// <summary>
    /// Third line of address
    /// </summary>
    [StringLength(50)]
    public string Address3 { get; set; } = null!;

    /// <summary>
    /// Sub Region of the address like county
    /// </summary>
    [StringLength(50)]
    [Unicode(false)]
    public string SubRegion { get; set; } = null!;

    /// <summary>
    /// Region like East Midland, West Midland
    /// </summary>
    [StringLength(50)]
    [Unicode(false)]
    public string Region { get; set; } = null!;

    /// <summary>
    /// Country like England
    /// </summary>
    [StringLength(50)]
    [Unicode(false)]
    public string? Country { get; set; }

    /// <summary>
    /// postal code of the address
    /// </summary>
    [StringLength(10)]
    public string? PostCode { get; set; }

    /// <summary>
    /// Is this a deleted record
    /// </summary>
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// the date when this record was created
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The date when this record was last modified
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    /// <summary>
    /// User who has created this record
    /// </summary>
    [StringLength(50)]
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// User who has modified the record last time
    /// </summary>
    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;
}
