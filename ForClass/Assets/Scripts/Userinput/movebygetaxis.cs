using UnityEngine;
using System.Collections;
public class movebygetaxis : MonoBehaviour
{
    public float horspeed;
    public float verspeed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 dir=new Vector3(horspeed*Input.GetAxis("Horizontal"),verspeed*Input.GetAxis("Vertical"),0);//初始化一個Vector3的資料型態，儲存我們從鍵盤上讀到的資料
        //transform.Translate(dir*Time.deltaTime);//將數值轉換成平移，需要乘上Time.deltaTime來平衡禎數
        //rb.AddForce(dir,ForceMode2D.Force);//將數值轉換成對物體施加的力
        rb.linearVelocity=dir;//將數值直接變成物體的移動速度
    }

}
