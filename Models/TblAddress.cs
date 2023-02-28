using System;
using System.Collections.Generic;

namespace MHR.API.ApimAutomation.Models;

public partial class TblAddress
{
    public int AddressId { get; set; }

    public string? Location { get; set; }

    public int? CustomerId { get; set; }

    public int? ContactId { get; set; }

    public string? AddressType { get; set; }

    public string? Address1 { get; set; }

    public string Address2 { get; set; } = null!;

    public string Address3 { get; set; } = null!;

    public string SubRegion { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string? Country { get; set; }

    public string? PostCode { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string ModifiedBy { get; set; } = null!;
}
