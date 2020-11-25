using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject pikuprefab;//piopioの仮
    public GameObject bombPrefab;
    public GameObject Beam;
    public GameObject DarkPikuPrefab;
    public GameObject PomepomePikuPrefab;
    public GameObject GhostPrefab;
    public GameObject Potion;

    public Text text;
    float delta = 0;

    public AudioClip DarkSE;
    public AudioClip PomepomeSE;
    public AudioClip PioPioSE;
    AudioSource aud;
    public static int EnemyCount;
    public int XRandom;
    int HealX_Random;
    int HealZ_Random;
    ParticleSystem particle;
   
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (new GameDirector().getThereResult() == false)
        {
            delta += Time.deltaTime;
            if (delta >= 3.0f)
            {
                delta -= 1.0f;

                GameObject Enemy;
                int EnemyNumber = Random.Range(0, 3);
                switch (EnemyNumber)
                {
                    case 0:
                        text.text = "ダークぴく出動!";
                        Enemy = Instantiate(DarkPikuPrefab) as GameObject;

                        float DarkPosition = Random.Range(-1.0f, 1.0f);

                        Enemy.transform.position = new Vector3(DarkPosition, 0.5f, 5.0f);
                        GameObject beam = Enemy.transform.Find("Beam").gameObject;
                        EnemyCount++;
                        this.aud.PlayOneShot(this.DarkSE);
                        break;


                    case 1:

                        text.text = "ぽめぽめにくたん出動!";
                        Enemy = Instantiate(PomepomePikuPrefab) as GameObject;
                        float PomepomePosition = Random.Range(-2.0f, 2.0f);
                        Enemy.transform.position = new Vector3(PomepomePosition,4.3f , 0.0f);
                        EnemyCount++;
                        this.aud.PlayOneShot(this.PomepomeSE);
                        break;


                    case 2:

                        text.text = "ゆうれいさんこっそり";
                        Enemy = Instantiate(GhostPrefab) as GameObject;
                        float[] GhostPosition = { -0.25f, 3.0f, 0.5f };
                        Enemy.transform.position = new Vector3(GhostPosition[XRandom], 1.3f, 3.5f);
                        EnemyCount++;

                        break;




                }

            }
        }
    }
}
