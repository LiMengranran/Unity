using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_operation : MonoBehaviour
{

    public AnimationCurve S;
    void Awake()
    {

    }
    void Start()
    {
        //InvokeRepeating("Move", 0.3f, 0.3f);
        //for (int i = 0; i < 50; i++)
        //{

        //}
        print(S.preWrapMode) ;
        print(S.postWrapMode) ;
    }
    float x;
    float z;

    bool Isadd;
    bool IsGo;

    public int temp = 1;
    void Update()
    {
        //print(Mathf.Sin(temp * Mathf.Deg2Rad));
        z++;
        x = Mathf.Sin(temp * Mathf.Deg2Rad);
        //print(temp * Mathf.Deg2Rad + "---" + x);
        transform.position = new Vector3(x * 3, 0, z * 0.1f);
        //transform.Translate(new Vector3(Isadd ? 1 : -1 * Time.deltaTime, 0, 10 * Time.deltaTime));

    }
    //void Move()
    //{
    //    print("执行");

    //    transform.position += new Vector3(1, 0, 0);

    //}
}