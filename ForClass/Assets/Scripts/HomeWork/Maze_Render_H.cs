using UnityEngine;
using UnityEngine.Tilemaps;

public class Maze_Render_H : MonoBehaviour
{
    public Tilemap mazeTilemap;
    public TileBase wallPrefab;
    public TileBase pathPrefab;
    public void RenderMaze(Maze_Array_Gen_H.Cell[,] maze)
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
                // 以下是填空部分
                // 目標:根據cell的walls陣列來決定要把pathPrefab放在哪些位置
                // 如果cell.walls[0]是false，表示這個格子上方沒有牆，就在(x*2, y*2+1)放pathPrefab
                // 反之亦然，其他如此推導
            }
        }
    }
    public void RenderKruskalMaze(Maze_Array_Gen_H.Cell[,] maze)
    {
        for(int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                //以下是填空部分
                ///目標:根據maze二維陣列中的每個格子的type來決定要放置wallPrefab還是pathPrefab
                /// 如果type是1，表示這個格子是牆，就放wallPrefab；如果type是0，表示這個格子是路，就放pathPrefab
            }
        }
    }
}
