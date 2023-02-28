using System;
using System.Collections.Generic;

namespace MHR.API.ApimAutomation.Models;

public partial class TblCustomer
{
    public int Id { get; set; }

    public string CustCode { get; set; } = null!;

    public string CustName { get; set; } = null!;

    public string CustGroup { get; set; } = null!;

    public string CustType { get; set; } = null!;

    public string CustCategory { get; set; } = null!;

    public string Version { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
