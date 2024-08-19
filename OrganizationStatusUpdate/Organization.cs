using System;
using System.Collections.Generic;

namespace OrganizationStatusUpdate;

public partial class Organization
{
    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Division { get; set; }
}
