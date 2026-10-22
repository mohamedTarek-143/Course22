using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace Course22
{
    internal class Program
    {
        public class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public Person(string name, int age, string city)
            {
                Name = name;
                Age = age;
                City = city;
            }
            public override string ToString()
            {
                return $"Name:{Name}, Age:{Age}, City: {City}";
            }

            int IComparable<Person>.CompareTo(Person? other)
            {
                if (other == null) return 1;

                return this.Age.CompareTo(other.Age);
            }
        }
        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }


            public Employee(string name, string department, decimal salary)
            {
                Name = name;
                Department = department;
                Salary = salary;
            }
        }
        static (int age, string name) ReturnTheseLol()
        {
            return (21, "Mohamed");
        }
        class FileNode
        {
            public string Name { get; set; } // Name of the file or directory
            public bool IsFile { get; set; } // Indicates whether this node is a file

            public int Size { get; set; }
            public List<FileNode> Children { get; set; } = new List<FileNode>(); // List of child nodes (subdirectories or files)



            public enum enType
            {
                Directory,
                File
            }


            public FileNode(string name, enType fType, int size)
            {
                Name = name;
                IsFile = fType == enType.File ? true : false;
                this.Size = size;
            }


            public void Print(string indent = "")
            {
                Console.WriteLine(indent + (IsFile ? "File: " : "Directory: ") + Name); // Print the current file/directory
                foreach (var child in Children)
                {
                    child.Print(indent + "  "); // Recursively print child nodes
                }
            }
            private int GetSize(FileNode fileNode)
            {
                int size = 0;

                size += fileNode.Size;

                foreach (FileNode node in fileNode.Children)
                {
                    size += GetSize(node);
                }
                return size;
            }
            public int GetSize()
            {
                return GetSize(this);
            }
            //abu hadhud way
            public int CalculateTotalSize()
            {
                int totalSize = Size;
                foreach (var child in Children)
                {
                    totalSize += child.CalculateTotalSize();
                }
                return totalSize;
            }
        }
        class DecisionNode
        {
            public string Question { get; set; }
            public DecisionNode Yes { get; set; }
            public DecisionNode No { get; set; }
            public DecisionNode(string question)
            {
                this.Question = question;
            }
        }
        class Product
        {
            public string ProductName { get; set; }
            public CategoryNode Category { get; set; }
            public Product(string name, CategoryNode category)
            {
                this.ProductName = name;
                this.Category = category;
            }
            public void Print(string ident)
            {
                Console.Write($"Name:{ProductName}"+ident);
            }
        }
        class CategoryNode
        {
            public string Name { get; set; }
            public List<Product> products = new List<Product>();
            public CategoryNode(string name)
            {
                this.Name = name;
            }
            public void Print(string indent = "")
            {
                Console.WriteLine(indent + Name); // Print the current category
                foreach (var subCategory in products) // Loop through subcategories
                {
                    subCategory.Print(indent + "  "); // Recursively print subcategories with indentation
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Graph graph = new Graph(new List<string> { "A","B","C","D","E","F","G"},Graph.DirectionType.Directed);
            graph.AddEdge("A", "B", 2);
            graph.AddEdge("B", "C", 3);
            graph.DisplayGraph();
            graph.AddEdge("B", "A", 5);
            Console.WriteLine("Added a new edge and all");
        }
        //FileSystem fileSystem = new FileSystem();
        //fileSystem.AddFolder("root", "My New Folder");
        //fileSystem.AddFile("My New Folder", "myImage.png");
        //fileSystem.AddFile("My New Folder", "cat.png");
        //fileSystem.AddFile("My New Folder", "hat.jpg");
        //fileSystem.AddFile("My New Folder", "notes.txt");
        //fileSystem.AddFolder("root", "Another Folder");
        //fileSystem.AddFile("Another Folder", "Project.pdf");
        //fileSystem.AddFile("root", "MainFile.bat");
        //fileSystem.Display();
        //// Define vertices
        //List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

        //// Create a directed graph
        //Graph graph = new Graph(vertices, Graph.DirectionType.Directed);

        //// Add edges with weights
        ////
        ////A → B: 10 minutes
        ////A → C: 15 minutes
        ////B → D: 12 minutes
        ////C → D: 10 minutes
        ////B → E: 15 minutes
        ////D → E: 2 minutes
        //graph.AddEdge("A", "B", 10);
        //graph.AddEdge("A", "C", 15);
        //graph.AddEdge("B", "D", 12);
        //graph.AddEdge("C", "D", 10);
        //graph.AddEdge("B", "E", 15);
        //graph.AddEdge("D", "E", 2);


        //// Display the graph
        //graph.DisplayGraph();

        //// Run Dijkstra's Algorithm from vertex "A"
        //graph.Dijkstra("A");
        //RedBlackTree rbTree = new RedBlackTree();


        // Test values to be inserted into the tree
        //int[] values = { 10, 20, 30, 15, 25, 35, 5, 19 };
        //foreach (var value in values)
        //{
        //    Console.WriteLine($"Inserting {value} to the tree\n");
        //    rbTree.Insert(value);
        //    rbTree.PrintTree();
        //    Console.WriteLine("\n--------------------------------\n");
        //}
        //int valuee = 150;
        //RedBlackTree.Node n = rbTree.Find(valuee);
        //if(n != null)
        //{
        //    Console.WriteLine($"Found node\nIs Red: {n.IsRed}\nValue:{n.Value}");
        //}
        //Console.ReadKey();

        // BinarySearchTree<int> bst = new BinarySearchTree<int>(43);
        // bst.Insert(23);
        // bst.Insert(234);
        // bst.Insert(32);
        // bst.TraverseDepthFirst(DepthFirstTraversalTechnique.InOrder);

        //BinarySearchTree<int>.Node n = bst.Search(43);
        // if(n != null)
        // {
        //     Console.WriteLine($"I got node n with value {n.Value} and right child of {n.Right.Value} and left with value {n.Left.Value}");
        // }

        //List<string> verticies = new List<string>{ "A", "B", "C", "D" };
        //Graph graph = new Graph(verticies,Graph.DirectionType.Undirected);
        //graph.AddEdge("A", "B", 1);
        //graph.AddEdge("C", "B",1);
        //graph.DisplayGraph();
        //Console.WriteLine($"B In-Degree is: {graph.GetInDegree("B")}");
        //Console.WriteLine($"A Out-Degree is: {graph.GetOutDegree("A")}");

        //int a = 10;
        //int b = 123;

        //(a, b) = (b, a);
        //Console.WriteLine(a);
        //Console.WriteLine(b);



        // Build tree
        //var tree = new BinaryTree<int>(1);
        //tree.Root.AddLeftChild(2);
        //tree.Root.AddRightChild(3);

        //tree.Root.Left.AddLeftChild(4);
        //tree.Root.Left.AddRightChild(5);

        //tree.Root.Right.AddLeftChild(6);
        //tree.Root.Right.AddRightChild(7);

        //Console.WriteLine("--- Breadth First ---");
        //tree.Root.TraverseBreadthFirst(tree.Root);

        //Console.WriteLine("\n--- DFS: PreOrder ---");
        //tree.Root.TraverseDepthFirst(tree.Root, BinaryTree<int>.DepthFirstTraversalTechinique.PreOrder);

        //Console.WriteLine("\n--- DFS: InOrder ---");
        //tree.Root.TraverseDepthFirst(tree.Root, BinaryTree<int>.DepthFirstTraversalTechinique.InOrder);

        //Console.WriteLine("\n--- DFS: PostOrder ---");
        //tree.Root.TraverseDepthFirst(tree.Root, BinaryTree<int>.DepthFirstTraversalTechinique.PostOrder);

        //GeneralTree<string> companyTree = new GeneralTree<string>("CEO");
        //var finance = new GeneralTree<string>.Node("CFO");
        //var tech = new GeneralTree<string>.Node("CTO");
        //var marketing = new GeneralTree<string>.Node("CMO");


        //// Add departments to CEO
        //companyTree.Root.AddChild(finance);
        //companyTree.Root.AddChild(tech);
        //companyTree.Root.AddChild(marketing);


        //// Add employees to departments
        //finance.AddChild(new GeneralTree<string>.Node("Accountant"));
        //tech.AddChild(new GeneralTree<string>.Node("Developer"));
        //tech.AddChild(new GeneralTree<string>. Node("UX Designer"));
        //marketing.AddChild(new GeneralTree<string>. Node("Social Media Manager"));

        //companyTree.PrintTree();

        //GeneralTree<string>.Node? n = companyTree.Root.Find("Developer");
        //if(n != null)
        //{
        //    Console.WriteLine($"N is not null I have a node with value {n.Value}");
        //}
        //MyCustomCollection strings = new MyCustomCollection();
        //strings.Add("Mohamed");
        //strings.Add("Tarek");
        //strings.Add("Lilia");
        //foreach (var item in strings)
        //{
        //    Console.WriteLine(item);
        //}


        //  //Tuple

        //  (int age, string name) person = (21,"Mohamed");
        ////  Console.WriteLine(person.age);
        //  //or
        //  var person2 = (21, "Ahmed Ibrahim");

        //  //or
        //  var person3 = (age: 11, name: "Ahmed Ibrahim");
        //  Console.WriteLine(person3.age + "    ---    " + person3.name);
        //  person3 = ReturnTheseLol();
        //  person3.age = 123;
        //  Console.WriteLine(person3.age + "    ---    " + person3.name);

        //int[][] myJaggedArray = new int[3][];
        //myJaggedArray[0] = new int[5] { 1, 2, 3, 4, 5 };
        //myJaggedArray[1] = new int[2] { 6, 7 };
        //myJaggedArray[2] = new int[20] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        //for(int i= 0; i < myJaggedArray.Length; i++)
        //{
        //    for (int j = 0; j < myJaggedArray[i].Length; j++)
        //    {
        //        Console.Write(myJaggedArray[i][j] + " ");
        //    }
        //    Console.WriteLine();
        //}

        //BitArray bitArray1 = new BitArray(new bool[] { false, true, true, false, true, false, true, true });
        //BitArray bitArray2 = new BitArray(new bool[] { true, true, true, false, false, false, true, false });
        //string bitArray1Str = bitArrayToString(bitArray1);
        //string bitArray2Str = bitArrayToString(bitArray2);
        //Console.WriteLine(bitArray1Str);
        //Console.WriteLine("                             AND");
        //Console.WriteLine(bitArray2Str);
        //BitArray resultAnd = bitArray1.And(bitArray2);
        //Console.WriteLine(new string('-', 50));
        //Console.WriteLine(bitArrayToString(resultAnd));
        //Console.WriteLine();

        static string bitArrayToString(BitArray bitArray)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (bool item in bitArray)
            {
                char value = item ? '1' : '0';
                stringBuilder.Append(value);
            }
            return stringBuilder.ToString();
        }
        //// Array of people with Name and Age
        //var people = new[]
        //{
        //new { Name = "Alice", Age = 30 },
        //new { Name = "Bob", Age = 25 },
        //new { Name = "Charlie", Age = 35 },
        //new { Name = "Diana", Age = 30 },
        //new { Name = "Ethan", Age = 25 }
        // };
        //// Grouping people by Age, then ordering within each group

        //var groupedByAge = people.GroupBy(person => person.Age)
        //                         .Select(group => new
        //                         {
        //                             Age = group.Key,
        //                             People = group.OrderBy(p=>p.Name)

        //                         });
        //foreach(var group in groupedByAge)
        //{
        //    Console.WriteLine(group.Age);
        //    foreach(var person in group.People)
        //    {
        //        Console.WriteLine($" - {person.Name}");
        //    }
        //}

        //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //var evenNumbers = numbers.Where(n => n % 2 == 0);
        //int sum = evenNumbers.Sum();
        //Console.WriteLine(sum +" of even numbers");

        //    // Array of employees
        //    var employees = new[]
        //    {
        //    new { Id = 1, Name = "Alice", DepartmentId = 2 },
        //    new { Id = 2, Name = "Bob", DepartmentId = 1 }
        //};


        //    // Array of departments
        //    var departments = new[]
        //    {
        //    new { Id = 1, Name = "Human Resources" },
        //    new { Id = 2, Name = "Development" }
        //};

        //    var joined = employees.Join(departments, d => d.Id, e => e.Id,
        //        (employee, department) => 
        //        new { ID = employee.Id, Name = employee.Name, Department = department.Name,
        //            DepartmentID = department.Id });

        //    // Displaying the results
        //    foreach (var detail in joined)
        //    {
        //        Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department}");
        //    }

        //int[,] my2dArray = new int[3,3];
        //int fill = 1;
        //for(int rows = 0; rows<3; rows++)
        //{
        //    for(int cols = 0; cols < 3; cols++)
        //    {
        //        my2dArray[rows, cols] = fill++;

        //    }
        //}
        //// Print as a grid instead of one number per line
        //for (int r = 0; r < my2dArray.GetLength(0); r++)
        //{
        //    for (int c = 0; c < my2dArray.GetLength(1); c++)
        //    {
        //        Console.Write(my2dArray[r, c] + "\t");
        //    }
        //    Console.WriteLine();
        //}
        //int[] numbers = { 5, 3, 1, 4, 2 };
        //Array.Sort(numbers);
        //Console.WriteLine(string.Join(',',numbers));
        //int searchedFor = Array.IndexOf(numbers, 3);
        //if(searchedFor != -1)
        //{
        //    Console.WriteLine("index is " +searchedFor);
        //}
        //int[] arr2 = new int[numbers.Length];
        //Array.Copy(numbers, arr2, numbers.Length);
        //var evenNumbers = arr2.Where(n => n % 2 == 0);
        //Console.WriteLine(string.Join(",", evenNumbers));
        //SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>();

        //sortedDict.Add("apple", 10);
        //sortedDict.Add("banana", 20);
        //sortedDict.Add("orange", 15);

        //sortedDict.Remove("apple");
        //// accessing the value of apple
        //if (sortedDict.ContainsKey("apple"))
        //{
        //    Console.WriteLine(sortedDict["apple"]);
        //}
        //foreach (var item in sortedDict)
        //{
        //    Console.WriteLine(item.Value);
        //}

        //SortedSet<int> mySortedSet = new SortedSet<int>();
        //mySortedSet.Add(1);
        //mySortedSet.Add(12);
        //mySortedSet.Add(4);
        //foreach (var item in mySortedSet)
        //{
        //    Console.WriteLine(item);
        //}

        // Creating an ObservableCollection
        //ObservableCollection<string> Items = new ObservableCollection<string>();
        //// Subscribing to the CollectionChanged event
        //Items.CollectionChanged += Items_CollectionChanged;


        //// Modifying the ObservableCollection
        //Items.Add("Item 1");
        //Items.Add("Item 2");
        //Items.Add("Item 3");


        //Items.RemoveAt(1);
        //Items.Insert(0, "New Item");
        //Items[1] = "Replaced Item"; // Replace action
        //Items.Move(0, 2); // Move action


        // Printing the Final Collection
        //    Console.WriteLine("\nFinal Collection:");
        //foreach (var item in Items)
        //{
        //    Console.WriteLine(item);
        //}
        //Console.ReadKey();
        // CollectionChanged Event Handler
        static void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine("\nCollection Changed:");


        // Handling Collection Changes
        switch (e.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                Console.WriteLine("Added:");
                foreach (var newItem in e.NewItems)
                {
                    Console.WriteLine("- " + newItem);
                }
                break;


            case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                Console.WriteLine("Removed:");
                foreach (var oldItem in e.OldItems)
                {
                    Console.WriteLine("- " + oldItem);
                }
                break;


            case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                Console.WriteLine("Replaced:");
                foreach (var oldItem in e.OldItems)
                {
                    Console.WriteLine("- " + oldItem);
                }
                Console.WriteLine("With:");
                foreach (var newItem in e.NewItems)
                {
                    Console.WriteLine("- " + newItem);
                }
                break;


            case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                Console.WriteLine("Moved:");
                Console.WriteLine($"- From index {e.OldStartingIndex} to index {e.NewStartingIndex}");
                break;
        }
         
        }

        
    }
    
}
//SortedList<string, int> sortedFruits = new SortedList<string, int>();
//sortedFruits.Add("Banana", 50);
//sortedFruits.Add("Orange", 23);
//sortedFruits.Add("Apple", 10);

