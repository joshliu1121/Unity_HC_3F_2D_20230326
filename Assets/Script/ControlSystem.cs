using UnityEngine;

namespace LSC
{
    public class ControlSystem : MonoBehaviour
    {
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
            //print("<color = red>這是開始事件</cplor>");

        }

        private void Update()
        {
            #region 角色移動
            //print("<color = yellow>這是更新事件</cplor>");
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rig.velocity = new Vector3(h, v, 0) * MoveSpeed; //物件物理加速度*MoveSpeed 
            #endregion
        }

    }

}
