namespace EfCore7.NamingIssue.Domain;

public class AirplaneMulti : Aircraft
{
    public double WingSpan { get; set; }
    public int WingCount { get; set; }
    public int Vmc { get; set; }
    public int Vyse { get; set; }
}