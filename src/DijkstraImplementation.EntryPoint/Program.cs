using System;
using System.Collections.Generic;
using System.Linq;
using DijkstraImplementation.Core;
using DijkstraImplementation.Core.Interfaces;
using DijkstraImplementation.Core.Utils;

namespace DijkstraImplementation.EntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {

            // Создаем граф для Варианта 18 из файла.
            int[,] graph = new[,]
            {
                        /*1*/  /*2*/   /*3*/   /*4*/   /*5*/   /*6*/   /*7*/   /*8*/
              /*1*/   {   0,     2,      3,      8,      0,      0,      0,      0   }, 
              /*2*/   {   2,     0,      0,      2,      0,      1,      0,      0   }, 
              /*3*/   {   3,     0,      0,      5,      0,      6,      0,      3   }, 
              /*4*/   {   8,     2,      5,      0,      3,      5,      0,      0   }, 
              /*5*/   {   0,     0,      0,      3,      0,      6,      0,      7   }, 
              /*6*/   {   0,     1,      6,      5,      6,      0,      12,     8   }, 
              /*7*/   {   0,     0,      0,      0,      0,      12,     0,      5   }, 
              /*8*/   {   0,     0,      3,      0,      7,      8,      5,      0   }, 
            };

            // Создаем алгоритм, который реализует интерфейс IDijkstraAlgorithm.
            IDijkstraAlgorithm dijkstraAlgorithmImpl = new DijkstraAlgorithmImpl();

            // Создаем визуализатор для вывода работы алгоритма в консоль.
            DijkstraAlgorithmVisualizator dijkstraAlgorithmVisualizator = new DijkstraAlgorithmVisualizator(
                dijkstraAlgorithm: dijkstraAlgorithmImpl,
                textColor: ConsoleColor.Green,
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
