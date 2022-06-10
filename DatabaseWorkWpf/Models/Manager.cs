using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;
[Table("Managers")]
public class Manager: PersonModel
{
    [NotNull]
    public string? Post { get; set; }

    public decimal Salary { get; set; }
    public double Bonus { get; set; }

    public override object Clone() => new Manager()
    {
        Id = Id,
        Name = Name,
        Post = Post,
        Phone = Phone,
        Salary = Salary,
        Bonus = Bonus
    };

}