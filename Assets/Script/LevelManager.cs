using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LSC
{
    public class LevelManager : MonoBehaviour
    {
        [Header("等級與經驗值介面")]
        public TextMeshProUGUI textLv;
        public TextMeshProUGUI textExp;
        public Image imgExp;
        [Header("等級上限"), Range(0, 500)]
        public int lvMax = 100;

        private int lv = 1;
        private float exp;


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

        /// <summary>
        /// 獲得經驗值
        /// </summary>
        /// <param name="getExp">取得經驗值的浮點數</param>
        public void GetExp(float getExp)
        {
            exp += getExp;

            print($"<color = yellow>當前經驗值:{exp}</color>");

            //如果 經驗值 >= 當前等級需求 並且 等級 < 等級上限 就 升級
            if (exp >= expNeeds[lv - 1] && lv <lvMax)
            {
                exp -= expNeeds[lv - 1]; //計算多出來的經驗值
                lv++;                    //等級提升(+1)
                textLv.text = $"Lv{lv}"; //更新等級介面
            }

            textExp.text = $"{exp}/{expNeeds[lv - 1]}";
            imgExp.fillAmount = exp / expNeeds[lv - 1];

        }


    }
}
