using UnityEngine;  //引用 Unity 引擎函式庫
using UnityEngine.SceneManagement;

namespace LSC 
{
    //腳本名稱:必須跟左上角檔案名稱一樣 包括大小寫 不能有空格
    public class MenuManager : MonoBehaviour
    {
        // 方法Method
        // 語法: 修飾詞 傳回類型 方法名稱()
        // { 方法程式內容 }
        public void StartGame() 
        {
            Time.timeScale = 1;
            // 載入場景的API
            SceneManager.LoadScene("遊戲場景");
        }

        public void QuitGame() 
        {
            // 離開遊戲的API
            Application.Quit();
        }
    }
}
