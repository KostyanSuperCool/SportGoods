using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder1;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierProduct { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
