using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DatabaseWorkWpf.Models.Base;

namespace DatabaseWorkWpf.Models;

[Table("Sales")]
public class Sale : ModelBase
{
    [ForeignKey("Manager")]
    public int IdManager { get; set; }
    public DateTime SaleDate { get; set; }
    public int Status { get; set; }
    public string? Comment { get; set; }
    public Client? Client { get; set; }
    public Manager? Manager { get; set; }
    [InverseProperty("Sale")]
    public List<Estimate?>? Estimates { get; set; }

    public override object Clone() => new Sale()
    {
        IdManager = IdManager,
        Status = Status,
        SaleDate = SaleDate,
        Comment = Comment,
        Id = Id,
        Client = Client?.Clone() as Client,
        Manager = Manager?.Clone() as Manager,
        Estimates = Estimates?.Select(e => e?.Clone() as Estimate).ToList()
    };

}