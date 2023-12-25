
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApi.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Amount { get; set; } = null!;

    public decimal Price { get; set; }

    public string Type { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
