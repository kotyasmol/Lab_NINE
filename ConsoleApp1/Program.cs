using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("----------ЧАСТЬ 1----------"); 
                Console.WriteLine("Создание конструктором без параметров:");
                Triangle tr1 = new Triangle();
                tr1.Print();
                bool result = Triangle.Exist(tr1.A, tr1.B, tr1.C); // использование статической функции
                Console.WriteLine(result);
                Console.WriteLine("Создание конструктором с параметрами:");
                Triangle tr2 = new Triangle(2.3, 3.84, 2.71);
                tr2.Print();
                tr2.ShowExist(); // использование метода класса
                Console.WriteLine("Создание конструктором копирования");
                Triangle tr3 = new Triangle(tr2);
                tr3.Print();
                tr3.ShowExist(); // тоже метод класса
                Console.WriteLine("\nКоличество созданных объектов: " + Triangle.Count);



                Console.WriteLine("---------- ЧАСТЬ 2 ----------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Унарные операции");
                Console.ResetColor();
                Console.WriteLine("< Вычислить площадь треугольника >\nПервый треугольник");
                // здесь создаётся первый пользовательский треугольник
                Triangle userTriangleOne = Triangle.CreateTriangleFromUserInput();
                userTriangleOne++; // площадь
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Операции приведения типа:");
                Console.ResetColor();
                Console.WriteLine("1. double (неявная) "); double perimetr = userTriangleOne; Console.WriteLine("Периметр = " + perimetr);
                Console.WriteLine("2. bool (явная) *TRUE - если существует"); bool exists = (bool)userTriangleOne; Console.WriteLine(exists);


                Console.WriteLine("Второй треугольник");
                Triangle userTriangleTwo = Triangle.CreateTriangleFromUserInput();
                userTriangleTwo++; // площадь
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Операции приведения типа:");
                Console.ResetColor();
                Console.WriteLine("1. double (неявная) "); perimetr = userTriangleTwo; Console.WriteLine("Периметр = " + perimetr);
                Console.WriteLine("2. bool (явная) *TRUE - если существует"); exists = (bool)userTriangleTwo; Console.WriteLine(exists);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Бинарные операции:");
                Console.ResetColor();
                Console.WriteLine("< / > - сравниваются площади треугольников.");
                if (userTriangleOne > userTriangleTwo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("S1 > S2");
                    Console.ResetColor();
                }
                else if (userTriangleOne < userTriangleTwo)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("S1 < S2");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Треугольники равны");
                    Console.ResetColor();
                }



                Console.WriteLine("---------- ЧАСТЬ 3 ----------");

                Console.WriteLine("С параметрами (случайными числами):");
                TriangleArray triangleArray = new TriangleArray(2);
                for (int i = 0; i < triangleArray.Triangles.Length; i++)
                {
                    Triangle triangle = triangleArray[i];
                    if (triangle != null)
                    {
                        Console.WriteLine($"Стороны треугольника {i + 1}: {triangle.A}, {triangle.B}, {triangle.C}");
                        double area = triangle.FindS();
                        Console.WriteLine($"Площадь треугольника {i + 1}: {area}");
                    }
                }
                Console.WriteLine("С параметрами (ввод с клавиатуры):");
                TriangleArray triangleArrayUserInput = new TriangleArray(2, true);
                for (int i = 0; i < triangleArrayUserInput.Triangles.Length; i++)
                {
                    Triangle triangle = triangleArrayUserInput[i];
                    if (triangle != null)
                    {
                        Console.WriteLine($"Стороны треугольника {i + 1}: {triangle.A}, {triangle.B}, {triangle.C}");
                        double area = triangle.FindS();
                        Console.WriteLine($"Площадь треугольника {i + 1}: {area}");
                    }
                }
                Console.WriteLine("\n\tПоиск треугольника с минимальной площадью:");
                Triangle minAreaTriangle = new Triangle();
                double minArea = double.MaxValue;
                foreach (Triangle triangle in triangleArray.Triangles)
                {
                    if (triangle != null)
                    {
                        double area = triangle.FindS();
                        if (area < minArea)
                        {
                            minArea = area;
                            minAreaTriangle = triangle;
                        }
                    }
                }
                foreach (Triangle triangle in triangleArrayUserInput.Triangles)
                {
                    if (triangle != null)
                    {
                        double area = triangle.FindS();
                        if (area < minArea)
                        {
                            minArea = area;
                            minAreaTriangle = triangle;
                        }
                    }
                }

                if (minAreaTriangle != null)
                {
                    Console.WriteLine("Треугольник с минимальной площадью:");
                    minAreaTriangle.Print();
                    Console.WriteLine("Минимальная площадь: " + minArea);
                }
                else
                {
                    Console.WriteLine("Массив пуст, треугольник не найден.");
                }
                Console.WriteLine("Количество созданных элементов: 4"); 
            }
        }
    }
