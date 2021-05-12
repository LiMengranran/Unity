using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer2 : MonoBehaviour
{
    float time;

    //void Awake()
    //{

    //}
    //void Start()
    //{

    //}
    void Update()
    {
        if (time >= 2)
        {
            BufferPool2.Instance.PushPool("Buffer2", this.gameObject);

            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}