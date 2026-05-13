using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Maze_Array_Gen_H;

public class Recursive_Backtrack_H : MonoBehaviour
{
    public Maze_Array_Gen_H mazeGen;
    public Maze_Render_H Render;
    private (int, int)[] directions = { (0,1), (0,-1), (1,0), (-1,0) }; // top, bottom, right, left
    void Start()
    {
       mazeGen.GenerateMaze();
       Cell startCell = mazeGen.maze[Random.Range(0, mazeGen.width), Random.Range(0, mazeGen.height)];
       RecursiveBacktrack(startCell);
       Render.RenderMaze(mazeGen.maze);
    }

    private void RecursiveBacktrack(Cell startCell)
    {
        //填空
        Stack<Cell> stack = new Stack<Cell>();
        // 以下為填空
        // 目標:將一個格子推入Stack，並標記為已造訪
        // 進入一個迴圈，利用GetUnvisitedNeighbors方法找出目前格子所有未造訪的合法鄰居
        // 如果有未造訪的鄰居，就隨機挑選一個，把它的牆打通，並把它推入Stack
        // 如果沒有未造訪的鄰居，就從Stack彈出一個格子，回到上一個位置繼續找路
        // 當堆疊不是空的，就一直找下去
        // 如果Stack為空跳出迴圈，表示整個迷宮已經生成完成
    }
    private List<(int x, int y, (int, int) dir)> GetUnvisitedNeighbors(Cell cell) // 找出所有未造訪的合法鄰居
    {
        List<(int, int, (int, int))> neighbors = new List<(int, int, (int, int))>();
        foreach (var dir in directions)
        {
            int nx = cell.position.Item1 + dir.Item1;
            int ny = cell.position.Item2 + dir.Item2;
            if (nx >= 0 && nx < mazeGen.width && ny >= 0 && ny < mazeGen.height)
            {
                if (!mazeGen.maze[nx, ny].visited)
                {
                    neighbors.Add((nx, ny, dir));
                }
            }
        }
        return neighbors;
    }
}

