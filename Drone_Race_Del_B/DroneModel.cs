public class DroneModel
{
    public string Name;
    public int MaxCheckpoints;
    public int DelayMs;
    public bool ForceError;

    public DroneModel(string name, int maxCheckponts, int delayMs, bool forceError = false)
    {
        Name = name;
        MaxCheckpoints = maxCheckponts;
        DelayMs = delayMs;
        ForceError = forceError;
    }
}