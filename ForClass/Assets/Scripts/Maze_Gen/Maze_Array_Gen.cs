using System;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Array_Gen : MonoBehaviour
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
                maze[x, y] = new Cell();
                maze[x, y].position = (x, y);
                maze[x, y].celltypes = new List<GameObject>(this.celltypes);
                if (x % 2 == 0 && y % 2 == 0)
                {
                    maze[x, y].type = 0; // 路
                    maze[x, y].setID = counter++;
                }
                else
                {
                    maze[x, y].type = 1; // 牆
                }
            }
        }

        // 第二階段：設定牆的鄰居並加入牆列表
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y].type == 1)
                {
                    if (x % 2 == 1 && y % 2 == 0) // 垂直牆
                    {
                        if (x > 0) maze[x, y].neighbor.Add(maze[x - 1, y]);
                        if (x < width - 1) maze[x, y].neighbor.Add(maze[x + 1, y]);
                    }
                    else if (x % 2 == 0 && y % 2 == 1) // 水平牆
                    {
                        if (y > 0) maze[x, y].neighbor.Add(maze[x, y - 1]);
                        if (y < height - 1) maze[x, y].neighbor.Add(maze[x, y + 1]);
                    }

                    if (maze[x, y].neighbor.Count == 2)
                    {
                        walllist.Add(maze[x, y]);
                    }
                }
            }
        }
    }
}
