using LSC;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
    #region 資料
    [Header("血條")]
    public Image imgHp;
    [Header("控制系統")]
    public ControlSystem controlSystem;
    [Header("結束面板")]
    public GameObject goFinal;
    #endregion


    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        imgHp.fillAmount = hp / hpMax;

        AudioClip sound = SoundManager.instance.playerHit;
        SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
    }

    //玩家死亡後不能動
    protected override void Dead()
    {
        //1.關閉控制系統
        controlSystem.enabled = false;

        //2.彈出結束畫面
        goFinal.SetActive(true);

        AudioClip sound = SoundManager.instance.playerDead;
        SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
    }
}


