using UnityEngine;
using UnityEngine.AI; // 必須引入 AI 命名空間

[RequireComponent(typeof(NavMeshAgent))]
public class Playerctrl : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // 防止 Agent 用 3D 的方式旋轉你的 2D Sprite，並鎖定在 XY 平面上
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        // 偵測滑鼠左鍵點擊
        if (Input.GetMouseButtonDown(0))
        {
            // 將滑鼠的螢幕座標轉換為世界座標
            Vector3 mousePos = Input.mousePosition;
            
            // 如果使用的是正交攝影機 (Orthographic)，這樣轉就能抓到正確的 XY 座標
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            
            // 強制將 Z 軸歸零，確保目標點與 NavMesh (通常在 Z=0) 同一個平面
            worldPos.z = 0f; 

            // 設定目的地，Agent 就會自動計算路徑並走過去
            agent.SetDestination(worldPos);
        }
    }
}
