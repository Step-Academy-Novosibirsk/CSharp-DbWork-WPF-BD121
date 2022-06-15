using System.ComponentModel.DataAnnotations;
using DatabaseWorkWpf.Mvvm.Utils;

namespace DatabaseWorkWpf.Models.Base;

public abstract class PersonModel : ModelBase
{
    [NotNull]
    public string? Name { get; set; }
    [NotNull]
    [StringLength(11)]
    public string? Phone { get; set; }

    public override string ToString() => Name ?? "";

}