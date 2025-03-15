using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Fio { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
