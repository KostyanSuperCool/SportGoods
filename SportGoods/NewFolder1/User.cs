using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder1;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string UserName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
