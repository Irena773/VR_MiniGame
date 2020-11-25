using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomepomePiku_Behavior : MonoBehaviour
{
    private CharacterController controller;
    public AudioClip pomepomepikuSE;
    AudioSource aud;
    private Vector3 moveDirection;
    float time = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        Invoke("Explosion", 2);//2秒後に爆発する
    }

    void Update()
    // Update is called once per frame
    {
        if (controller.isGrounded)
        { //地面についているか判定
            moveDirection.y = 8; //ジャンプするベクトルの代入    
           
        }

        moveDirection.y -= 8 * Time.deltaTime; //重力計算
      
        controller.Move(moveDirection * Time.deltaTime); //動かす処理

        if(transform.position.y <  -10  || 40 < transform.position.y)
        {
            Destroy(gameObject);
            Debug.Log("消えた");
            Debug.Log("y"+gameObject.transform.position.y);
            CardController.EnemyCount--;
        }

  
    }

    void Explosion()
    {
        Debug.Log("爆発する");
        GetComponent<ParticleSystem>().Play();
        this.aud.PlayOneShot(pomepomepikuSE);
        GameObject director = GameObject.Find("OVRPlayerController");//追加
        Collider collider = director.GetComponentInChildren<CapsuleCollider>();
        director.GetComponent<HPbar>().OnTriggerEnter(collider);//追加
        Destroy(gameObject,time);
        CardController.EnemyCount--;
    }

    void OnTriggerEnter(Collider collision) //衝突時の処理
    {

        /*if (collision.gameObject.tag == "Player")
        //タグで限定（他のオブジェクトに衝突した場合は呼び出さない
        {
            Debug.Log("爆発する");

            GetComponent<ParticleSystem>().Play();
            GameObject director = GameObject.Find("OVRPlayerController");//追加
            Collider collider = director.GetComponentInChildren<CapsuleCollider>();
            director.GetComponent<HPbar>().OnTriggerStay(collider);//追加
            CardController.EnemyCount--;
            Destroy(this.gameObject, time);


        }*/
    }


}
