using System.Text;
using Dumpify;

const string title = "Encoding\n";
title.Dump(typeRenderingConfig: new TypeRenderingConfig {QuoteStringValues = false});
for (int i = 1; i <= 512; i *= 2)
{
    Console.WriteLine($"{i}-Bit number has\n minimum of 0\n maximum number of {Math.Pow(2, (i)) - 1}");
}

const string message = "Hello";
byte[] bytes = Encoding.UTF8.GetBytes(message);
Console.WriteLine();
Console.WriteLine(message);
foreach (byte b in bytes)
{
    Console.Write(b + " ");
}
Console.WriteLine();
foreach (byte b in bytes)
{
    Console.Write(Convert.ToString(b, 2) + " ");
}
Console.WriteLine();
foreach (byte b in bytes)
{
    Console.Write(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
}
Console.WriteLine();
foreach (byte b in bytes)
{
    Console.Write(Convert.ToString(b, 16).PadLeft(2, '0').ToUpper() + " ");
}
Console.WriteLine();
Console.Write(Convert.ToBase64String(bytes) + " ");