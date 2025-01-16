using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTDTLab2
{
    internal class AdjList
    {
        //Thuộc tính
        private LinkedList<int>[] v;
        private int n;

        //properties
        public int N
        {
            get => n;
            set => n = value;

        }
        public LinkedList<int>[] V
        {
            get { return v; }
            set { v = value; }
        }
        //Constructor
        public AdjList() { }

        //Constructor khởi tạo v có k đinh
        public AdjList(int k)
        {
            v = new LinkedList<int>[k];
            for (int i = 0; i < k; i++)
            {
                v[i] = new LinkedList<int>(); //Khởi tạo danh sách kề cho mỗi đỉnh
            }
        }
        //Constructor nhận mảng LinkedList<int>[]
        public AdjList(LinkedList<int>[] g)
        {
            v = g;
            n = g.Length;

        }
        //Đọc file AdjList.txt --> danh sách kề v 
        public void FileToAdjList(string filePath)
        {
            //Kiểm tra xem file có tồn tại không
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File không tồn tại!");
                return;

            }
            //sử dụng using để đảm bảo đóng file sau khi xử lí
            using (StreamReader sr = new StreamReader(filePath))
            {
                n = int.Parse(sr.ReadLine());
                v = new LinkedList<int>[(int)n];
                //Khởi tạo danh sách kề cho mỗi đỉnh
                for (int i = 0; i < n; i++)
                {
                    v[i] = new LinkedList<int>();
                    string st = sr.ReadLine();

                    //đặt điều kiện không phải đỉnh cô lập
                    if (!string.IsNullOrWhiteSpace(st))
                    {
                        string[] s = st.Split();
                        foreach (var item in s)
                        {
                            int x = int.Parse(item);
                            v[i].AddLast(x); //Thêm đỉnh kề vào danh sách kề của đỉnh i

                        }
                    }
                }
            }
        }
        //xuất đồ thị
        public void Output()
        {
            Console.WriteLine("Đồ thị danh sách kề - số đỉnh: " + n);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("Đỉnh {0} -> ", i);
                foreach (int x in v[i])
                {
                    Console.Write("{0 ,3 }", x);
                }
                Console.WriteLine();

            }
        }
        public void AdjListToFile(string path)
        {
            StreamWriter srOut = new StreamWriter(path);
            srOut.WriteLine("Đồ thị danh sách kề - số đỉnh: " + n);
            for (int i = 0; i < v.Length; i++)
            {
                srOut.Write("Đỉnh {0} ->", i);
                foreach (int x in v[i])
                {
                    srOut.Write("{0,3)", x);
                }
                srOut.WriteLine();
            }
            srOut.Close();
        }
        //Phương thức tính bậc của các đỉnh và xuất ra màn hình
        public void DegreeOfVertices()
        {
            Console.WriteLine("\nBậc của các đỉnh:");
            for (int i = 0; i < v.Length; i++)
            {
                Console.WriteLine($"Bậc của đỉnh {i}: {v[i].Count}");
            }
        }
        public void DegV(string filePath)
        {
            // Khởi tạo đối tượng StreamWriter để ghi vào file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Duyệt qua tất cả các đỉnh
                for (int i = 0; i < v.Length; i++)
                {
                    // Bậc của đỉnh i là số phần tử trong danh sách kề v[i]
                    int degree = v[i].Count;
                    // Ghi vào file
                    sw.WriteLine($"Bậc của đỉnh {i}: {degree}");
                    // Xuất ra màn hình
                    Console.WriteLine($"Bậc của đỉnh {i}: {degree}");
                }
               
            }
        } // StreamWriter sẽ tự động đóng file khi ra khỏi khối using
    }
}
    