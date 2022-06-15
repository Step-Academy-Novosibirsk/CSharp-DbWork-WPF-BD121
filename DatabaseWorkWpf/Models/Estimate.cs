using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;
[Table("Estimates")]
public class Estimate : ModelBase
{
    [NotNull]
    public Sale? Sale { get; set; }
    [NotNull]
    public Good? Good { get; set; }
    public int Amount { get; set; }

    public override object Clone() => new Estimate()
    {
        Amount = Amount,
        Sale = Sale.Clone() as Sale,
        Good = Good.Clone() as Good
    };

}