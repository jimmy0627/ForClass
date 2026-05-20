using System.Collections.Generic;
using UnityEngine;
using static Maze_Array_Gen;
using System.Collections;
using NavMeshPlus.Components;

public class Recursive_Backtrack : MonoBehaviour
{
    public Maze_Array_Gen mazeGen;
    public Maze_Render Render;
    public NavMeshSurface navMeshSurface;
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
    
        startCell.visited = true;
        stack.Push(startCell); // 把起點推入堆疊

        // 2. 當堆疊不是空的，就一直找下去
        while (stack.Count > 0)
        {
            // 偷看現在堆疊最頂端的格子 (目前所在位置)
            Cell currentCell = stack.Peek(); 

            // 找出所有未造訪的合法鄰居
            List<(int x, int y, (int, int) dir)> unvisitedNeighbors = GetUnvisitedNeighbors(currentCell);

            if (unvisitedNeighbors.Count > 0)
            {
                // 【情況 A：有路可走 -> 推進】
                // 隨機挑選一個鄰居
                var chosen = unvisitedNeighbors[Random.Range(0, unvisitedNeighbors.Count)];
                Cell nextCell = mazeGen.maze[chosen.x, chosen.y];
                var dir = chosen.dir;
                if (dir == (0, 1)) // top
                {
                    currentCell.walls[0] = false;
                    nextCell.walls[2] = false;
                }
                else if (dir == (0, -1)) // bottom
                {
                    currentCell.walls[2] = false;
                    nextCell.walls[0] = false;
                }
                else if (dir == (1, 0)) // right
                {
                    currentCell.walls[3] = false;
                    nextCell.walls[1] = false;
                }
                else if (dir == (-1, 0)) // left
                {
                    currentCell.walls[1] = false;
                    nextCell.walls[3] = false;
                }

                nextCell.visited = true;
                stack.Push(nextCell); // 把新格子推入堆疊，往前邁進！
            }
            else
            {
                stack.Pop(); 
            }
        }
    }
    private List<(int x, int y, (int, int) dir)> GetUnvisitedNeighbors(Cell cell)
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

