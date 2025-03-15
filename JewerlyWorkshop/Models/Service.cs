using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class Service
{
    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
