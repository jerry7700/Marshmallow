using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("觸發物件")]
    public GameObject obj;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "玩家")
        {
            obj.SetActive(true);
        }
    }
}
