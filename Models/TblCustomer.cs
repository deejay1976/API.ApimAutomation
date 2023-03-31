using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MHR.API.ApimAutomation;

[Table("tblCustomer", Schema = "Customer")]
public partial class TblCustomer
{
    /// <summary>
    /// Auto Generated System Id
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Customer Code from old system
    /// </summary>
    [StringLength(10)]
    public string CustCode { get; set; } = null!;

    /// <summary>
    /// Name of the Customer
    /// </summary>
    [StringLength(100)]
    [Unicode(false)]
    public string CustName { get; set; } = null!;

    /// <summary>
    /// Group of Companies Name of the customer(Can be null)
    /// </summary>
    [StringLength(100)]
    [Unicode(false)]
    public string? CustGroup { get; set; }

    /// <summary>
    /// Customer Type
    /// </summary>
    [StringLength(10)]
    public string CustType { get; set; } = null!;

    /// <summary>
    /// Category of the customer
    /// </summary>
    [StringLength(10)]
    public string CustCategory { get; set; } = null!;

    [StringLength(10)]
    public string Version { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    public string? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateModified { get; set; }
}
