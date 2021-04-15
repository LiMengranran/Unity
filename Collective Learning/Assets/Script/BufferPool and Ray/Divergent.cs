using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divergent : MonoBehaviour
{
    public int deg;
    private GameObject bullet;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {

            //if (time > 3)
            //{
            //for (int i = 0; i < 8; i++)
            //{
            //    Vector3 Ray = Quaternion.Euler(0, -30 + i * 10, 0) * transform.forward;
            //    //Vector3 dir = Ray ;
            //    //Debug.DrawRay(transform.position, Ray * 10);
            //    GameObject go = Instantiate<GameObject>(bullet);
            //    go.transform.position = transform.position;
            //    go.transform.rotation = Quaternion.LookRotation(Ray);
            //}
            for (int i = 0; i < 3; i++)
            {
                GameObject go = null;
                Vector3 Ray = Quaternion.Euler(0, i * 10, 0) * transform.forward; //角度发射
                if (God.god.GetBulletPool().transform.childCount > 0) //判断用缓冲池的还是再克隆
                {
                    //God.god.GetBulletPool().transform.GetChild(0).gameObject.SetActive(true);
                    go = God.god.GetBulletPool().transform.GetChild(0).gameObject;
                    go.transform.parent = null;
                    go.SetActive(true);
                }
                else
                {
                    go = Instantiate<GameObject>(bullet);
                }
                go.transform.position = transform.position;
                go.transform.rotation = Quaternion.LookRotation(Ray);
            }
            time = 0;
        }
        //Quaternion p = Quaternion.Euler(0, -deg, 0);

        //}
    }
}
