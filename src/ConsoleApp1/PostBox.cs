using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class PostBox
    {
        public List<Newspaper> newspapers = new List<Newspaper>();

        // Добавление записей
        public void AddBook(Newspaper news)
        {
            newspapers.Add(news);
        }

        // Сортировка
        public void SortNews()
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < newspapers.Count - 1; i++)
                {

                    if (CompareBooks(newspapers[i], newspapers[i + 1]) > 0)
                    {
                        Swap(i, i + 1);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        // Сравнение элементов
        private int CompareBooks(Newspaper first, Newspaper second)
        {
            int genreComparison;
            if (first.ChisloStranic < second.ChisloStranic)
            { genreComparison = -1; }
            else
            {
                if (first.ChisloStranic == second.ChisloStranic) genreComparison = 0;
                else genreComparison = 1;
            }


            if (genreComparison != 0)
                return genreComparison;

            return string.Compare(first.Nazvanie, second.Nazvanie, StringComparison.OrdinalIgnoreCase);

        }

        private void Swap(int indexA, int indexB)
        {
            var temp = newspapers[indexA];
            newspapers[indexA] = newspapers[indexB];
            newspapers[indexB] = temp;
        }

        // Сохранение в файл
        public void SaveToFile(string filePath)
        {
            using StreamWriter writer = File.CreateText(filePath);
            foreach (var news in newspapers)
            {
                writer.WriteLine($"{news.Nazvanie},{news.Vladelec},{news.ChisloStranic}");
            }
        }
    }

}
