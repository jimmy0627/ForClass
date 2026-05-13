using System;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Array_Gen_H : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public (int, int) position; // used in WFC
        public bool[] walls = { true, true, true, true }; // top, left, bottom, right, used in recursive backtracking algorithm
        public int type = 1; // 1 for wall, 0 for path, used in kruskal's algorithm
        public List<Cell> neighbor = new List<Cell>(); // used in kruskal's algorithm
        public List<GameObject> celltypes = new List<GameObject>(); // list of cell types, used in WFC
        public int setID; // used in kruskal's algorithm
    }
    public List<Cell> walllist = new List<Cell>(); // list of wall types, used in Kruskal's algorithm
    [SerializeField] public List<GameObject> celltypes = new List<GameObject>(); // list of cell types, used in WFC
    public int width = 50;
    public int height = 50;
    public Cell[,] maze;
    public void GenerateMaze()
    {
        int counter = 0;
        maze = new Cell[width, height];
        // 第一階段：初始化所有格子
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //以下是填空部分
                ///目標:初始化maze二維陣列的每個格子，並設定它們的position
                /// 每個格子的position應該對應到它在maze陣列中的座標 (x,y)
                /// 同時，根據x和y的奇偶性來決定這個格子是牆還是路
                /// 如果x或y是偶數，則這個格子是牆 (type = 1)，否則是路 (type = 0)
                /// 詳細內容參考PPT上的說明
            }
        }

        // 第二階段：設定牆的鄰居並加入牆列表
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //以下是填空部分
                ///目標:對於maze陣列中的每個格子，如果它是牆 (type = 1)，就要找出它的鄰居
                /// 僅有垂直或水平的牆才會有鄰居，對角線的牆不算
                /// 如果這個牆格子有兩個鄰居，就把它加入walllist中，供Kruskal's algorithm使用
                /// 你如果想用Recursive來實作這裡可以不做，但如果想用Kruskal's algorithm來實作，這裡是必須的
            }
        }
    }
}
