using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Node = Course22.GeneralTree<string>.Node;
namespace Course22
{
   
    public class FileSystem
    {
        private GeneralTree<string> Tree { get; set; } = new GeneralTree<string>("root");
        public void AddFile(string directoryFolder, string fileName)
        {
            Node folder = Tree.Find(directoryFolder);
            if(folder != null)
            {
                folder.AddChild(new Node(fileName));
            }
            else
            {
                Tree.Root.AddChild(new Node(fileName));
            }
        }
        public void AddFolder(string directoryFolder,string folerName)
        {
            Node directory = Tree.Find(directoryFolder);
            if (directory != null)
            {
                directory.AddChild(new Node(folerName));
            }
            else
            {
                Tree.Root.AddChild(new Node(folerName));
            }
        }
        public void Display()
        {
            Tree.PrintTree();
        }
    }
}
