using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string ManufacturerProduct { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
