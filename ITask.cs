namespace Tweak
{
    public interface ITask
    {
        ulong Weight { get; }
        
        void Apply();
    }
}