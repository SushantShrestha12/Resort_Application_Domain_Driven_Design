using System;
namespace Resort.Domain.SharedKernel
{
	public abstract class BaseEntity<TId>
	{
		protected BaseEntity(TId id)
		{
			Id = id;
		}

		protected BaseEntity()
		{
		}

		public TId Id { get; private set; }
	}
}

