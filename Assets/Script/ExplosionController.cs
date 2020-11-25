using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    int time = 1;
    public AudioClip DarkSE;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy" && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("Tag=Enemy");
            Debug.Log("ダークぴくたんを倒した");
            Destroy(other.gameObject,time);
            this.aud.PlayOneShot(this.DarkSE);
            GameDirector.point += 20;

        }
    }
}