//foreach (var item in sortedFruits)
//{
//    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//}
//sortedFruits.Remove("Apple");
//Console.WriteLine("\nAfter removing Apple\n");
//foreach (var item in sortedFruits)
//{
//    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//}
//Console.WriteLine(new string('-', 50));
//Console.WriteLine();
//SortedList<string, int> numbers = new SortedList<string, int>();
//numbers.Add("One", 1);
//numbers.Add("Two", 2);
//numbers.Add("Three", 3);
//numbers.Add("Four", 4);
//numbers.Add("Five", 5);

//var numbersGreaterThanOne = from kvp in numbers
//                            where kvp.Value > 1
//                            select kvp;

//// var numbersGreaterThanOneWay2 = numbers.Where(kvp => kvp.Value > 1);

//foreach (var item in numbersGreaterThanOne)
//{
//    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//}

// Initialize a SortedList of int keys and string values with fruit names
//SortedList<int, string> sortedList = new SortedList<int, string>()
//{
//{ 1, "Apple" },
//{ 2, "Banana" },
//{ 3, "Cherry" },
//{ 4, "Date" },
//{ 5, "Grape" },
//{ 6, "Fig" },
//{ 7, "Elderberry" }
//};

//var groupedByValueLength = sortedList.GroupBy(kvp => kvp.Value.Length);
//foreach(var group in groupedByValueLength)
//{
//    Console.WriteLine("Group with Length {0}: {1}", group.Key,string.Join(',',group.Select(kvp=>kvp.Value)));

