using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace MyApi.Models;

public partial class Stock
{
    public int IdStock { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public int IdWorkers { get; set; }

    public virtual Worker IdWorkersNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
