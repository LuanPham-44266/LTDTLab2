using LTDTLab2;
using System.Text;

static AdjList EdgeListToAdjList(EdgeList ge)
{
    // Kiểm tra số đỉnh và số cạnh
    if (ge.N <= 0 || ge.M <= 0)
    {
        throw new InvalidOperationException("Số đỉnh và số cạnh không hợp lệ");
    }
    // Khởi tạo đồ thị AdjList
    AdjList ga = new AdjList(ge.N); // Khởi tạo danh sách kề với số đỉnh = ge.N
                                    // Duyệt qua từng cạnh e trong EdgeList và thêm vào danh sách kề
    foreach (var e in ge.G)
    {
        // Kiểm tra xem các đỉnh có hợp lệ không
        if (e.Item1 >= ge.N || e.Item2 >= ge.N)
        { throw new InvalidOperationException($"Cạnh ({e.Item1}, {e.Item2}) không hợp lệ");
    }
    // Thêm e.Item2 vào ga.V[e.Item1] (đỉnh Item1 kề với Item2)
    ga.V[e.Item1].AddLast(e.Item2);
    // Thêm e.Item1 vào ga.V[e.Item2] (đỉnh Item2 kề với Item1)
    ga.V[e.Item2].AddLast(e.Item1);
}
return ga; // Trả về đồ thị danh sách kề
}
//chuyển danh sách cạnh sang danh sách kề
static EdgeList AdjListToEdgeList(AdjList ga)
{
    // Khởi tạo danh sách cạnh (EdgeList)
    EdgeList ge = new EdgeList(ga.N, 0); // 0 là số cạnh ban đầu (sẽ tính sau)
                                         // Duyệt qua từng đỉnh trong danh sách kề
    for (int i = 0; i < ga.N; i++)
    {
        foreach (var v in ga.V[i])
        {
            // Thêm cạnh (i, v) vào danh sách cạnh
            // Kiểm tra nếu (i, v) chưa được thêm (đảm bảo không trùng lặp)
            if (i < v) // Đảm bảo chỉ thêm một lần cho mỗi cạnh vô hướng
            {
                ge.AddEdge(i, v);
            }
        }
    }
    // Cập nhật số cạnh
    ge.M = ge.G.Count;
    return ge; // Trả về danh sách cạnh
}
//
// Xuất text theo Unicode (có dấu tiếng Việt)
Console.OutputEncoding = Encoding.Unicode;
// Nhập text theo Unicode (có dấu tiếng Việt)
Console.InputEncoding = Encoding.Unicode;
//
string path = "D:/PhamVietLuan/LTDTLab2/LTDTLab2/EdgeList.txt";
EdgeList edgeList = new EdgeList();
edgeList.FileToEdgeList(path);
edgeList.Output();
// tạo đồ thị AdjList từ EdgeList
AdjList adjList = new AdjList();
adjList = EdgeListToAdjList(edgeList);
adjList.Output();
string fileOutput = "AdjList.txt";
adjList.AdjListToFile(fileOutput);
//tạo đồ thị từ ds cạnh sang ds kề
EdgeList edgeList2 = AdjListToEdgeList(adjList);
edgeList.Output();