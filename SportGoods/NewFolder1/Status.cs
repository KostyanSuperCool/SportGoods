using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder1;

public partial class Status
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