//}
//SortedList<int, Employee> employees = new SortedList<int, Employee>()
//{
//    { 1, new Employee("Alice", "HR", 50000) },
//    { 2, new Employee("Bob", "IT", 70000) },
//    { 3, new Employee("Charlie", "HR", 52000) },
//    { 4, new Employee("Daisy", "IT", 80000) },
//    { 5, new Employee("Ethan", "Marketing", 45000) }
//};
////filter Employee objects by the "IT" department,
////sort them by salary in descending order, and select their names.
//var ITEmployeesSortedBySalaryDesc = employees.Where(e => e.Value.Department == "IT")
//                                            .OrderByDescending(e => e.Value.Salary)
//                                            .Select(e=>e.Value);
//foreach(Employee e in ITEmployeesSortedBySalaryDesc)
//{
//    Console.WriteLine($"Name: {e.Name}, Salary: {e.Salary}, Department: {e.Department}");
//}
//// remove duplicates using hashset
//int[] array = new int[] { 1, 2, 2, 3, 4, 5, 52, 52 };

//HashSet<int> ints = new HashSet<int>(array);
//foreach(int item in ints)
//{
//    Console.WriteLine(item);
//}

//// using manual way O(n^2)

//int[] nonDuplicateArray = new int[array.Length];
//int nextSuitableIndex = 0;
//for (int i = 0; i < array.Length; i++)
//{
//    int val = array[i];
//    bool alreadyInNewArray = false;

