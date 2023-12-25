using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApi.Models;

public partial class Worker
{
    public int IdWorkers { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
