using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using static Maze_Array_Gen_H;
using Random = UnityEngine.Random;
public class Kruskal_H : MonoBehaviour
{
    public Maze_Array_Gen_H mazeGen;
    public Maze_Render_H Render;
    void Start()
    {
       mazeGen.GenerateMaze();
       Kruskal_gen();
       Render.RenderKruskalMaze(mazeGen.maze);
    }
    private void Kruskal_gen()
    {
        var shuffledWalls = mazeGen.walllist.OrderBy(x => Random.value).ToList(); // 將牆列表隨機打亂
        //以下為填空部分
        ///目標:一個能夠持續地從shuffledWalls中抽出牆，並在每次循環中檢查牆的左右是否同屬一個集合
        /// 如果不屬於同一個集合，就把牆刪除
        /// 檢查所有屬於舊集合的，把它們的集合ID改成新的集合ID
    }
}
