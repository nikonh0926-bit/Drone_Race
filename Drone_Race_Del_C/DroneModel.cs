public class DroneModel
{
    public string Name;
    public int MaxCheckpoints;
    public int DelayMs;
    public int Location; // 0 = Tønsberg, 1 = Horten, 2 = Oslo, 3 = Bergen, 4 = Sandefjord
    public double multiplier;

    public DroneModel(string name, int maxCheckponts, int delayMs, int location)
    {
        Name = name;
        MaxCheckpoints = maxCheckponts;
        DelayMs = delayMs;
        Location = location;
    }
}