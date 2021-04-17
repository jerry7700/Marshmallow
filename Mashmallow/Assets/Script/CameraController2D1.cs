using UnityEngine;

public class CameraController2D1 : MonoBehaviour
{
    [Header("觸發物件")]
    public Transform sec1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "玩家")
        {
            sec1.position = new Vector3(3.82f, 7.8f, -10f);
        }
    }
}
