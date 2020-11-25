using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost_Movement : MonoBehaviour
{

    public Transform target;
    public float speed = 10.0f;
    private Vector3 vec;
    public AudioClip GhostSE;
    AudioSource aud;


    void Start()
    {
        target = GameObject.Find("GameObject").transform;
        this.aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
        transform.position += transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Tag=Player");
            this.aud.PlayOneShot(this.GhostSE);
            GameObject director = GameObject.Find("OVRPlayerController");//追加
            Collider collider = director.GetComponentInChildren<CapsuleCollider>();
            director.GetComponent<HPbar>().OnTriggerEnter(collider);//追加
            Destroy(gameObject,0.1f);
            CardController.EnemyCount--;
            Debug.Log("Enemycount:" + CardController.EnemyCount);


        }


    }
}