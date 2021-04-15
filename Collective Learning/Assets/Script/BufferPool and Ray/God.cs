using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    GameObject pool;
    public static God god;
    private void Awake()
    {
        god = this;
    }
    public GameObject GetBulletPool()
    {
        if (pool == null)
        {
            pool = GameObject.Find("BulletPool");
        }
        return pool;
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
