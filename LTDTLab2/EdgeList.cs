using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDTLab2
{
    internal class EdgeList
    {
        LinkedList<Tuple<int, int>> g;
        int n;
        int m;

        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public LinkedList<Tuple<int, int>> G { get => g; set => g = value; }
        //Constructor
        public EdgeList()
        {
            g = new LinkedList<Tuple<int, int>>();
        }
        public EdgeList(int n, int m)
        {
            N = n;
            M = m;
            G = new LinkedList<Tuple<int, int>>();

        }
        //Thêm cạnh vào danh sách
        public void AddEdge(int u, int v)
        {
            G.AddLast(new Tuple<int, int>(u, v));
        }
        //Đọc file EdgeList.txt --> g
        public void FileToEdgeList(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string[] s = sr.ReadLine().Split(' ');
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            for (int i = 0; i < m; i++)
            {
                s = sr.ReadLine().Split(' ');
                //khởi tạo một cạnh mới 
                Tuple<int, int> e = new Tuple<int, int>(int.Parse(s[0]), int.Parse(s[1]));
                g.AddLast(e);

            }
            sr.Close();

        }
        public void Output()
        {
            Console.WriteLine("Danh sách cạnh của đồ thị với số đỉnh n = " + n);
            foreach (Tuple<int, int> e in g)
                Console.WriteLine(" (" + e.Item1 + "," + e.Item2 + ")");

        }
        

    }
}
