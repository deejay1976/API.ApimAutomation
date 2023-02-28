using System;
using System.Collections.Generic;

namespace MHR.API.ApimAutomation.Models;

public partial class TblContact
{
    public int ContactId { get; set; }

    public int? CustomerId { get; set; }

    public int? AddressId { get; set; }

    public string? ContactFname { get; set; }

    public string? ContactMname { get; set; }

    public string? ContactLname { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactFax { get; set; }

    public string? ContactPhone1 { get; set; }

    public string? ContactPhone2 { get; set; }

    public string? ContactMobile { get; set; }

    public string? ContactType { get; set; }

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
