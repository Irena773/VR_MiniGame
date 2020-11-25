using UnityEngine;
using System.Collections;

public class BeamShot : MonoBehaviour
{

    float timer = 0.0f;
    float effectDisplayTime = 2.0f;
    float range = 50.0f;
    int time = 2;
    Ray shotRay;
    RaycastHit shotHit;
    ParticleSystem beamParticle;
    LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        beamParticle = GetComponent<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log(beamParticle.name);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        shot();
        
        if (timer >= effectDisplayTime)
        {
            disableEffect();
        }
    }

    public void shot()
    {
        timer = 0f;
        beamParticle.Stop();
        beamParticle.Play();
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        shotRay.origin = transform.position;
        shotRay.direction = transform.forward;
        Destroy(this.gameObject, time);


        int layerMask = LayerMask.GetMask("Player");
        if (Physics.Raycast(shotRay, out shotHit, range, layerMask))
        {
            // hit 
            Debug.Log("プレイヤーはビームを食らった");
            GameObject director = GameObject.Find("OVRPlayerController");//追加
           // Collider collider = director.GetComponentInChildren<CapsuleCollider>();
            //director.GetComponent<HPbar>().OnTriggerEnter(collider);//追加            
        }
        lineRenderer.SetPosition(1, shotRay.origin + shotRay.direction * range);


    }

    private void disableEffect()
    {
        beamParticle.Stop();
        lineRenderer.enabled = false;
    }
}
