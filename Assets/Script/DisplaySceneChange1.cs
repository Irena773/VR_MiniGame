using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplaySceneChange1 : MonoBehaviour

{
    GameObject DisplayButtonText;
    public static bool Displayflag = false;
    // Start is called before the first frame update
    void Start()
    {
        this.DisplayButtonText = GameObject.Find("DisplayButtonText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DisplaySceneChange();
        }
    }

    public void DisplaySceneChange()
    {
        Displayflag = true;
        DisplayButtonText.GetComponentInChildren<Text>().text = "ちょっとまってぷい";
        if (Displayflag == true && Stagechange.Oculusflag == true)
        {
            Debug.Log("Go to the First");
            SceneManager.LoadScene("First");
        }

        
      

    }
}
