namespace Trestlebridge.Interfaces
{
    public interface IDualProducing
    {
        double Harvest ();
        double Farmer ();
        string Type { get; }
    }
}