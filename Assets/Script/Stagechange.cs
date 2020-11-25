using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stagechange : MonoBehaviour
{
    GameObject OculusButtonText;
    public static bool Oculusflag = false;
    // Start is called before the first frame update
    void Start()
    {
        this.OculusButtonText = GameObject.Find("OculusButtonText");
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.RawButton.A)))
        {
            SceneManager.LoadScene("Second");
        } 
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StartButton")
        {
            Oculusflag= true;
            OculusButtonText.GetComponentInChildren<Text>().text = "ちょっとまってぷい";

            if(Oculusflag == true && DisplaySceneChange1.Displayflag == true)
            {
                Debug.Log("Go to the Next Stage");
                SceneManager.LoadScene("Second");
            }
            
        }
    }*/
}
