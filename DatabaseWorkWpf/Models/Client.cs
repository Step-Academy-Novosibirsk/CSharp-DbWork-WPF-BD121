using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;
[Table("Clients")]
public class Client : PersonModel
{
    [NotNull]
    public string? Email { get; set; }
    [NotNull]
    public string? Address { get; set; }
    public override object Clone() => new Client()
        {
            Id = Id,
            Address = Address,
            Email = Email,
            Name = Name,
            Phone = Phone
        };
}