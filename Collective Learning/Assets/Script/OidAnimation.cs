using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OidAnimation : MonoBehaviour
{
    //void Awake()
    //{

    //}

    Animation aa;
    void Start()
    {
        aa = gameObject.GetComponent<Animation>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //aa.PlayQueued("OldAnimation");
            aa.Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            aa.PlayQueued("OldAnimation 1");
        }
    }
}