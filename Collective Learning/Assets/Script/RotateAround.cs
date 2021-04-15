using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject cube;
    public float deg;
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(90, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion q1 = Quaternion.AngleAxis(10, Vector3.up);
        //Vector3 pos = cube.transform.position - transform.position;
        //Vector3 newP = q1 * pos;
        //cube.transform.position = newP + transform.position;

        //Quaternion q1 = Quaternion.AngleAxis(deg, Vector3.up);
        //Vector3 pos = q1 * transform.forward * 5;
        //cube.transform.position = pos + transform.position;
        //Vector3 look = transform.position - cube.transform.position;
        //Debug.DrawRay(cube.transform.position, look);
        //cube.transform.forward = look;


        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, deg, transform.rotation.eulerAngles.z);
        transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, deg, 0);
    }
}
