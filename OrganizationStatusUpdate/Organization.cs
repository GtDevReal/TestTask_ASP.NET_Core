using System;
using System.Collections.Generic;

namespace OrganizationStatusUpdate;

public partial class Organization
{
    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? ParentId { get; set; }

    public virtual ICollection<Organization> InverseParent { get; set; } = new List<Organization>();

    public virtual Organization? Parent { get; set; }
}
