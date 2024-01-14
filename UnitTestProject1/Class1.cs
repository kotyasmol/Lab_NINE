using System.IO;
using System;

// Этот класс предназначен для захвата вывода, записанного в консоль в целях тестирования.
public class ConsoleCapture : IDisposable
{
    // StringWriter используется для захвата текста, записанного в поток.
    private StringWriter stringWriter;

    // originalOutput хранит оригинальный вывод консоли перед его перенаправлением.
    private TextWriter originalOutput;

    // Конструктор инициализирует объект ConsoleCapture.
    public ConsoleCapture()
    {
        // Создаем новый StringWriter для захвата вывода консоли.
        stringWriter = new StringWriter();

        // Сохраняем оригинальный вывод консоли.
        originalOutput = Console.Out;

        // Перенаправляем вывод консоли в StringWriter.
        Console.SetOut(stringWriter);
    }

    // Метод GetOutput возвращает захваченный вывод консоли в виде строки.
    public string GetOutput()
    {
        // Восстанавливаем оригинальный вывод консоли.
        Console.SetOut(originalOutput);

        // Возвращаем захваченный вывод в виде строки.
        return stringWriter.ToString();
    }

    // Метод Dispose вызывается, когда объект ConsoleCapture больше не нужен.
    public void Dispose()
    {
        // Восстанавливаем оригинальный вывод консоли.
        Console.SetOut(originalOutput);

        // Высвобождаем ресурсы StringWriter.
        stringWriter.Dispose();
    }
}