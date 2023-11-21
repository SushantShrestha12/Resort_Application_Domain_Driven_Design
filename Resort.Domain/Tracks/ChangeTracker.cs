using Resort.Domain.SharedKernel;

namespace Resort.Domain.Tracks;

public sealed class ChangeTracker : AggregateRoot<Guid>
{
    private ChangeTracker()
    {
        
    }
    public string Action { get; private set; } 
    public ChangeTracker(string action)
    {
        Action = action;
    }
}