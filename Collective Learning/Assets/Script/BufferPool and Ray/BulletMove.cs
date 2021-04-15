using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float Timing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timing += Time.deltaTime;
        transform.Translate(new Vector3(0, 0, 0.5f));
        if (Timing > 3) //每两秒放进缓冲池
        {
            //transform.parent = GameObject.Find("BulletPool");
            transform.parent = God.god.GetBulletPool().transform;
            gameObject.SetActive(false);
            Timing = 0;
        }
    }
}
