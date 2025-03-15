using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdClient { get; set; }

    public int? IdJevel { get; set; }

    public int? IdMaster { get; set; }

    public string? ServiceName { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public int? Cost { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Jevel? IdJevelNavigation { get; set; }

    public virtual Master? IdMasterNavigation { get; set; }

    public virtual Service? ServiceNameNavigation { get; set; }
}
