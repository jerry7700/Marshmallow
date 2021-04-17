using UnityEngine;
using System.Collections;       // 引用 系統.集合 API

public class Dead : MonoBehaviour
{

    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 100f;
    private void Track()
    {
        Vector3 posA = target.position;                                         // 取得玩家座標
        Vector3 posB = transform.position;                                      // 取得攝影機座標
        posA.z = -10;                                                           

        posB = Vector3.Lerp(posB, posA, 0.5f * speed * Time.deltaTime);         
        transform.position = posB;                                              
    }

    // 延遲更新：在 Update 執行後才執行，追蹤
    private void LateUpdate()
    {
        Track();
    }
}
