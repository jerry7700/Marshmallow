using UnityEngine;

public class cherry : MonoBehaviour
{
   
    private Animator Ani;

    private void Start()
    {
        //剛體欄位=取得元件<剛體>()
        Ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "玩家")
        {
            Ani.SetTrigger("掉落");
        }
    } 
}
