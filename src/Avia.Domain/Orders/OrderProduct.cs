
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Avia.Products;
using System.ComponentModel.DataAnnotations;

namespace Avia.Orders;

public class OrderProduct : AuditedAggregateRoot<Guid>
{
    public DateTime Date { get; set; } = DateTime.Now;
    public string Note { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public int Change{ get; set; } 
    public int Money{ get; set; } 
    public virtual ICollection<OrderProduct>? Products { get; protected set; }

}
