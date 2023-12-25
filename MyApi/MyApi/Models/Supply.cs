using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApi.Models;

public partial class Supply
{
    public int IdSupplies { get; set; }

    public string Type { get; set; } = null!;

    public int Weight { get; set; }

    public int IdStock { get; set; }

    public int IdProvider { get; set; }

    public int IdProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Provider IdProviderNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Stock IdStockNavigation { get; set; } = null!;
}
