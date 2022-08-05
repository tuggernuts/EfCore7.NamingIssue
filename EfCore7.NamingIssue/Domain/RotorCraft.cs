namespace EfCore7.NamingIssue.Domain;

public class RotorCraft : Aircraft
{
    public double RotorLength { get; set; }
    public int RotorCount { get; set; }
    public bool IsTurbine { get; set; }
}