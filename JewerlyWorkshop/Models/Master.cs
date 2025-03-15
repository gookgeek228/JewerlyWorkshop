using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class Master
{
    public int IdMaster { get; set; }

    public string? Fio { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DismissialDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
