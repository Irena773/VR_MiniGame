using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIOPIO : MonoBehaviour  
{
    GameObject CameraObj;//カメラを取得
    Vector3 Camerapos;
    // Start is called before the first frame update
    void Start()
    {
        CameraObj = Camera.main.gameObject;
        Camerapos = CameraObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Transform Playertransform = CameraObj.transform;
        Vector3 pos = Playertransform.localPosition;
       
        transform.localPosition = pos;
    }
}
