using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FromFirstToSecond : MonoBehaviour
{
    float time = 30;
    GameObject OculustimerText;
    GameObject DisplaytimerText;
    // Start is called before the first frame update
    void Start()
    {
        this.OculustimerText = GameObject.Find("OculusTimerText");
        this.DisplaytimerText = GameObject.Find("DisplayTimerText");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.OculustimerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.DisplaytimerText.GetComponent<Text>().text = this.time.ToString("F1");
        if(time < 0)
        {
            Debug.Log("Go to the Next Stage");
            SceneManager.LoadScene("Second");
        }
    }

    
}
