using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 155;
    int currentHp;
    //Sliderを入れる
    public Slider slider;
    public Text hpText;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
        //hpText = GameObject.Find("HPText").GetComponent<Text>();
        //hpText.text = currentHp.ToString() + "/" + maxHp.ToString();
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    public void OnTriggerEnter(Collider collider)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Player")
        {
            Debug.Log("当たったよ");
            //ダメージは1～100の中でランダムに決める。
            int damage = 5;
            

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            slider.value = currentHp;
            hpText.text = currentHp.ToString() + "/" + maxHp.ToString();
            

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp; ;
            //Debug.Log("slider.value : " + slider.value);
        }
    }
}