//    for (int j = 0; j < nonDuplicateArray.Length; j++)
//    {
//        if (nonDuplicateArray[j] == val)
//        {
//            alreadyInNewArray = true;
//            break;
//        }
//    }
//    if (!alreadyInNewArray)
//    {
//        nonDuplicateArray[nextSuitableIndex] = val;
//        nextSuitableIndex++;
//    }
//}
//Console.WriteLine("Original Array");
//Console.WriteLine(string.Join(',', array));
//Console.WriteLine("Non duplicate array");
//Console.WriteLine(string.Join(',', nonDuplicateArray));


//// third way manual using dictionary
//int[] nonDuplicateArray2 = new int[array.Length];
//int nextSuitableIndex2 = 0;
//Dictionary<int, bool> seen = new Dictionary<int, bool>();

//for(int i = 0; i <array.Length; i++)
//{
//    int val = array[i];
//    if (!seen.ContainsKey(val))
//    {
//        seen.Add(val, true);
//        nonDuplicateArray2[nextSuitableIndex2] = val;
//        nextSuitableIndex2++;
//    }
//}
//for(int i = 0; i< nextSuitableIndex2; i++)
//{
//    Console.WriteLine(nonDuplicateArray2[i]);
//}


//var collection = ints.Where(n => n > 3);

