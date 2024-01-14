using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExistMethod_WithValidTriangle_ShouldReturnTrue()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);

            // Act
            bool result = triangle.Exist();

            // Assert
            Assert.IsTrue(result, "Valid triangle should exist.");
        }

        [TestMethod]
        public void TestExistMethod_WithInvalidTriangle_ShouldReturnFalse()
        {
            // Arrange
            Triangle triangle = new Triangle(1, 1, 3);

            // Act
            bool result = triangle.Exist();

            // Assert
            Assert.IsFalse(result, "Invalid triangle should not exist.");
        }
        [TestMethod]
        public void TestConstructor_WithoutParameters_ShouldInitializeDefaultValues()
        {
            // Arrange
            Triangle triangle = new Triangle();

            // Act and Assert
            Assert.AreEqual(0, triangle.A, "SideA should be initialized to 0.");
            Assert.AreEqual(0, triangle.B, "SideB should be initialized to 0.");
            Assert.AreEqual(0, triangle.C, "SideC should be initialized to 0.");
        }
        [TestMethod]
        public void TestCopyConstructor_ShouldCreateCopyWithSameValues()
        {
            // Arrange
            Triangle originalTriangle = new Triangle(3, 4, 5);

            // Act
            Triangle copiedTriangle = new Triangle(originalTriangle);

            // Assert
            Assert.AreEqual(originalTriangle.A, copiedTriangle.A, "SideA should be copied.");
            Assert.AreEqual(originalTriangle.B, copiedTriangle.B, "SideB should be copied.");
            Assert.AreEqual(originalTriangle.C, copiedTriangle.C, "SideC should be copied.");
        }
        [TestMethod]
        public void TestStaticExistMethod_WithValidTriangle_ShouldReturnTrue()
        {
            // Arrange
            double a = 3;
            double b = 4;
            double c = 5;

            // Act
            bool result = Triangle.Exist(a, b, c);

            // Assert
            Assert.IsTrue(result, "Valid triangle should exist.");
        }

        [TestMethod]
        public void TestStaticExistMethod_WithInvalidTriangle_ShouldReturnFalse()
        {
            // Arrange
            double a = 1;
            double b = 1;
            double c = 3;

            // Act
            bool result = Triangle.Exist(a, b, c);

            // Assert
            Assert.IsFalse(result, "Invalid triangle should not exist.");
        }
        [TestMethod]
        public void TestShowExistMethod_WithValidTriangle_ShouldPrintCanExistAndReturnTrue()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                // Act
                bool result = triangle.ShowExist();

                // Assert
                Assert.IsTrue(result, "Valid triangle should exist.");
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Может существовать", "Console output should contain 'Может существовать'.");
            }
        }

        [TestMethod]
        public void TestShowExistMethod_WithInvalidTriangle_ShouldPrintCannotExistAndReturnFalse()
        {
            // Arrange
            Triangle triangle = new Triangle(1, 1, 3);
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                // Act
                bool result = triangle.ShowExist();

                // Assert
                Assert.IsFalse(result, "Invalid triangle should not exist.");
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Не может существовать", "Console output should contain 'Не может существовать'.");
            }
        }
        [TestMethod]
        public void TestPrintMethod_ShouldPrintCorrectTriangleInfo()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                // Act
                triangle.Print();

                // Assert
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Стороны треугольника:\nA = 3\tB = 4\tC = 5", "Console output should contain correct triangle info.");
            }
        }
        [TestMethod]
        public void TestCreateTriangleFromUserInput_WithValidInput_ShouldReturnTriangleObject()
        {
            // Arrange
            string input = "3\n4\n5\n"; // ввод пользователя для создания треугольника
            using (StringReader stringReader = new StringReader(input))
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                Console.SetIn(stringReader);

                // Act
                Triangle result = Triangle.CreateTriangleFromUserInput();

                // Assert
                Assert.IsNotNull(result, "Should return a Triangle object.");
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Введите стороны треугольника:");
                StringAssert.Contains(output, "сторона A:");
                StringAssert.Contains(output, "сторона B:");
                StringAssert.Contains(output, "сторона C:");
            }
        }
        [TestMethod]
        public void TestFindS_WithValidTriangle_ShouldReturnCorrectArea()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);

            // Act
            double result = triangle.FindS();

            // Assert
            Assert.AreEqual(6, result, 0.001, "Area should be calculated correctly for a valid triangle.");
        }

        [TestMethod]
        public void TestFindS_WithInvalidTriangle_ShouldPrintErrorMessageAndReturnZero()
        {
            // Arrange
            Triangle triangle = new Triangle(1, 1, 3);
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                // Act
                double result = triangle.FindS();

                // Assert
                Assert.AreEqual(0, result, 0.001, "Area should be zero for an invalid triangle.");
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Треугольник не может существовать");
            }
        }
        [TestMethod]
        public void TestIncrementOperator_ShouldCalculateAreaAndPrint()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                // Act
                triangle++;

                // Assert
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Стороны треугольника:");
                StringAssert.Contains(output, "Площадь треугольника со сторонами A:3  B:4  C:5 =");
            }
        }
        [TestMethod]
        public void TestImplicitConversionToDouble_ShouldReturnPerimeter()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);

            // Act
            double result = triangle;

            // Assert
            Assert.AreEqual(12, result, 0.001, "Perimeter should be calculated correctly.");
        }

        [TestMethod]
        public void TestExplicitConversionToBool_ShouldReturnExistence()
        {
            // Arrange
            Triangle validTriangle = new Triangle(3, 4, 5);
            Triangle invalidTriangle = new Triangle(1, 1, 3);

            // Act
            bool validResult = (bool)validTriangle;
            bool invalidResult = (bool)invalidTriangle;

            // Assert
            Assert.IsTrue(validResult, "Valid triangle should exist.");
            Assert.IsFalse(invalidResult, "Invalid triangle should not exist.");
        }

        [TestMethod]
        public void TestTrianglesProperty_ShouldSetAndGetValues()
        {
            // Arrange
            TriangleArray container = new TriangleArray();
            Triangle[] expectedTriangles = new Triangle[] { new Triangle(3, 4, 5), new Triangle(4, 5, 6) };

            // Act
            container.Triangles = expectedTriangles;
            Triangle[] actualTriangles = container.Triangles;

            // Assert
            CollectionAssert.AreEqual(expectedTriangles, actualTriangles, "Triangles should be set and retrieved correctly.");
        }
        [TestMethod]
        public void TestParameterizedConstructor_ShouldCreateArrayWithRandomTriangles()
        {
            // Arrange
            int size = 5;

            // Act
            TriangleArray array = new TriangleArray(size);

            // Assert
            Assert.AreEqual(size, array.Triangles.Length, $"Array should have {size} triangles.");

            foreach (var triangle in array.Triangles)
            {
                Assert.IsNotNull(triangle, "Each element in the array should be a valid triangle.");
            }
        }
        [TestMethod]
        public void TestFindTriangleWithMinArea_ShouldReturnTriangleWithMinArea()
        {
            // Arrange
            TriangleArray array = new TriangleArray(3);

            // Act
            Triangle minAreaTriangle = array.FindTriangleWithMinArea();

            // Assert
            Assert.IsNotNull(minAreaTriangle, "Min area triangle should not be null.");
            double minArea = minAreaTriangle.FindS();
            foreach (var triangle in array.Triangles)
            {
                double area = triangle.FindS();
                Assert.IsTrue(area >= minArea, "Area of min area triangle should be less than or equal to the areas of other triangles.");
            }
        }

        [TestMethod]
        public void TestPrint_ShouldPrintTriangleArrayElements()
        {
            // Arrange
            TriangleArray array = new TriangleArray(2);

            // Act
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                array.Print();

                // Assert
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Элементы массива:");
            }
        }

        [TestMethod]
        public void TestIndexer_ShouldGetAndSetTriangleAtIndex()
        {
            // Arrange
            TriangleArray array = new TriangleArray(3);
            Triangle newTriangle = new Triangle(6, 8, 10);

            // Act
            array[1] = newTriangle;
            Triangle retrievedTriangle = array[1];

            // Assert
            Assert.AreEqual(newTriangle, retrievedTriangle, "Retrieved triangle should be the same as the one set.");
        }

        [TestMethod]
        public void TestIndexer_OutOfBounds_ShouldPrintErrorMessageAndReturnNull()
        {
            // Arrange
            TriangleArray array = new TriangleArray(3);

            // Act
            using (ConsoleCapture consoleCapture = new ConsoleCapture())
            {
                Triangle result = array[-1];

                // Assert
                Assert.IsNull(result, "Result should be null for out-of-bounds index.");
                string output = consoleCapture.GetOutput();
                StringAssert.Contains(output, "Ошибка: выход за границы массива!");
            }
        }

        [TestMethod]
        public void TestConstructorWithUserInput_ShouldCreateArrayWithValidTriangles()
        {
            // Подготавливаем ввод с клавиатуры для теста
            string input = "3\n4\n5\n";
            input += "6\n8\n10\n";

            using (StringReader stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);

                // Выполняем конструктор и проверяем результат
                TriangleArray triangleArray = new TriangleArray(2, true);

                // Проверяем, что в массиве созданы три треугольника
                Assert.AreEqual(2, triangleArray.Triangles.Length);

                // Проверяем, что треугольники созданы с корректными сторонами
                Assert.AreEqual(3, triangleArray[0].A);
                Assert.AreEqual(4, triangleArray[0].B);
                Assert.AreEqual(5, triangleArray[0].C);

                Assert.AreEqual(6, triangleArray[1].A);
                Assert.AreEqual(8, triangleArray[1].B);
                Assert.AreEqual(10, triangleArray[1].C);

                // Проверяем, что массив содержит null вместо треугольника с некорректным вводом
                Assert.IsNull(triangleArray[2]);
            }
        }
    }
}
