using System.IO;
using System;

public class ConsoleCapture : IDisposable
{
    private StringWriter stringWriter;
    private TextWriter originalOutput;

    public ConsoleCapture()
    {
        stringWriter = new StringWriter();
        originalOutput = Console.Out;
        Console.SetOut(stringWriter);
    }

    public string GetOutput()
    {
        Console.SetOut(originalOutput);
        return stringWriter.ToString();
    }

    public void Dispose()
    {
        Console.SetOut(originalOutput);
        stringWriter.Dispose();
    }
}