//HashSet<int> evenNumbers = ints.Where(n => n % 2 == 0).ToHashSet();

////
//HashSet<string> namesSet = new HashSet<string>
//{
//    "Mohamed","Tarek","Sayed"
//};
//HashSet<string> lastNmaes = new HashSet<string> { "Tarek", "Ibrahim" };
//namesSet.UnionWith(lastNmaes);
//foreach(string str in namesSet)
//{
//    Console.WriteLine(str);
//}

////HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
////HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };


//// Intersection of set1 and set2
////set1.IntersectWith(set2);


////Console.WriteLine("Intersection of sets:");
////foreach (int item in set1)
////{
////    Console.WriteLine(item);
////}

////set1.ExceptWith(set2);
////foreach (int item in set1)
////{
////    Console.WriteLine(item);
////}


////Retaining elements unique to each set using SymmetricExceptWith.
//// Symmetric difference between set1 and set2
////set1.SymmetricExceptWith(set2);


////Console.WriteLine("Symmetric difference of sets:");
////foreach (int item in set1)
////{
////    Console.WriteLine(item);
////}

//HashSet<int> set1 = new HashSet<int> { 1, 2 };
//HashSet<int> set2 = new HashSet<int> { 1, 2, 3 };
//HashSet<int> set3 = new HashSet<int> { 3, 4, 5 };


//Console.WriteLine("set1 equals set2: " + set1.SetEquals(set2));
//Console.WriteLine("set1 equals set3: " + set1.SetEquals(set3));
//Console.WriteLine("set1 is subset of set 2?: " + set1.IsSubsetOf(set2));
//Console.WriteLine("set2 is superset of set1?: " + set2.IsSupersetOf(set1));
//Console.WriteLine("Does set1 and set3 overlap: " + set1.Overlaps(set3));
//Console.WriteLine("Does set1 and set2 overlap: " + set1.Overlaps(set2));
//Console.ReadKey();


