using UnityEngine;

public class Player : MonoBehaviour
{
    #region 角色基本設定
    [Header("移動速度"), Range(0, 100)]
    public float Speed = 10.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public int Jump = 100;
    [Header("是否在地板上")]
    public bool OnFloor;
    [Header("跳躍音效")]
    public AudioClip JumpAud;
    [Header("判定地面位置")]
    public Vector3 offset;
    [Header("判定地面半徑")]
    public float radius = 0.3f;
    [Header("死掉畫面")]
    public GameObject GameOver;
    [Header("死掉物件")]
    public GameObject cherry;
    [Header("玩家")]
    public GameObject player;
    [Header("玩家死亡")]
    public GameObject playerdead;
    [Header("血量")]
    public float hp = 10;
    [Header("結束畫面")]
    public GameObject panelGameOver;
    [Header("勝利畫面")]
    public GameObject panelwin;


    private SpriteRenderer Spr;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    #endregion

    /// <summary>
    /// 取得玩家水平軸向值
    /// </summary>
    public float h;

    //在 Unity 內繪製圖示
    private void OnDrawGizmos()
    {
        // 圖示 . 顏色 = 顏色
        Gizmos.color = new Color(1, 0, 0, 0.35f);
        //圖示 . 繪製球體(中心點，半徑)
        Gizmos.DrawSphere(transform.position + offset, radius);
    }

    private void Update()
    {
        GetHorizontal();
        Move();
        Jumpz();
        attack();
        
    }

    private void Start()
    {
        //剛體欄位=取得元件<剛體>()
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        Spr = GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// 取得水平軸向
    /// </summary>
    private void GetHorizontal()
    {
        //輸入.取得軸向("水平")
        h = Input.GetAxis("Horizontal");
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //剛體.加速度=二維(水平*速度，原本加速度的Y)
        Rig.velocity = new Vector2(h * Speed, Rig.velocity.y);
        //如果 玩家 按下 D 或者 右鍵 就執行{內容}
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform 此腳本同一層的Transform元件
            //Rotation 角度在程式是localEulerAngles
            transform.localEulerAngles = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        //設定跑步動畫 水平不等於0
        Ani.SetBool("跑步開關", h != 0);
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jumpz()
    {
        //OnFloor 等於 OnFloor==true
        //按下W 或 上 執行跳躍 並且 在地面上
        // onfloor || 兩邊都要
        if (OnFloor && Input.GetKeyDown(KeyCode.W) || OnFloor && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //AddForce = 增加推力
            Rig.AddForce(new Vector2(0, Jump));
            Ani.SetTrigger("跳躍開關");
        }
        //碰撞物件 = 2D 物理.覆蓋圖形(中心點，半徑，圖層)
        // 1<<圖層
        Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, radius, 1 << 8);

        if (hit)
        {
            OnFloor = true;
        }
        else
        {
            OnFloor = false;
        }
        //動畫控制器.設定浮點數
        Ani.SetFloat("跳躍", Rig.velocity.y);
        Ani.SetBool("是否在地面上", OnFloor);

    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void attack()
    {
        // 如果按下左鍵 (手機為觸控)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ani.SetTrigger("攻擊開關");
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "碰撞器")
        {
            hp = -1;
            panelGameOver.SetActive(true);
            player.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "勝利")
        {
           
            panelwin.SetActive(true);
            enabled = false;
        }
    }


    public void Damage(float getDamge)
    {
        hp -= getDamge;                 // 遞減
        if (hp <= 0) player.SetActive(false);    // 如果 血量 <= 0 就 死亡
    }
}
