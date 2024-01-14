using System;

namespace UnitTestProject1
{
    internal class Triangle
    {
        private double a = 0.0;
        private double b = 0.0;
        private double c = 0.0;
        private static int count = 0; // статический счётчик созданных объектов класса (тип триангл)
                                      //private bool isExist = false;

        public static int Count // статическая компонента класса для подсчета созданных в программе объектов
        {
            get { return count; }
            private set { count = value; }
        }

        public double A
        {
            get => a;
            set => a = value;
        }
        public double B
        {
            get => b;
            set => b = value;
        }
        public double C
        {
            get => c;
            set => c = value;
        }

        /// конструкторы
        public Triangle() // конструктор без параметров
        {
            A = 0;
            B = 0;
            C = 0;
            Triangle.Count++;
        }
        public Triangle(Triangle triangle) // конструктор копирования
        {
            this.A = (double)triangle.A; // указатель на объект класса в котором я сейчас нахожусь + явное приведение типов (значение а не ссылка)
            this.B = (double)triangle.B;
            this.C = (double)triangle.C;
            Triangle.Count++;
        }
        public Triangle(double a, double b, double c) // конструктор с параметрами
        {
            A = a;
            B = b;
            C = c;
            Triangle.Count++;
        }

        public static bool Exist(double a, double b, double c) // Статическая функция существование
        {
            if (a + b > c &
                b + c > a &
                c + a > b)
                return true;
            else { return false; }
        }
        public bool Exist() // метод класса return true если существует
        {
            if (a + b > c && b + c > a && c + a > b
                && a > 0 && b > 0 && c > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ShowExist() // вывод результата exist
        {
            if (Exist()) { Console.WriteLine("Может существовать"); return true; }
            else { Console.WriteLine("Не может существовать"); return false; }
        }
        public void Print() // вывод информации из треугольника
        {
            Console.WriteLine($"Стороны треугольника:\nA = {A}\tB = {B}\tC = {C}");
        }
        public static Triangle CreateTriangleFromUserInput()
        {
            double sideA, sideB, sideC;

            while (true) // Бесконечный цикл, который будет прерываться только при корректном вводе
            {
                Console.WriteLine("Введите стороны треугольника:");
                Console.Write("сторона A: ");
                if (!double.TryParse(Console.ReadLine(), out sideA) || sideA <= 0)
                {
                    Console.WriteLine("Некорректный ввод для стороны A. Сторона должна быть положительным числом.");
                    continue; // Запросить ввод снова
                }

                Console.Write("сторона B: ");
                if (!double.TryParse(Console.ReadLine(), out sideB) || sideB <= 0)
                {
                    Console.WriteLine("Некорректный ввод для стороны B. Сторона должна быть положительным числом.");
                    continue; // Запросить ввод снова
                }

                Console.Write("сторона C: ");
                if (!double.TryParse(Console.ReadLine(), out sideC) || sideC <= 0)
                {
                    Console.WriteLine("Некорректный ввод для стороны C. Сторона должна быть положительным числом.");
                    continue; // Запросить ввод снова
                }

                if (!(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA))
                {
                    Console.WriteLine("Треугольник с такими сторонами не может существовать. Попробуйте снова.");
                    continue; // Запросить ввод снова
                }

                try
                {
                    // Создание объекта Triangle с помощью конструктора, принимающего три стороны
                    return new Triangle(sideA, sideB, sideC);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    continue; // Запросить ввод снова
                }
            }
        }
        public double FindS() // поиск площади треугольника
        {
            if (Exist())
            {
                double polPer = (A + B + C) / 2;
                double area = Math.Sqrt(polPer * (polPer - A) * (polPer - B) * (polPer - C));
                return area;
            }
            else { Console.WriteLine("Треугольник не может существовать"); return 0; }
        }

        // перегрузки

        public static Triangle operator ++(Triangle triangle) // S = √p · (p — a)(p — b)(p — c), где p – половина периметра треугольника.
        {
            double polPer = (triangle.A + triangle.B + triangle.C) / 2;
            triangle.Print();
            triangle.FindS();
            Console.WriteLine($"Площадь треугольника со сторонами A:{triangle.A}  B:{triangle.B}  C:{triangle.C} = " + triangle.FindS());
            return triangle;
        }
        public static implicit operator double(Triangle triangle) // определение неявного оператора преобразования для типа Triangle (периметр)
        {
            if (triangle.Exist())
            {
                double perimetr = triangle.A + triangle.B + triangle.C;
                //equation.Print(); // изменено
                //Console.WriteLine($"Периметр треугольника со сторонами ({triangle.A}|{triangle.B}|{triangle.C}) = {perimetr}");
                return perimetr;
            }
            return 0;
        }
        public static explicit operator bool(Triangle triangle) // явное преобразование булево с выводом возможности существования
        {
            //Console.WriteLine($"Треугольник со сторонами ({triangle.A}|{triangle.B}|{triangle.C}) = " + triangle.ShowExist());
            return triangle.Exist();
        }
        public static bool operator >(Triangle eq1, Triangle eq2) // true если 1>2
        {
            if (eq1.Exist() && eq2.Exist())
            {
                double eq1s = eq1.FindS();
                Console.WriteLine($"Площадь первого: ({eq1.A}|{eq1.B}|{eq1.C}) = " + eq1.FindS());
                double eq2s = eq2.FindS();
                Console.WriteLine($"Площадь второго: ({eq2.A}|{eq2.B}|{eq2.C}) = " + eq2.FindS());
                return eq1s > eq2s;
            }
            return false;
        }
        public static bool operator <(Triangle eq1, Triangle eq2) // true если 1<2
        {
            if (eq1.Exist() && eq2.Exist())
            {
                double eq1s = eq1.FindS();
                double eq2s = eq2.FindS();
                return eq1s < eq2s;
            }
            return false;
        }
    }
}