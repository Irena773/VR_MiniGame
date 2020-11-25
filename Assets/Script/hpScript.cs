using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hpScript : MonoBehaviour{


    public Slider hpSlider;
    public Text hpText;
    float hp = 200; 
   
    void Start()
    {
        hpSlider = GameObject.Find("Slider").GetComponent<Slider>();
        hpSlider.maxValue = hp;//200が代入されている
        hpSlider.value = hp;//現在の値を200にした

        hpText = GameObject.Find("HPText").GetComponent<Text>();
        hpText.text = hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == " Enemy")
        {
            Debug.Log("攻撃だあ");
            hp -= 10f;
            hpSlider.value = hp;
            hpText.text = hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hp -= 10f;
            hpSlider.value = hp;
            hpText.text = hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
        }
    }
}
