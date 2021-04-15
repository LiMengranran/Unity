using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float Displacement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        Displacement += h;
        Displacement = Mathf.Clamp(Displacement, -8, 8);
        //transform.Translate(h * 0.5f, 0, 0);
        transform.position = new Vector3(Displacement, transform.position.y, transform.position.z);
    }
}
