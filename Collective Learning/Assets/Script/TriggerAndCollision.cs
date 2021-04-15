using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAndCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.rotation.z + "|" + -transform.rotation.z);
        //print(transform.rotation + "-----" + Quaternion.Inverse(transform.rotation));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision + "进入");
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log();
        print(collision.transform.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision + "离开");
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
    }
}
