using DijkstraImplementation.Core;
using DijkstraImplementation.Core.Interfaces;
using DijkstraImplementation.Core.Utils;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace DijkstraImplementation.EntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] graph = new int[8, 8];


            using (FileStream fstream = new FileStream(@"C:\Users\User\Source\Repos\dijkstra-algorithm2\src\TextFile.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader dataStream = new StreamReader(fstream))
                {

                    string Content = dataStream.ReadToEnd();

                    string[] SplitAtLines = Content.Split("\n");

                    for (int i = 0; i < SplitAtLines.Length; i++)
                    {
                        var Trimed = SplitAtLines[i].Replace(" ", string.Empty).Replace("\r\n", string.Empty);
                        int[] Splitted = Trimed.Split(',').Select(n => int.Parse(n)).ToArray();

                        for (int j = 0; j < Splitted.Length; j++)
                        {
                            graph[i, j] = Splitted[j];
                        }

                    }

                }


            }
            int a = Console.WindowWidth;
            Console.SetCursorPosition(a / 2,200);
            Console.WriteLine("Загрузка файла с массивом данных");
            Thread.Sleep(5000);
            Console.WriteLine("....");
            Thread.Sleep(2000);
            Console.WriteLine("Загрузка выполнена");
          


            // Создаем алгоритм, который реализует интерфейс IDijkstraAlgorithm.
            IDijkstraAlgorithm dijkstraAlgorithmImpl = new DijkstraAlgorithmImpl();

            // Создаем визуализатор для вывода работы алгоритма в консоль.
            DijkstraAlgorithmVisualizator dijkstraAlgorithmVisualizator = new DijkstraAlgorithmVisualizator(
                dijkstraAlgorithm: dijkstraAlgorithmImpl,
                textColor: ConsoleColor.Red,
                backgroundColor: ConsoleColor.Black);

            // Найдем кратчайшие пути до каждой вершины графа.
            for (int destinationNode = 0; destinationNode < 8; destinationNode++)
            {
                dijkstraAlgorithmVisualizator.PrintPath(graph: graph,
                    sourceNode: 0,
                    destinationNode: destinationNode);
            }

        }
    }
}
