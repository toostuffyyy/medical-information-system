namespace MISEmployeeDesktop.Models;

public class Cabinet
{
    public double X { get; set; }
    public double Y { get; set; } = 0;
    public double Width { get; set; }
    public double Height { get; set; } = 250;
    public string Title { get; set; }
    public int Skud { get; set; }
    public double TextDirection => Skud == 19 || Skud == 21 || Skud == 1 || Skud >= 4 && Skud <= 6 || 
                                   Skud == 15 || Skud == 14 || Skud == 12 || Skud == 8 || Skud == 7
        ? 0
        : 270;
    public string Color => Skud == 19 || Skud == 21 || Skud == 1 || Skud >= 4 && Skud <= 6 || 
                           Skud == 15 || Skud == 14 || Skud == 12 || Skud == 8 || Skud == 7
        ? "#ffdd85"
        : "#fff9c6";
    public double TextWidth => TextDirection == 0 ? Width : Height;

    public string VerticalAlignment => Skud >= 17 && Skud <= 22 || Skud >= 0 && Skud <= 6
        ? "Bottom"
        : "Top";
}