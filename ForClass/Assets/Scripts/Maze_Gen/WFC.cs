using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static Maze_Array_Gen;

public class WFC : MonoBehaviour
{
    public Maze_Array_Gen mazeGen;
    public Maze_Render Render;

    [Header("生成設定")]
    public Transform mazeParent; // 將父物件設定移到這裡
    public float cellSize = 1f;  // 格子大小
    private List<GameObject> celltypes;  //所有可能的格子
    private Cell[,] maze; // 存放格子資訊的二維陣列
    private (int,int)[] Directions = { (0,1), (0,-1), (1,0), (-1,0) }; // 上、下、右、左的方向向量

    void Start()
    {
        mazeGen.GenerateMaze();
        celltypes = mazeGen.celltypes; // 從 Maze_Array_Gen 取得 celltypes
        maze = mazeGen.maze; // 從 Maze_Array_Gen 取得 maze
        RunWFC();
    }

    void RunWFC()
    {
        Cell starcell = maze[Random.Range(0, mazeGen.width), Random.Range(0, mazeGen.height)];
        starcell.celltypes = new List<GameObject> { celltypes[Random.Range(0, celltypes.Count)] }; // 隨機選擇一個格子類型作為起點
        while (true)
        {
            Cell minCell = getMinEntropyCell();
            if (minCell == null) break; // 如果沒有格子了，結束迴圈
            // 找到熵最小的，再隨機挑一個類型
            GameObject chosenType = minCell.celltypes[Random.Range(0, minCell.celltypes.Count)];
            minCell.celltypes = new List<GameObject> { chosenType }; // 只保留選定的類型
            // 更新鄰居的格子類型
            foreach (var dir in Directions)
            {
                int newX = minCell.position.Item1 + dir.Item1;
                int newY = minCell.position.Item2 + dir.Item2;
                //(newX,newY) 是鄰居的位置
                if (newX >= 0 && newX < mazeGen.width && newY >= 0 && newY < mazeGen.height)
                {
                    Cell neighbor = maze[newX, newY];
                    WFC_Road roadComponent = chosenType.GetComponent<WFC_Road>();
                    // 根據選定的類型更新鄰居的 celltypes
                    if (dir == (0,1)) // 上
                    {
                        neighbor.celltypes.RemoveAll(type => type.GetComponent<WFC_Road>().bottomdoor != roadComponent.topdoor); //剔除鄰居的下與目前選定的上不相容的類型
                    }
                    else if (dir == (0,-1)) // 下
                    {
                        neighbor.celltypes.RemoveAll(type => type.GetComponent<WFC_Road>().topdoor != roadComponent.bottomdoor); //剔除鄰居的上與目前選定的下不相容的類型
                    }
                    else if (dir == (-1,0)) // 左
                    {
                        neighbor.celltypes.RemoveAll(type => type.GetComponent<WFC_Road>().rightdoor != roadComponent.leftdoor); //剔除鄰居的右與目前選定的左不相容的類型
                    }
                    else if (dir == (1,0)) // 右
                    {
                        neighbor.celltypes.RemoveAll(type => type.GetComponent<WFC_Road>().leftdoor != roadComponent.rightdoor); //剔除鄰居的左與目前選定的右不相容的類型
                    }
                }
            }
        }
        //生成結果
        for (int x = 0; x < mazeGen.width; x++)
        {
            for (int y = 0; y < mazeGen.height; y++)
            {
                Cell cell = maze[x, y];
                Vector2 position = new Vector2(x * cellSize, y * cellSize);
                if (cell.celltypes.Count > 0)
                {
                    GameObject prefab = cell.celltypes[0]; // 由於已經只剩一種可能，所以直接取第一個
                    Instantiate(prefab, position, Quaternion.identity, mazeParent);
                }
                else
                {
                    Instantiate(celltypes[0], position, Quaternion.identity, mazeParent); // 如果沒有可能的類型了，就放一個預設的空白
                }
                
            }
        }
    }
    private Cell getMinEntropyCell()
    {
        int minEntropy = int.MaxValue;
        Cell minCell = null;
        foreach (var item in maze)
        {
            if (item.celltypes.Count > 1 && item.celltypes.Count < minEntropy)
            {
                minEntropy = item.celltypes.Count;
                minCell = item;
            }    
        }
        return minCell;
    }
}
