using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder;

public partial class Product
{
    public int Id { get; set; }

    public string Article { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int IdCategory { get; set; }

    public int IdManufacturer { get; set; }

    public int IdSupplier { get; set; }

    public string Price { get; set; } = null!;

    public string UnitOfMeasurement { get; set; } = null!;

    public string Discount { get; set; } = null!;

    public string CountOnStock { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Image { get; set; }

    public virtual CategoryProduct IdCategoryNavigation { get; set; } = null!;

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual ICollection<OrderComposition> OrderCompositions { get; set; } = new List<OrderComposition>();
}
