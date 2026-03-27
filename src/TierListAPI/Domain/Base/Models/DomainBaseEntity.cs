namespace BackTierList.TierListAPI.Domain.Models;

using System;
using System.Linq.Expressions;

public abstract class DomainBaseEntity<T>
{
    public T Id { get; set; }
    public DateTimeOffset? Created { get; set; }
    public DateTimeOffset? Deleted { get; set; }
    public DateTimeOffset? Updated { get; set; }
} 