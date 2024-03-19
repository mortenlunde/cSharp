// ReSharper disable InconsistentNaming
namespace JsonSaver;

public class Computer
{
    public string? cpu;
    public string? gpu;
    public string? ram;
    public Drive? drives;
}

public class Drive
{
    public string? name;
    public string? type;
    public int capacityGB;
}