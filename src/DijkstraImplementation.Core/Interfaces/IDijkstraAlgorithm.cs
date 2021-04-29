using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraImplementation.Core.Interfaces
{
    public interface IDijkstraAlgorithm
    {
        List<int> Process(int[,] graph, int sourceNode, int destinationNode);
    }
}
