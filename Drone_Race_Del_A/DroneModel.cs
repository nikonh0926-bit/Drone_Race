public class DroneModel
{
    public string Name;
    public int MaxCheckpoints;
    public int DelayMs;
    public DroneModel(string name, int maxCheckponts, int delayMs)
    {
        Name = name;
        MaxCheckpoints = maxCheckponts;
        DelayMs = delayMs;
    }
}