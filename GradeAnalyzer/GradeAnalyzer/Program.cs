using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Анализ успеваемости группы";

            Console.WriteLine("=== Анализ успеваемости группы студентов ===\n");

            // 1. Ввод оценок
            List<int> grades = InputGrades();

            if (grades.Count == 0)
            {
                Console.WriteLine("❌ Оценки не введены. Завершение программы.");
                return;
            }

            // 2. Расчёт и вывод статистики
            Console.WriteLine("\n=== Результаты анализа ===\n");

            double average = CalculateAverage(grades);
            Console.WriteLine($"📊 Средний балл: {average:F2}");

            double learningLevel = CalculateLearningLevel(grades);
            Console.WriteLine($"📚 Уровень обученности (>2): {learningLevel:F1}%");

            double successLevel = CalculateSuccessLevel(grades);
            Console.WriteLine($"✅ Уровень успешности (>3): {successLevel:F1}%");

            // 3. Дополнительная информация
            Console.WriteLine($"\n📝 Всего оценок: {grades.Count}");
            Console.WriteLine($"📈 Диапазон оценок: {grades.Min()} - {grades.Max()}");

            Console.WriteLine("\n=== Анализ завершён ===");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Ввод оценок студентов с клавиатуры
        /// </summary>
        static List<int> InputGrades()
        {
            List<int> grades = new List<int>();

            Console.WriteLine("Введите оценки студентов (2-5).");
            Console.WriteLine("Для завершения ввода введите 0 или нажмите Enter без ввода.\n");

            int count = 1;
            while (true)
            {
                Console.Write($"Оценка студента #{count}: ");
                string input = Console.ReadLine();

                // Завершение ввода
                if (string.IsNullOrWhiteSpace(input) || input == "0")
                    break;

                if (int.TryParse(input, out int grade))
                {
                    if (grade >= 2 && grade <= 5)
                    {
                        grades.Add(grade);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Оценка должна быть от 2 до 5!");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ Неверный формат! Введите число.");
                }
            }

            return grades;
        }

        /// <summary>
        /// Расчёт среднего балла (арифметическое среднее)
        /// </summary>
        static double CalculateAverage(List<int> grades)
        {
            if (grades.Count == 0) return 0;
            return grades.Average();
        }

        /// <summary>
        /// Расчёт уровня обученности (процент оценок выше 2)
        /// </summary>
        static double CalculateLearningLevel(List<int> grades)
        {
            if (grades.Count == 0) return 0;
            int countAbove2 = grades.Count(g => g > 2);
            return (double)countAbove2 / grades.Count * 100;
        }

        /// <summary>
        /// Расчёт уровня успешности (процент оценок выше 3)
        /// </summary>
        static double CalculateSuccessLevel(List<int> grades)
        {
            if (grades.Count == 0) return 0;
            int countAbove3 = grades.Count(g => g >= 3);
            return (double)countAbove3 / grades.Count * 100;
        }
    }
}

