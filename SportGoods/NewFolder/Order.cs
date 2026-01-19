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

    public virtual PickUpPoint IdAddresPickUpPointNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderComposition> OrderCompositions { get; set; } = new List<OrderComposition>();
}
