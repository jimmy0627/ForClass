using UnityEngine;

public class spwan_borad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject board;
    void Start()
    {
        Vector3 pos = new Vector3(-1.5f, 2, 0); 
        while (pos.y>-2)
        {
            while (pos.x < 3.5f)
            {
                Instantiate(board, pos, Quaternion.identity);
                pos.x += 0.8f;
            }
            pos.y -= 1;
            pos.x = -1.5f;
        }
    }
}
