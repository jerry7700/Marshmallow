using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundClick;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        deada();
    }
    /// <summary>
    /// 設定介面啟動時暫停遊戲
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        player.enabled = false;
        aud.PlayOneShot(soundClick, 2);
    }

    /// <summary>
    /// 關閉時繼續遊戲
    /// </summary>
    public void RestarGame()
    {
        Time.timeScale = 1;
        player.enabled = true;
        aud.PlayOneShot(soundClick, 2);
    }
    public void deada()
    {
        if (player.hp<=0)
        {
            player.playerdead.SetActive(true);
           
        }
    }
  
}
