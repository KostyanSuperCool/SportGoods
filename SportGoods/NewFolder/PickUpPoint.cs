using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder;

public partial class PickUpPoint
{
    public int Id { get; set; }

    public string AddresPickUpPoint { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
