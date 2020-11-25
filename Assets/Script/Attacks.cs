using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    GameObject cube;
    public AudioClip MagicSE;
    AudioSource aud;
    

    void Start()
    {
       
        
        this.aud = GetComponent<AudioSource>();
    }

    public void MagicGetKey()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))//Bボタンを押す
        {
            Debug.Log("Attack");
            AttackExplosion();
        }
    }

    public void AttackExplosion()
    {

        StartCoroutine("ExplosionIE");
    }

    public IEnumerator ExplosionIE()
    {
        cube = GameObject.Find("PIOPIO");
        var nowPosition = transform.position;
        var targetPosition = cube.transform.position;

        var magic = transform.Find("Magic").gameObject;

        magic.transform.position = targetPosition;

        magic.transform.Find("Explosion").gameObject.SetActive(true);
        this.aud.PlayOneShot(this.MagicSE);

        yield return new WaitForSeconds(1.2f);

        magic.transform.Find("Explosion").gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        MagicGetKey();       
    }

    
}
