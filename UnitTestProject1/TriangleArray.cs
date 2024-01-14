using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    internal class TriangleArray
    {
        private Triangle[] triangles;
        private static int count;
        public static int Count { get; private set; }
        public Triangle[] Triangles
        {
            get { return triangles; }
            set { triangles = value; }
        }


        public TriangleArray() // конструктор без параметров
        {
            triangles = new Triangle[0];
            Count++;
        }
        public TriangleArray(TriangleArray array) // конструктор копирования
        {
            triangles = new Triangle[array.triangles.Length];
            for (int i = 0; i < array.triangles.Length; i++)
            {
                triangles[i] = new Triangle(array.triangles[i]);
            }
            Count++;
        }
        public TriangleArray(int size) // конструктор с параметрами, заполняющий элементы случайными значениями
        {
            triangles = new Triangle[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                double sideA, sideB, sideC;

                do
                {
                    sideA = 1 + random.NextDouble() * 10;
                    sideB = 1 + random.NextDouble() * 10;
                    sideC = 1 + random.NextDouble() * 10;
                } while (!Triangle.Exist(sideA, sideB, sideC));

                triangles[i] = new Triangle(sideA, sideB, sideC);
            }
            Count++;
        }

        public TriangleArray(int size, bool userInput)
        {
            List<Triangle> triangleList = new List<Triangle>();

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Введите стороны треугольника {i + 1}:");
                double sideA, sideB, sideC;
                bool validInput = false;

                while (!validInput)
                {
                    string inputA = Console.ReadLine();
                    string inputB = Console.ReadLine();
                    string inputC = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputA) || string.IsNullOrEmpty(inputB) || string.IsNullOrEmpty(inputC))
                    {
                        Console.WriteLine("Введены пустые значения. Повторите ввод.");
                        continue; // Повторяем ввод для этого треугольника
                    }

                    if (double.TryParse(inputA, out sideA) && double.TryParse(inputB, out sideB) && double.TryParse(inputC, out sideC))
                    {
                        if (Triangle.Exist(sideA, sideB, sideC))
                        {
                            triangleList.Add(new Triangle(sideA, sideB, sideC));
                            validInput = true; // Успешный ввод, завершаем цикл
                        }
                        else
                        {
                            Console.WriteLine("Треугольник с такими сторонами не существует. Повторите ввод.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод для сторон треугольника. Повторите ввод.");
                    }
                }
            }

            // Преобразовываем List<Triangle> в массив
            triangles = triangleList.ToArray();
            Count++;
        }
        public Triangle FindTriangleWithMinArea()
        {
            if (TriangleArray.Count == 0)
            {
                return null; // Если массив пуст, вернем null, так как треугольник не найден
            }

            Triangle minAreaTriangle = triangles[0]; // Предположим, что первый треугольник имеет минимальную площадь

            foreach (Triangle triangle in triangles)
            {
                if (triangle.FindS() < minAreaTriangle.FindS()) // Сравниваем площади треугольников
                {
                    minAreaTriangle = triangle; // Если найден треугольник с меньшей площадью, обновляем минимальный треугольник
                }
            }

            return minAreaTriangle; // Возвращаем треугольник с минимальной площадью
        }
        public void Print() // метод для просмотра элементов массива
        {
            Console.WriteLine("Элементы массива:");
            foreach (var triangle in triangles)
            {
                triangle.Print();
            }
        }


        public Triangle this[int index] // индексатор
        {
            get
            {
                if (index >= 0 && index < triangles.Length)
                    return triangles[index];
                else
                {
                    Console.WriteLine("Ошибка: выход за границы массива!");
                    return null; // Возвращаем null в случае ошибки
                }
            }
            set
            {
                if (index >= 0 && index < triangles.Length)
                    triangles[index] = value;
                else
                    Console.WriteLine("Ошибка: выход за границы массива!");
            }
        }
    }
}
