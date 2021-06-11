using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayShooting : MonoBehaviour
{
    public GameObject hitMark;
    public GameObject bullet;
    void Awake()
    {

    }
    void Start()
    {

    }
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //射线
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 dir = hitInfo.point - transform.position;
                GameObject go = Instantiate(bullet);
                go.transform.position = transform.position;
                go.GetComponent<Rigidbody>().velocity = dir.normalized * 30;

                GameObject go2 = Instantiate(hitMark);
                go2.transform.position = hitInfo.point += new Vector3(0, 0.01f, 0);
                go2.transform.rotation = Quaternion.LookRotation(-hitInfo.normal);
                //hitInfo.
            }
            else
            {
                //Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 100));
                GameObject go = Instantiate(bullet);
                go.transform.position = transform.position;
                //go.GetComponent<Rigidbody>().velocity = dir.normalized * 30;
                go.GetComponent<Rigidbody>().velocity = ray.direction.normalized * 30;
            }
        }

    }

    //private void FixedUpdate()
    //{

    //}
}