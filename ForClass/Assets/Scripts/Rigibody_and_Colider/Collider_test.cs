using UnityEngine;

public class Collider_test : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //當物體進入的時候，執行括號內的程式一次
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //當物體在碰撞區內的時候，每禎執行一次(類似update)
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        //當物體離開碰撞區的時候，執行括號內的程式一次        
    }

}
