using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    public class Graph
    {
        public enum DirectionType { Directed = 1, Undirected = 2}

        private int[,] _adjacencyMatrix;

        private Dictionary<string, int> _vertexDictionary;

        private int _numberOfVertices;

        private DirectionType directionType = DirectionType.Undirected;

        public Graph(List<string>verticies, DirectionType type)
        {
            directionType = type;
            _numberOfVertices = verticies.Count;
            _adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
            _vertexDictionary = new Dictionary<string, int>();

            for(int i = 0; i < verticies.Count; i++)
            {
                _vertexDictionary[verticies[i]] = i;
            }
        }

        public bool AddEdge(string vertex1, string vertex2, int weight)
        {
            if (_vertexDictionary.ContainsKey(vertex1) && _vertexDictionary.ContainsKey(vertex2))
            {
                int sourceIndex = _vertexDictionary[vertex1];
                int destinationIndex = _vertexDictionary[vertex2];

                _adjacencyMatrix[sourceIndex, destinationIndex] = weight;

                if (directionType == DirectionType.Undirected)
                {
                    _adjacencyMatrix[destinationIndex, sourceIndex] = weight;
                }
                return true;
            }
            Console.WriteLine($"Ignored, Invalid verticies. {vertex1}===>{vertex2}");
            return false;
            
        }
        public void DisplayGraph()
        {
            string[] keys = _vertexDictionary.Keys.ToArray();
            Console.WriteLine("  "+string.Join("  ", _vertexDictionary.Keys));
           
            for (int i = 0; i < _adjacencyMatrix.GetLength(0); i++)
            {
                Console.Write(keys[i] + " ");
                for(int j = 0; j < _adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(_adjacencyMatrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public bool IsEdge(string vertex1, string vertex2)
        {
            if(_vertexDictionary.ContainsKey(vertex1) && _vertexDictionary.ContainsKey(vertex2))
            {
                int v1Index = _vertexDictionary[vertex1];
                int v2Index = _vertexDictionary[vertex2];

                return _adjacencyMatrix[v1Index, v2Index] > 0;
            }
            return false;
            
        }

        public int GetInDegree(string vertex)
        {
            if (_vertexDictionary.ContainsKey(vertex))
            {
                int counter = 0;
                int colIndex = _vertexDictionary[vertex];
                for(int i=0; i < _adjacencyMatrix.GetLength(0); i++)// goes through rows
                {
                    if (_adjacencyMatrix[i, colIndex] > 0)
                        counter++;
                }
                return counter;
            }
            return -1;
        }
        public int GetOutDegree(string vertex)
        {
            if (_vertexDictionary.ContainsKey(vertex))
            {
                int counter = 0;
                int rowIndex = _vertexDictionary[vertex];
                for (int i = 0; i < _adjacencyMatrix.GetLength(1); i++)// goes through columns
                {
                    if (_adjacencyMatrix[rowIndex, i] > 0)
                        counter++;
                }
                return counter;
            }
            return -1;
        }
        public void BreadthFirstDisplay(string startVertix)
        {
            if (!_vertexDictionary.ContainsKey(startVertix)) 
            { 
                Console.WriteLine("No such vertex exist");
                return;
            }


            bool[] visited = new bool[_numberOfVertices];

            Queue<int> verticies = new Queue<int>();

            int startIndex = _vertexDictionary[startVertix];

            visited[startIndex] = true;

            verticies.Enqueue(startIndex);

            while (verticies.Count > 0)
            {
                int currentVertix = verticies.Dequeue();

                Console.WriteLine(GetVertexName(currentVertix));
                
                for(int i =0; i < _numberOfVertices; i++)
                {
                    if (_adjacencyMatrix[currentVertix,i] > 0 && !visited[i])
                    {
                        visited[i] = true;
                        verticies.Enqueue(i);
                        
                        
                    }
                }
                
                
               


            }

        }

        private string GetVertexName(int index)
        {
           return _vertexDictionary.Keys.ElementAt(index);
            
        }
        public void DepthFirstDisplay(string startVertix)
        {
            if (!_vertexDictionary.ContainsKey(startVertix))
            {
                Console.WriteLine("No such vertex exist");
                return;
            }


            bool[] visited = new bool[_numberOfVertices];

            Stack<int> verticies = new Stack<int>();

            int startIndex = _vertexDictionary[startVertix];

            visited[startIndex] = true;

            verticies.Push(startIndex);

            while (verticies.Count > 0)
            {
                int currentVertix = verticies.Pop();

                Console.WriteLine(GetVertexName(currentVertix));

                for (int i = _numberOfVertices - 1; i >= 0; i--)
                {
                    if (_adjacencyMatrix[currentVertix, i] > 0 && !visited[i])
                    {
                        visited[i] = true;
                        verticies.Push(i);

                    }
                }





            }
        }

        // Display the graph as an adjacency matrix
        public void DisplayGraph(string message)
        {
            Console.WriteLine("\n" + message + "\n");
            Console.Write("  ");
            foreach (var vertex in _vertexDictionary.Keys)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();

            foreach (var source in _vertexDictionary)
            {
                Console.Write(source.Key + " ");
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    Console.Write(_adjacencyMatrix[source.Value, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Dijkstra's Algorithm: Finds the shortest paths from a source vertex
        public void Dijkstra(string startVertex)
        {

            // Adjacency Matrix : O(V^2)
            // In the Next lesson we will use: Adjacency List with Min-Heap: O((V+E) log⁡ V)

            if (!_vertexDictionary.ContainsKey(startVertex))
            {
                Console.WriteLine("Invalid start vertex.");
                return;
            }

            // Initialize distance and visited arrays
            int startIndex = _vertexDictionary[startVertex];
            int[] distances = new int[_numberOfVertices]; // Stores shortest distances
            bool[] visited = new bool[_numberOfVertices]; // Tracks processed vertices
            string[] predecessors = new string[_numberOfVertices]; // Tracks the previous vertex on the shortest path

            // Initialize all distances to infinity and mark all vertices as unvisited
            for (int i = 0; i < _numberOfVertices; i++)
            {
                distances[i] = int.MaxValue; // Set distance to "infinity"
                visited[i] = false; // Mark as unvisited
                predecessors[i] = null; // No predecessors initially
            }
            distances[startIndex] = 0; // Distance to the source is 0

            // Main loop: Process each vertex
            for (int count = 0; count < _numberOfVertices - 1; count++)
            {
                // Find the unvisited vertex with the smallest distance
                int minVertex = GetMinDistanceVertex(distances, visited);
                visited[minVertex] = true; // Mark this vertex as visited

                // Update distances for all neighbors of the current vertex
                for (int v = 0; v < _numberOfVertices; v++)
                {
                    // Update distance if:
                    // 1. There is an edge.
                    // 2. The vertex is unvisited.
                    // 3. The new distance is shorter.
                    if (!visited[v] && _adjacencyMatrix[minVertex, v] > 0 &&
                        distances[minVertex] != int.MaxValue &&
                        distances[minVertex] + _adjacencyMatrix[minVertex, v] < distances[v])
                    {
                        distances[v] = distances[minVertex] + _adjacencyMatrix[minVertex, v];
                        predecessors[v] = GetVertexName(minVertex); // Record the predecessor, prev node.
                    }
                }
            }

            // Display the shortest paths and their distances
            Console.WriteLine("\nShortest paths from vertex " + startVertex + ":");
            for (int i = 0; i < _numberOfVertices; i++)
            {
                Console.WriteLine($"{startVertex} -> {GetVertexName(i)}: Distance = {distances[i]}, Path = {GetPath(predecessors, i)}");
            }
        }

        // Finds the unvisited vertex with the smallest distance
        private int GetMinDistanceVertex(int[] distances, bool[] visited)
        {
            int minDistance = int.MaxValue; // Start with infinity
            int minIndex = -1; // Invalid index initially

            // Iterate over all vertices
            for (int i = 0; i < _numberOfVertices; i++)
            {
                // Update the minimum if the vertex is unvisited and has a smaller distance
                if (!visited[i] && distances[i] < minDistance)
                {
                    minDistance = distances[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        // Helper to get the vertex name by its index
        

        // Reconstructs the shortest path from the source to a vertex using predecessors
        private string GetPath(string[] predecessors, int currentIndex)
        {
            // Base case: If there is no predecessor, return the current vertex
            if (predecessors[currentIndex] == null)
                return GetVertexName(currentIndex);

            // Recursive case: Build the path from the predecessor
            return GetPath(predecessors, _vertexDictionary[predecessors[currentIndex]]) + " -> " + GetVertexName(currentIndex);
        }

    }
}
