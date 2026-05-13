using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using static Maze_Array_Gen;
using Random = UnityEngine.Random;
public class Kruskal : MonoBehaviour
{
    public Maze_Array_Gen mazeGen;
    public Maze_Render Render;
    void Start()
    {
       mazeGen.GenerateMaze();
       Kruskal_gen();
       Render.RenderKruskalMaze(mazeGen.maze);
    }
    private void Kruskal_gen()
    {
        //填空
        var shuffledWalls = mazeGen.walllist.OrderBy(x => Random.value).ToList();
        foreach (var chosenWall in shuffledWalls)
        {
            Cell roomA = chosenWall.neighbor[0];
            Cell roomB = chosenWall.neighbor[1];
            if (roomA.setID != roomB.setID)
            {
                chosenWall.type = 0;

                int newID = math.min(roomA.setID, roomB.setID);
                int oldID = math.max(roomA.setID, roomB.setID);
                foreach (var cell in mazeGen.maze)
                {
                    if (cell.setID == oldID)
                    {
                        cell.setID = newID;
                    }
                }
            }
        }
    }
}
