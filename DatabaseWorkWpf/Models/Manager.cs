using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;
[Table("Managers")]
public class Manager: PersonModel
{
    [NotNull]
    public string? Post { get; set; }

    public decimal Salary { get; set; }
    public double Bonus { get; set; }
    [InverseProperty("Manager")]
    public List<Sale?>? Sales { get; set; }

    public override object Clone() => new Manager()
    {
        Id = Id,
        Name = Name,
        Post = Post,
        Phone = Phone,
        Salary = Salary,
        Bonus = Bonus,
        Sales = Sales?.Select(s => s?.Clone() as Sale).ToList()
    };
}