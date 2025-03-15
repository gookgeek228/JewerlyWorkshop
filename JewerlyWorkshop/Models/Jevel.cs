using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class Jevel
{
    public int IdJevel { get; set; }

    public string? JevelName { get; set; }

    public string? JevelType { get; set; }

    public int? IdMaterial { get; set; }

    public int? Weight { get; set; }

    public int? Cost { get; set; }

    public virtual Material? IdMaterialNavigation { get; set; }

    public virtual JevelType? JevelTypeNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
