namespace QnSCommunityCount.Contracts.Modules.App
{
    public interface IBalance : ICopyable<IBalance>
    {
        string From { get; }
        string To { get; }
        double Amount { get; }
    }
}