//            //    int x = 10;
//            //    object myVal = x; // boxing
//            //                      // Console.WriteLine(myVal);

//            //    int y = (int)myVal;//unboxing
//            //                       //  Console.WriteLine(y);


//            //    List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0 };
//            //    list.Insert(0, 0);
//            //    list.InsertRange(4, new List<int> { 100, 200, 300 });

//            //    list.RemoveAll(a => a == 0);
//            //    list.RemoveAt(1);


//            //    list.ForEach( (int item) => Console.WriteLine(item));

//            //    Console.WriteLine("Sum: " + list.Sum());
//            //    Console.WriteLine("Average: " + list.Average());
//            //    Console.WriteLine("Count: " + list.Count());
//            //    Console.WriteLine("Min: " + list.Min());
//            //    Console.WriteLine("Max: " + list.Max());

//            //    Console.WriteLine("Even Numebrs: " + string.Join(',', list.Where((int item) => item % 2 == 0)));
//            //    Console.WriteLine("Odd Numbers: " + string.Join(',', list.Where((int item) => item %2 == 1)));
//            //    Console.WriteLine("Numbers Greater than 5: " + string.Join(',', list.Where(item => item > 5)));
//            //    Console.WriteLine("Every Second Number: " + string.Join(',', list.Where((item, index) =>index % 2 == 0 )));
//            //    Console.WriteLine("Numbers between 3 and 8: " + string.Join(',', list.Where(item => item > 3 && item < 8)));
//            //}


//            List<int> list = new List<int> { -21, 3, 431, 21, -500, 34, 5, 377, 6345 };
//            //   list.Sort();
//            //   Console.WriteLine(string.Join(',', list));
//            //   list.Reverse();
//            //   Console.WriteLine(string.Join(',', list));

//            list = list.OrderBy(item => item).ToList();// this is used to order by a specefic thing like person => person.age
//            list = list.Order().ToList(); // this is the same thing
//            Console.WriteLine(string.Join(',', list));

//            list = list.OrderDescending().ToList();
//            list = list.OrderByDescending(item => item).ToList();
//            Console.WriteLine(string.Join(',', list));



//            bool containNegative21 = list.Contains(-21);

//            bool containsAnyNegativeNumber = list.Exists(item => item < 0);

//            containsAnyNegativeNumber = list.Any(item => item < 0); // same as Exists but from LINQ

//            Console.WriteLine("Contains -21: " + containNegative21);
//            Console.WriteLine("Contains negative numbers: " + containsAnyNegativeNumber);

//            Console.WriteLine("First Number bigger than 1: " + list.Find(item => item > 1)); // first item bigger than one
//            Console.WriteLine("All numbers bigger than 1: " + string.Join(',', list.FindAll(item => item > 1))); // all items bigger than one

//            List<string> words = new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew" };

//            Console.WriteLine("Contains apple: " + words.Contains("apple"));
//            Console.WriteLine("Contains a word with more than 5 letters: " + words.Exists(str => str.Length > 5));
//            Console.WriteLine("First word longer than 5 charachters: " + words.Find(word => word.Length > 5));
//            Console.WriteLine("All words longer than 5 charachters: " + string.Join(',', words.FindAll(word => word.Length > 5)));
//            Console.WriteLine("Words starts with a: " + words.Any(word => word.StartsWith('a')));
//            Console.WriteLine("Words ends with a:" + words.Any(word => word.EndsWith('a')));
//            Console.WriteLine("All words ends or starts with a: "+ string.Join(',', words.Where(word => word.StartsWith('a') || word.EndsWith('a'))));

