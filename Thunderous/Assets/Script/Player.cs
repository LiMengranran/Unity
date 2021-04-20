using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    RoleInfo info;

    //GameObject BulletPool;
    //GameObject bullet;
    //Transform Emitter;
    ////private void Awake()
    ////{

    ////}
    void Start()
    {
        info = transform.GetComponent<RoleInfo>();
    }

    private void Update()
    {
        if (!God.god.IsStartGame)
            return;
        //第二种限制的方法
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 40 * -h);
        transform.Translate(h * Time.deltaTime * info.Speed, 0, v * Time.deltaTime * info.Speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, God.god.worldPosLeftBottom.x, God.god.worldPosTopRight.x),
                                         transform.position.y,
                                         Mathf.Clamp(transform.position.z, God.god.worldPosLeftBottom.y, God.god.worldPosTopRight.y));

        if (Input.GetKey(KeyCode.J) && info.Timer(info.ShootTiming, info.ShootCD))
        {
            info.Shoot();
        }

    }
}
