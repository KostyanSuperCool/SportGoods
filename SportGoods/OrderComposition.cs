using System;
using System.Collections.Generic;

namespace SportGoods;

public partial class OrderComposition
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdArticle { get; set; }

    public string Count { get; set; } = null!;

    public virtual Product IdArticleNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
