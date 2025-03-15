using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string? MaterialName { get; set; }

    public int? GramPrice { get; set; }

    public virtual ICollection<Jevel> Jevels { get; set; } = new List<Jevel>();
}
