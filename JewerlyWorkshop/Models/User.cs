using System;
using System.Collections.Generic;

namespace JewerlyWorkshop.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Username { get; set; }

    public int? IdRole { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
