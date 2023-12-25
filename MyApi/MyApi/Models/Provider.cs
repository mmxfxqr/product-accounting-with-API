using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApi.Models;

public partial class Provider
{
    public int IdProvider { get; set; }

    public string CompanyName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CityProvider { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
