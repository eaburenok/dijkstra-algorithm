using DijkstraImplementation.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraImplementation.Core.Utils
{
    /*
    
    Визуализируем работу алгоритма Дейкстры для нахождения кратчайшего пути.

    */
    public class DijkstraAlgorithmVisualizator
    {
        public ConsoleColor TextColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        public IDijkstraAlgorithm DijkstraAlgorithm { get; set; }
        public DijkstraAlgorithmVisualizator(IDijkstraAlgorithm dijkstraAlgorithm,
            ConsoleColor textColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            DijkstraAlgorithm = dijkstraAlgorithm ?? throw new ArgumentNullException("Необходима реализация алгоритма Дейкстры.");
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }

        /*
         
        Выводим кратчайший путь (последовательность) в консоль.
        
        */
        public void PrintPath(int[,] graph,
            int sourceNode,
            int destinationNode)
        {
            Console.ForegroundColor = TextColor;
            Console.BackgroundColor = BackgroundColor;

            Console.Write($"Поиск наименьшего пути.... Поиск выполнен... Кратчайший путь: [{sourceNode + 1} -> {destinationNode + 1}]: ");

            List<int> path = DijkstraAlgorithm.Process(graph, sourceNode, destinationNode);

            if (path == null)
            {
                Console.WriteLine("Путь не найден.");
            }
            else
            {
                int pathLength = 0;

                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }

                path = path.Select(p => p + 1).ToList();

                string formattedPath = string.Join("->", path);
                Console.WriteLine($"{formattedPath} (длина {pathLength})");
            }

            Console.ResetColor();
        }
    }
}
