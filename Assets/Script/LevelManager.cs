using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace LSC
{
    public class LevelManager : MonoBehaviour
    {
        #region 資料


        [Header("等級與經驗值介面")]
        public TextMeshProUGUI textLv;
        public TextMeshProUGUI textExp;
        public Image imgExp;
        [Header("等級上限"), Range(0, 500)]
        public int lvMax = 100;

        private int lv = 1;
        private float exp;

        [Header("升級面板")]
        public GameObject goLevelUp;

        [Header("技能選取面板")]
        public GameObject[] gochooseSkills;

        [Header("全部技能")]
        public DataSkill[] dataSkills;

        public List<DataSkill> randomSkill = new List<DataSkill>();
        #endregion

        #region 經驗值系統

        //陣列
        public float[] expNeeds = { 100, 200, 300 }; //寫法1 量沒那麼多可以使用

        //迴圈
        [ContextMenu("更新經驗值需求表")]  // 讓我們能透過Unity屬性面板使用下列的程式
        private void UpdateExpNeeds()  //寫法2(利用迴圈) 量較多可以使用
        {
            expNeeds = new float[lvMax];

            for (int i = 0; i < lvMax; i++)
            {

                //print("迴圈:" + i);
                expNeeds[i] = (i + 1) * 100;

            }
        }
        private void LevelUp()
        {
            //時間暫停
            Time.timeScale = 0;
            goLevelUp.SetActive(true);

            //技能必須小於5
            randomSkill = dataSkills.Where(x => x.lv < 5).ToList();
            //5個技能隨機排序
            randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

            for (int i = 0; i < 3; i++)
            {
                gochooseSkills[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
                gochooseSkills[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
                gochooseSkills[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "等級Lv" + randomSkill[i].lv;

                gochooseSkills[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].iConSkill;
            }
        }

        public void clickSkillButton(int number)
        {
            //print("按下按鈕" + number);

            //該技能等級+1
            randomSkill[number].lv++;
            //按下的技能升級
            if (randomSkill[number].nameSkill == "移動速度") UpdateMoveSpeed(number);
            if (randomSkill[number].nameSkill == "武器攻擊") UpdateWeaponAttack(number);
            if (randomSkill[number].nameSkill == "武器間隔") UpdateWeaponInterval(number);
            if (randomSkill[number].nameSkill == "玩家血量") UpdatePlayerHealth(number);
            if (randomSkill[number].nameSkill == "經驗值範圍") UpdateExpRange(number);

            Time.timeScale = 1;
            goLevelUp.SetActive(false);

        }
        
        /// <summary>
        /// 獲得經驗值
        /// </summary>
        /// <param name="getExp">取得經驗值的浮點數</param>
        public void GetExp(float getExp)
        {
            exp += getExp;

            print($"<color = yellow>當前經驗值:{exp}</color>");

            //如果 經驗值 >= 當前等級需求 並且 等級 < 等級上限 就 升級
            if (exp >= expNeeds[lv - 1] && lv < lvMax)
            {
                exp -= expNeeds[lv - 1]; //計算多出來的經驗值
                lv++;                    //等級提升(+1)
                textLv.text = $"Lv{lv}"; //更新等級介面
                LevelUp();
            }

            textExp.text = $"{exp}/{expNeeds[lv - 1]}";
            imgExp.fillAmount = exp / expNeeds[lv - 1];

        }
        #endregion

        private void Awake()
        {
            controlSystem.MoveSpeed = dataSkills[4].skillValues[0];
            weaponGhost.attack = dataSkills[1].skillValues[0];
            weaponSystem.interval = dataSkills[2].skillValues[0];
            dataHealth.hp = dataSkills[3].skillValues[0];
            expStrawberry.radius = dataSkills[0].skillValues[0];
        }

        #region 升級系統

        [Header("控制系統:蘑菇")]
        public ControlSystem controlSystem;
        [Header("武器系統:蘑菇")]
        public WeaponSystem weaponSystem;
        [Header("玩家血量:玩家蘑菇")]
        public DataHealth dataHealth;
        [Header("經驗值物件:草莓")]
        public CircleCollider2D expStrawberry;
        [Header("武器:幽靈")]
        public Weapon weaponGhost;

        public void UpdateMoveSpeed(int number)
        {
            int lv = randomSkill[number].lv;
            controlSystem.MoveSpeed = randomSkill[number].skillValues[lv - 1];
        }

        public void UpdateWeaponAttack(int number)
        {
            int lv = randomSkill[number].lv;
            weaponGhost.attack = randomSkill[number].skillValues[lv - 1];
        }

        public void UpdateWeaponInterval(int number)
        {
            int lv = randomSkill[number].lv;
            weaponSystem.interval = randomSkill[number].skillValues[lv - 1];
        }

        public void UpdatePlayerHealth(int number)
        {
            int lv = randomSkill[number].lv;
            dataHealth.hp = randomSkill[number].skillValues[lv - 1];
        }

        public void UpdateExpRange(int number)
        {
            int lv = randomSkill[number].lv;
            expStrawberry.radius = randomSkill[number].skillValues[lv - 1];
        }

    }
    #endregion
}
