using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;
[Table("Goods")]
public class Good : ModelBase
{
    [NotNull]
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }

    public override object Clone() => new Good()
    {
        Amount = Amount,
        Comment = Comment,
        Description = Description,
        Id = Id,
        Name = Name,
        Price = Price
    };

}