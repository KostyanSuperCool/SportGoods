using System;
using System.Collections.Generic;

namespace SportGoods.NewFolder;

public partial class OrderComposition
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdArticle { get; set; }

    public string Count { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
