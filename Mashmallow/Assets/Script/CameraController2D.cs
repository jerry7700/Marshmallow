using UnityEngine;

public class CameraController2D : MonoBehaviour
{
   
    [Header("觸發物件")]
    public Transform sec2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "玩家")
        {
            sec2.position= new Vector3(-31.6f, 7.8f,-10f);
        }
    }
}
