using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void FixedUpdate()
    {
        //Vector3 dir = new Vector3(0, 1, 0);
        transform.Translate(new Vector3(0, 0.3f, 0), Space.Self);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(transform.rotation);
        //Debug.Log(Quaternion.Inverse(transform.rotation));
        //transform.rotation = Quaternion.Inverse(transform.rotation);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 180);

        //transform.up = -transform.up;

        //transform.up = new Vector3(1 - Mathf.Abs(transform.up.x), 1 - Mathf.Abs(transform.up.y), 0);
        //print(transform.up);
    }


}

