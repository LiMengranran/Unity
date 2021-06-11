using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncLoad : MonoBehaviour
{
    void Awake()
    {

    }
    void Start()
    {
        print("111");
        StartCoroutine("PrintA");
        print("222");
    }
    void Update()
    {

    }
    IEnumerator PrintA()
    {
        print("PrintA");
        yield return new WaitForSeconds(3); //延迟几秒time
        StartCoroutine("PrintB");
        //AsyncLoad
    }
    IEnumerator PrintB()
    {
        print("PrintB");
        yield return new WaitForSeconds(1);
        print("PrintB----2");

    }
}