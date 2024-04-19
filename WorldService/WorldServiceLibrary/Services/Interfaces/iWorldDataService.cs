namespace WorldClassLibrary.Services.Interfaces;

public interface IIWorldDataService<out T>
    where T : class
{
    IEnumerable<T> GetData();
}