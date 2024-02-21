namespace Feminancials.Domain.Constants;

public abstract class Policies
{
    public const string CanPurge = nameof(CanPurge);
    public const string CanAccessCollective = nameof(CanAccessCollective);
    public const string CanAccessTransaction = nameof(CanAccessTransaction);
    public const string CanAccessExpense = nameof(CanAccessExpense);
}
