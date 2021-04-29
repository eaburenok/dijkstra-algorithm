using DijkstraImplementation.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraImplementation.Core
{
    /*
    
    Реализация алгоритма Дейкстры для нахождения кратчайшего пути.
     
    */
    public class DijkstraAlgorithmImpl : IDijkstraAlgorithm
    {
        /*
        
        Запускаем процесс нахождения короткого пути от заданной начальной вершины,
        
        до заданной конечной вершины в заданном графе.

        */
        public List<int> Process(int[,] graph, 
            int sourceNode, 
            int destinationNode)
        {
            int numberOfNodes = graph.GetLength(0);

            bool[] visited = new bool[numberOfNodes];
            int?[] previous = new int?[numberOfNodes];

            int[] distances = new int[numberOfNodes];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[sourceNode] = 0;

            while (true)
            {
                int[] nodeParams = GetNearestUnvisitedNode(numberOfNodes: numberOfNodes, 
                    distances: distances, 
                    visited: visited);

                int nearestNode = nodeParams[0];
                int minDist = nodeParams[1];

                if (minDist == int.MaxValue)
                {
                    break;
                }

                visited[nearestNode] = true;

                List<int> adjacentNodes = GetAdjacentNodes(graph: graph, 
                    node: nearestNode);

                foreach (int adjacentNode in adjacentNodes)
                {
                    int currDistance = distances[adjacentNode];
                    int newDistance = distances[nearestNode] + graph[nearestNode, adjacentNode];
                    if (newDistance < currDistance)
                    {
                        distances[adjacentNode] = newDistance;
                        previous[adjacentNode] = nearestNode;
                    }
                }
            }

            List<int> path = ReconstructShortestPath(destinationNode: destinationNode, 
                distances: distances, 
                previous: previous);

            return path;
        }

        /*
        
        Получаем коротки путь в виде динамического массива, размерностью 0-n вершин.
         
        */
        private List<int> ReconstructShortestPath(int destinationNode, 
            int[] distances, 
            int?[] previous)
        {
            List<int> path = new List<int>();

            if (distances[destinationNode] == int.MaxValue)
            {
                return null;
            }

            int? currNode = destinationNode;
            while (currNode != null)
            {
                path.Add(currNode.Value);
                currNode = previous[currNode.Value];
            }

            path.Reverse();
            return path;
        }

        /*
        
        Получаем соседние вершины для конкретной вершины.
         
        */
        private List<int> GetAdjacentNodes(int[,] graph, int node)
        {
            List<int> adjacentNodes = new List<int>();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[node, i] > 0)
                {
                    adjacentNodes.Add(i);
                }
            }

            return adjacentNodes;
        }

        /*
        
        Получаем массив соседних непосещенных вершин.

        */
        private int[] GetNearestUnvisitedNode(int numberOfNodes, 
            int[] distances, 
            bool[] visited)
        {
            int nearestNode = 0;
            int minDist = int.MaxValue;

            for (int currNode = 0; currNode < numberOfNodes; currNode++)
            {
                if (!visited[currNode])
                {
                    int currNodeDist = distances[currNode];
                    if (currNodeDist < minDist)
                    {
                        nearestNode = currNode;
                        minDist = currNodeDist;
                    }
                }
            }


            return new int[] { nearestNode, minDist };
        }
    }
}
