using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusPlayerController : MonoBehaviour
{
    int healbreaktime = 2;
    public AudioClip SwordSE;
    public AudioClip HealSE;
    AudioSource aud;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Tag=Enemy");
            GetComponent<ParticleSystem>().Play();
            this.aud.PlayOneShot(this.SwordSE);
            Destroy(other.gameObject);

            GameDirector.point += 10;
            CardController.EnemyCount--;

        }

       
    }
}
