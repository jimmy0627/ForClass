using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static Maze_Array_Gen_H;

public class WFC_H : MonoBehaviour
{
    public Maze_Array_Gen_H mazeGen;
    public Maze_Render_H Render;

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
            //以下為填空部分
                ///目標:持續地找到熵最小的格子，並從它的celltypes中隨機選擇一個類型
                /// 選定後，將這個格子的celltypes縮減為只有選定的類型
                /// 接著根據選定的類型更新鄰居格子的celltypes，剔除掉不相容的類型
                /// 不相容的定義是：如果目前格子在某個方向有門，那麼鄰居在相對應的方向也必須有門；如果沒有門，也必須沒有門
                /// 例如，如果目前格子上方有門，那麼上方鄰居的下方也必須有門；如果目前格子右方沒有門，那麼右方鄰居的左方也必須沒有門
                /// 持續這樣進行，直到所有格子的celltypes都只剩下一種可能，或者沒有格子了
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
    private Cell getMinEntropyCell() // 找出熵最小的格子
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
