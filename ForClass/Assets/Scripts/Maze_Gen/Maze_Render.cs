using UnityEngine;
using UnityEngine.Tilemaps;

public class Maze_Render : MonoBehaviour
{
    public Tilemap mazeTilemap;
    public TileBase wallPrefab;
    public TileBase pathPrefab;
    public void RenderMaze(Maze_Array_Gen.Cell[,] maze)
    {
        for (int x = 1; x < maze.GetLength(0)*2; x++)
        {
            for (int y = 1; y < maze.GetLength(1)*2; y++)
            {
                mazeTilemap.SetTile(new Vector3Int(x, y, 0), wallPrefab);
            }
        }
        for(int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                var cell = maze[x, y];
                // 預計留空
                // 計算在 Tilemap 上的中心座標
                int tileX = x * 2 + 1;
                int tileY = y * 2 + 1;
                if (!maze[x, y].walls[0]) // top
                {
                    mazeTilemap.SetTile(new Vector3Int(tileX, tileY+1, 0), pathPrefab);
                }
                if (!maze[x, y].walls[1]) // left
                {
                    mazeTilemap.SetTile(new Vector3Int(tileX-1, tileY, 0), pathPrefab);
                }
                if (!maze[x, y].walls[2]) // bottom
                {
                    mazeTilemap.SetTile(new Vector3Int(tileX, tileY-1, 0), pathPrefab);
                }
                if (!maze[x, y].walls[3]) // right
                {
                    mazeTilemap.SetTile(new Vector3Int(tileX+1, tileY, 0), pathPrefab);
                }
                mazeTilemap.SetTile(new Vector3Int(tileX, tileY, 0), pathPrefab);
            }
        }
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
                    mazeTilemap.SetTile(new Vector3Int(x, y, 0), pathPrefab);
                }
                else
                {
                    mazeTilemap.SetTile(new Vector3Int(x, y, 0), wallPrefab);
                } 
            }
        }
    }
}
