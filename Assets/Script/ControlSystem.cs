using UnityEngine;

namespace LSC
{
    public class ControlSystem : MonoBehaviour
    {
        // ctrl + k + s 叫菜單能生成#region

        #region 宣告
        [Header("移動速度")]   //標題
        [Range(0.5f, 10.0f)]   //範圍
        //欄位
        //語法: 修飾詞 資料類型 欄位名稱 = 預設;
        //作用: 儲存資料       ex移動速度、跳躍高度、等級、經驗等等
        public float MoveSpeed = 3.5f;

        [Header("2D 剛體")]
        public Rigidbody2D rig;

        [Header("動畫控制器")]
        public Animator ani;

        [Header("跑步參數")]
        public string parRun = "開關跑步";
        #endregion

        private void Awake()
        {
            //print("哈囉");
            //print(" 1+2 "); //不能運算
            //print($"{ 1 + 2}"); //可以運算

        }

        private void Start()
        {
            //print("<color = red>這是開始事件</color>");

        }

        private void Update()
        {
            MoveAndAnimation();
        }

        #region 角色移動和動畫
        private void MoveAndAnimation()
        {
            //print("<color = yellow>這是更新事件</color>");
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rig.velocity = new Vector3(h, v, 0) * MoveSpeed; //物件物理加速度*MoveSpeed 

            //按下 A 輸出true 沒有按下則輸出false
            //print(Input.GetKeyDown(KeyCode.A));

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //print("玩家按下左邊");

                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                transform.eulerAngles = new Vector3(0, 180, 0);

            }

            //如果 h > 0 就開啟跑步動畫 或者 h < 0 或者 v > 0 或者 v < 0
            //ani.SetBool(parRun, h > 0 || h < 0  || v > 0 || v < 0);

            //設置動畫(動畫參數 , 水平軸h 不等於 0 或者 垂直軸v 不等於 0);
            ani.SetBool(parRun, h != 0 || v != 0);
        }
        #endregion
    }

}
