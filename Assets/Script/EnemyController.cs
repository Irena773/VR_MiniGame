using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Tag=Player");
            GameObject director = GameObject.Find("GameDirector");          
        }

    }
   
    void Update()
    {
    }
}
