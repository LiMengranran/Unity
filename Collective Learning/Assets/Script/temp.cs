using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        g.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject woc = g.transform.gameObject;
            woc.SetActive(true);
            woc.transform.position = new Vector3(0, 0, 0);
        }
    }
}
