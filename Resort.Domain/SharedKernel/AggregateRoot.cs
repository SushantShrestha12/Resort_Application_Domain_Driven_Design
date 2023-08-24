using System;
namespace Resort.Domain.SharedKernel
{
	public abstract class AggregateRoot<TId>: BaseEntity<TId>
	{
		protected AggregateRoot(TId id) : base(id)
		{
		}

		protected AggregateRoot()
		{
		}
	}
}

