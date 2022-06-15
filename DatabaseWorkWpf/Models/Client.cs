using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;
[Table("Clients")]
public class Client : PersonModel
{
    [NotNull]
    public string? Email { get; set; }
    [NotNull]
    public string? Address { get; set; }
    [InverseProperty("Client")]
    public List<Sale?>? Sales { get; set; }
    public override object Clone() => new Client()
        {
            Id = Id,
            Address = Address,
            Email = Email,
            Name = Name,
            Phone = Phone,
            Sales = Sales?.Select(s => s?.Clone() as Sale).ToList()
        };
}