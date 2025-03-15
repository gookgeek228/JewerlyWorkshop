using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class JevelType
{
    public string JevelType1 { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Jevel> Jevels { get; set; } = new List<Jevel>();
}
