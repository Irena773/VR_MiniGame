using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject RankingCanvas;

    GameObject OculustimerText;
    GameObject OculuspointText;
    GameObject DisplaytimerText;
    GameObject DisplaypointText;
    GameObject hpGauge;

    public static float time = 90;
    public static int point = 0;

   
    void Start()
    {
        this.OculustimerText = GameObject.Find("OculusTime");
        this.DisplaytimerText = GameObject.Find("DisplayTime");
        this.OculuspointText  = GameObject.Find("OculusPoint");
        //this.hpGauge = GameObject.Find("HP");


    }

    public static bool thereResult = false;

    public bool getThereResult()
    {
        return thereResult;
    }

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            this.OculustimerText.GetComponent<Text>().text = "残り" + time.ToString("F1") + "秒";
        }

        this.OculuspointText.GetComponent<Text>().text = point.ToString("F1") + "ポイント";

        if (time <= 0 && thereResult == false)
        {
            RankingCanvas.SetActive(true);
            this.OculustimerText.GetComponent<Text>().text = "おわりぷい！";
            thereResult = true;
        }       
    }
}
