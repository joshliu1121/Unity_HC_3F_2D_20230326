using UnityEngine;  //�ޥ� Unity �����禡�w
using UnityEngine.SceneManagement;

namespace LSC 
{
    //�}���W��:�����򥪤W���ɮצW�٤@�� �]�A�j�p�g ���঳�Ů�
    public class MenuManager : MonoBehaviour
    {
        // ��kMethod
        // �y�k: �׹��� �Ǧ^���� ��k�W��()
        // { ��k�{�����e }
        public void StartGame() 
        {
            // ���J������API
            SceneManager.LoadScene("�C������");
        }

        public void QuitGame() 
        {
            // ���}�C����API
            Application.Quit();
        }
    }
}
