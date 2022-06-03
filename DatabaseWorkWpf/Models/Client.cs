using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseWorkWpf.Models;
[Table("Clients")]
public class Client : ICloneable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [NotNull]
    public string? Name { get; set; }
    [NotNull]
    public string? Phone { get; set; }
    [MaxLength(11)]
    [MinLength(11)]
    [NotNull]
    public string? Email { get; set; }
    [NotNull]
    public string? Address { get; set; }
    public object Clone() => new Client()
        {
            Id = Id,
            Address = Address,
            Email = Email,
            Name = Name,
            Phone = Phone
        };
}