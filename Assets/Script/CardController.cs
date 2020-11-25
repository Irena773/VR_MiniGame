using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{

    float delta = 0;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.particle = GetComponent<ParticleSystem>();
       
    }

    public GameObject pikuprefab;//piopioの仮
    public GameObject bombPrefab;
    public GameObject Beam;
    public GameObject DarkPikuPrefab;
    public GameObject PomepomePikuPrefab;
    public GameObject GhostPrefab;
    public GameObject Potion;

    public Text text;

    public AudioClip DarkSE;
    public AudioClip PomepomeSE;
    public AudioClip PioPioSE;
    AudioSource aud;
    public static int EnemyCount;
    public int XRandom;
    int HealX_Random;
    int HealZ_Random;
    ParticleSystem particle;

    public void GetStackInfos()
    {
        //一つ前のスタックを取得
        StackFrame callerFrame = new StackFrame(1);
        //メソッド名
        string methodName = callerFrame.GetMethod().Name;
        //クラス名
        string className = callerFrame.GetMethod().ReflectedType.FullName;

        //以下にクラス名とメソッド名を使う処理を記述
        UnityEngine.Debug.Log("method: " + methodName);
    }

    void Update()
    {
        delta += Time.deltaTime;
        if(delta >= 30.0f)
        {
            delta -= 30.0f;
            GameObject potion = Instantiate(Potion) as GameObject;
            HealX_Random = Random.Range(-1, 1);
            HealZ_Random = Random.Range(-5, -2);
            potion.transform.position = new Vector3(HealX_Random, -1, HealZ_Random);

        }

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            UnityEngine.Debug.Log("A pushed");

            GetStackInfos();
        }
    }
    public void OnClick(int number)
    {
        GameObject Enemy;
     
        switch (number)
        {
            case 0:                
                text.text = "ダークぴく出動!";
                Enemy = Instantiate(DarkPikuPrefab) as GameObject;
                
                float DarkPosition = Random.Range(-3.0f, 3.0f);
                Enemy.transform.position = new Vector3(DarkPosition,0.9f,-0.39f);
                GameObject beam = Enemy.transform.Find("Beam").gameObject;        
                EnemyCount++;
                this.aud.PlayOneShot(this.DarkSE);
                break;


            case 1:
                
                text.text = "ぽめぽめにくたん出動!";
                Enemy = Instantiate(PomepomePikuPrefab) as GameObject;

                float[] PomepomePosition = {-2.8f, 0.6f, 2.1f};
                XRandom = Random.Range(0, 2);
                Enemy.transform.position = new Vector3(PomepomePosition[XRandom], 4, -0.9f);                              
                EnemyCount++;
                this.aud.PlayOneShot(this.PomepomeSE);
                break;


            case 2:
                
                text.text = "ゆうれいさんこっそり";
                Enemy = Instantiate(GhostPrefab) as GameObject;
                float[] GhostPosition = { -0.46f, 1.48f, -1.77f};              
                Enemy.transform.position = new Vector3(GhostPosition[XRandom], -0.1f, -9f);           
                EnemyCount++;
                
                break;


            case 3:
   
                text.text = "ぴおぴおいく！";
                Enemy = Instantiate(pikuprefab) as GameObject;
                Enemy.transform.position = new Vector3(1, 0, 1);
                this.aud.PlayOneShot(this.PioPioSE);
                break;

        }
    }
}
