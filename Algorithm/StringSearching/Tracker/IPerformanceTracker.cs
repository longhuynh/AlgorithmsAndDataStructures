namespace Tracker
{
    public interface IPerformanceTracker
    {
        long Comparisons { get; }

        long Swaps { get; }

        void Reset();
    }
}