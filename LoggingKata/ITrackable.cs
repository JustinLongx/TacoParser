namespace LoggingKata
{
    public interface ITrackable //Interface specify behavior
    {
        string Name { get; set; } //Property name
        Point Location { get; set; } //Location will be of type Point and every pointy will have a Longitude and Latitude
    }
}