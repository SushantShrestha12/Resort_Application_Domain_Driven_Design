namespace Resort.Domain;

public record Features 
{
    private Features()
    {
        
    }
   
    public Features(bool ac, bool bed, bool wifi, bool tv)
    {
        Ac = ac;
        Bed = bed;
        Wifi = wifi;
        Tv = tv;
    }
    public bool Ac { get; private set; }
    public bool Bed { get; private set; }
    public bool Wifi { get; private set; }
    public bool Tv { get; private set; }
}