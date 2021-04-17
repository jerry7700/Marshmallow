using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

public class ScenesController : MonoBehaviour
{
    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundClick;

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        // 音效來源.播放一次(音效，音量)
        aud.PlayOneShot(soundClick, 2);
        // 延遲呼叫("方法名稱"，延遲秒數)
        Invoke("DelayStartGame", 1f);
    }

    /// <summary>
    /// 返回選單
    /// </summary>
    public void BackToMenu()
    {
        Time.timeScale = 1;
        aud.PlayOneShot(soundClick, 2);
        Invoke("DelayBackToMenu", 1f);
    }

    
    /// <summary>
    /// 延遲開始遊戲
    /// </summary>
    private void DelayStartGame()
    { 
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 延遲返回選單
    /// </summary>
    private void DelayBackToMenu()
    {
        SceneManager.LoadScene("開始畫面");
    }

}
