using System.Collections;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Maze_Render : MonoBehaviour
{
    [Header("Tilemaps 設置")]
    public Tilemap wallTilemap; // 原本的 mazeTilemap 拿來放牆
    public Tilemap pathTilemap; // 新增：專門用來放路

    [Header("Tiles 設置")]
    public TileBase wallPrefab;
    public TileBase pathPrefab;

    [Header("NavMesh 設置")]
    public NavMeshSurface navMeshSurface; // 尋路表面元件
public void RenderMaze(Maze_Array_Gen.Cell[,] maze)
    {
        // 1. 先把整個範圍鋪滿牆壁 (畫在 wallTilemap)
        for (int x = 1; x < maze.GetLength(0) * 2; x++)
        {
            for (int y = 1; y < maze.GetLength(1) * 2; y++)
            {
                wallTilemap.SetTile(new Vector3Int(x, y, 0), wallPrefab);
            }
        }

        // 2. 開始「挖路」
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                // 計算在 Tilemap 上的中心座標
                int tileX = x * 2 + 1;
                int tileY = y * 2 + 1;

                if (!maze[x, y].walls[0]) // top
                    SetPathTile(tileX, tileY + 1);

                if (!maze[x, y].walls[1]) // left
                    SetPathTile(tileX - 1, tileY);

                if (!maze[x, y].walls[2]) // bottom
                    SetPathTile(tileX, tileY - 1);

                if (!maze[x, y].walls[3]) // right
                    SetPathTile(tileX + 1, tileY);

                SetPathTile(tileX, tileY); // 中心點
            }
        }

        // 3. 地圖生成完畢，呼叫延遲烘焙
        if (navMeshSurface != null)
        {
            StartCoroutine(BakeNavMeshDelay());
        }
    }
    private void SetPathTile(int x, int y)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        // 在路徑層畫上地板
        pathTilemap.SetTile(pos, pathPrefab);
        // 把牆壁層同一個位置的牆壁「刪掉」，避免生成多餘的碰撞體
        wallTilemap.SetTile(pos, null); 
    }
    public void RenderKruskalMaze(Maze_Array_Gen.Cell[,] maze)
    {
        for(int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                var cell = maze[x, y];
                if (cell.type == 0)
                {
                    pathTilemap.SetTile(new Vector3Int(x, y, 0), pathPrefab);
                }
                else
                {
                    wallTilemap.SetTile(new Vector3Int(x, y, 0), wallPrefab);
                } 
            }
        }
    }
    private IEnumerator BakeNavMeshDelay()
    {
        yield return new WaitForEndOfFrame();
        navMeshSurface.BuildNavMeshAsync();
        Debug.Log("迷宮尋路網格烘焙完成！");
    }
}
