using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly DateOrder { get; set; }

    public DateOnly DateOfIssue { get; set; }

    public int IdAddresPickUpPoint { get; set; }

    public int IdUser { get; set; }

    public string Code { get; set; } = null!;

    public int IdStatus { get; set; }

    public virtual PickUpPoint PickUpPoint { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<OrderComposition> OrderCompositions { get; set; } = new List<OrderComposition>();
}