//            List<Person> people = new List<Person>
//{
//    new Person("James", 25, "Cairo"), new Person("Mary", 34, "Alexandria"),
//    new Person("John", 41, "Giza"), new Person("Patricia", 29, "Cairo"),
//    new Person("Robert", 38, "Luxor"), new Person("Jennifer", 22, "Cairo"),
//    new Person("Michael", 45, "Giza"), new Person("Linda", 31, "Alexandria"),
//    new Person("William", 27, "Luxor"), new Person("Elizabeth", 36, "Cairo"),
//    new Person("David", 44, "Giza"), new Person("Barbara", 23, "Alexandria"),
//    new Person("Richard", 39, "Cairo"), new Person("Susan", 30, "Luxor"),
//    new Person("Joseph", 28, "Giza"), new Person("Jessica", 33, "Cairo"),
//    new Person("Thomas", 42, "Alexandria"), new Person("Sarah", 26, "Luxor"),
//    new Person("Charles", 37, "Cairo"), new Person("Karen", 24, "Giza"),
//    new Person("Christopher", 40, "Alexandria"), new Person("Nancy", 32, "Cairo"),
//    new Person("Daniel", 29, "Luxor"), new Person("Lisa", 35, "Giza"),
//    new Person("Matthew", 43, "Cairo"), new Person("Betty", 21, "Alexandria"),
//    new Person("Anthony", 46, "Luxor"), new Person("Margaret", 34, "Cairo"),
//    new Person("Mark", 27, "Giza"), new Person("Sandra", 38, "Alexandria"),
//    new Person("Donald", 25, "Cairo"), new Person("Ashley", 30, "Luxor"),
//    new Person("Steven", 41, "Giza"), new Person("Kimberly", 28, "Cairo"),
//    new Person("Paul", 36, "Alexandria"), new Person("Emily", 23, "Luxor"),
//    new Person("Andrew", 39, "Cairo"), new Person("Donna", 44, "Giza"),
//    new Person("Joshua", 31, "Alexandria"), new Person("Michelle", 26, "Cairo"),
//    new Person("Kenneth", 33, "Luxor"), new Person("Dorothy", 42, "Giza"),
//    new Person("Kevin", 24, "Cairo"), new Person("Carol", 37, "Alexandria"),
//    new Person("Brian", 29, "Luxor"), new Person("Amanda", 35, "Cairo"),
//    new Person("George", 40, "Giza"), new Person("Melissa", 22, "Alexandria"),
//    new Person("Timothy", 45, "Cairo"), new Person("Deborah", 27, "Luxor"),
//    new Person("Ronald", 32, "Giza"), new Person("Stephanie", 38, "Cairo"),
//    new Person("Edward", 43, "Alexandria"), new Person("Rebecca", 25, "Luxor"),
//    new Person("Jason", 30, "Cairo"), new Person("Sharon", 41, "Giza"),
//    new Person("Jeffrey", 28, "Alexandria"), new Person("Laura", 36, "Cairo"),
//    new Person("Ryan", 23, "Luxor"), new Person("Cynthia", 39, "Giza"),
//    new Person("Jacob", 44, "Cairo"), new Person("Kathleen", 31, "Alexandria"),
//    new Person("Gary", 26, "Luxor"), new Person("Amy", 33, "Cairo"),
//    new Person("Nicholas", 42, "Giza"), new Person("Shirley", 24, "Alexandria"),
//    new Person("Eric", 37, "Cairo"), new Person("Angela", 29, "Luxor"),
//    new Person("Jonathan", 35, "Giza"), new Person("Helen", 40, "Cairo"),
//    new Person("Stephen", 22, "Alexandria"), new Person("Anna", 45, "Luxor"),
//    new Person("Larry", 27, "Cairo"), new Person("Brenda", 32, "Giza"),
//    new Person("Justin", 38, "Alexandria"), new Person("Pamela", 43, "Cairo"),
//    new Person("Scott", 25, "Luxor"), new Person("Nicole", 30, "Giza"),
//    new Person("Brandon", 41, "Cairo"), new Person("Emma", 28, "Alexandria"),
//    new Person("Benjamin", 36, "Luxor"), new Person("Samantha", 23, "Cairo"),
//    new Person("Samuel", 39, "Giza"), new Person("Katherine", 44, "Alexandria"),
//    new Person("Gregory", 31, "Cairo"), new Person("Christine", 26, "Luxor"),
//    new Person("Frank", 33, "Giza"), new Person("Debra", 42, "Cairo"),
//    new Person("Alexander", 24, "Alexandria"), new Person("Rachel", 37, "Luxor"),
//    new Person("Raymond", 29, "Cairo"), new Person("Catherine", 35, "Giza"),
//    new Person("Patrick", 40, "Alexandria"), new Person("Carolyn", 22, "Luxor"),
//    new Person("Jack", 45, "Cairo"), new Person("Janet", 27, "Giza"),
//    new Person("Dennis", 32, "Alexandria"), new Person("Ruth", 38, "Luxor"),
//    new Person("Jerry", 43, "Cairo"), new Person("Maria", 25, "Giza"),
//    new Person("Mohamed", 21, "Alexandria"), new Person("Omar", 30, "Luxor")
//};

//            Console.WriteLine(people.Find(p => p.Name == "Mohamed"));

//            List<Person> peopleOver30 = people.FindAll(p => p.Age > 30);
//            peopleOver30.ForEach(p => Console.WriteLine(p));

//            Person[] arr = peopleOver30.ToArray();
//            List<Person> listLol = new List<Person>(arr);


//            // Initialization
//            Hashtable myHashtable = new Hashtable();
//            myHashtable.Add("key1", "value1");
//            myHashtable.Add("key2", "value2");
//            myHashtable.Add("key3", "value3");




//            // Accessing an element
//            Console.WriteLine($"Accessing key1: {myHashtable["key1"]}");


//            // Modifying an element
//            myHashtable["key1"] = "newValue1";


//            // Removing an element
//            myHashtable.Remove("key2");


//            // Iterating over elements
//            Console.WriteLine("\nCurrent Hashtable contents:");
//            foreach (DictionaryEntry entry in myHashtable)
//            {
//                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
//            }

//            Dictionary<string, int> fruitBasket = new Dictionary<string, int>();
//            fruitBasket.Add("Apple", 1);
//            fruitBasket.Add("Banana", 2);
//            fruitBasket.Add("Mango", 3);
//            fruitBasket.Add("Pears", 4);
//            fruitBasket.Add("Strawberry", 5);
//            fruitBasket.Add("Kiwi", 6);
//            fruitBasket.Add("Peach", 7);
//            fruitBasket.Add("Watermelon", 8);
//            fruitBasket.Add("Pinaple", 9);
//            fruitBasket.Add("Orange", 10);

//            fruitBasket["Apple"] = -1;



//            foreach (KeyValuePair<string,int> valuePair in fruitBasket)
//            {
//                Console.WriteLine($"Key:{valuePair.Key}, Value: {valuePair.Value} ");
//            }

//            fruitBasket.Remove("Banana");

//            foreach (KeyValuePair<string, int> valuePair in fruitBasket)
//            {
//                Console.WriteLine($"Key:{valuePair.Key}, Value: {valuePair.Value} ");
//            }

//            if(fruitBasket.TryGetValue("Apple", out int val))
//                  Console.WriteLine(val);

/*
  Dictionary<string, int> fruitBasket = new Dictionary<string, int>();
            fruitBasket.Add("Apple", 1);
            fruitBasket.Add("Orange", 10);
            fruitBasket.Add("Banana", 2);
            fruitBasket.Add("Peach", 7);
            fruitBasket.Add("Pears", 4);
            fruitBasket.Add("Watermelon", 8);
            fruitBasket.Add("Strawberry", 5);
            fruitBasket.Add("Kiwi", 6);
  
            fruitBasket.Add("Pinaple", 9);
            fruitBasket.Add("Mango", 3);

            var newShape = fruitBasket.Select((KeyValuePair<string, int> kvp) => new { Key = kvp.Key, Quantity = kvp.Value });
            // that created an anonymous class with two properties, var is required here cause I can't know the name of that class
            foreach(var item in newShape)
            {
                Console.WriteLine($"Key: {item.Key}, Quantity: {item.Quantity}");
            }

            Console.WriteLine(new string('-', 50));

            var fruitsWithQunatityLessThan5 = fruitBasket.Where(kvp => kvp.Value < 5);
            foreach(var item in fruitsWithQunatityLessThan5)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine(new string('-', 50));

            var ordered = fruitBasket.OrderBy(kvp => kvp.Value);
            foreach (var item in ordered)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine(new string('-', 50));

            var orderedDesc = fruitBasket.OrderByDescending(kvp => kvp.Value);
            foreach (var item in orderedDesc)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine(new string('-', 50));

            int totalQuantity = fruitBasket.Sum(kvp => kvp.Value);
            Console.WriteLine("Total Quantity: {0}", totalQuantity);

            Dictionary<string, string> fruitsCategory = new Dictionary<string, string>
            {
                { "Apple", "Tree" },
                { "Banana", "Herb" },
                { "Cherry", "Tree" },
                { "Strawberry", "Bush" },
                { "Raspberry", "Bush" }
            };

            var groupedFruits = fruitsCategory.GroupBy(kvp => kvp.Value);

            foreach(var group in groupedFruits)
            {
                Console.WriteLine(group.Key);

                foreach (var fruit in group)
                {
                    Console.WriteLine($" - {fruit.Key}");
                }
            
            }

            var sortedFilteredFruits = fruitBasket
            .Where(kpv => kpv.Value > 3)
            .OrderBy(kpv => kpv.Key)
            .Select(kpv => new { kpv.Key, kpv.Value });


            foreach (var fruit in sortedFilteredFruits)
            {
                Console.WriteLine($"Fruit: {fruit.Key}, Quantity: {fruit.Value}");
            }
 */
