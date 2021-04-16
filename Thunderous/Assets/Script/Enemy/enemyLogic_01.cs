using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyLogic_01 : MonoBehaviour
{
    RoleInfo info;
    private void Awake()
    {
        info = transform.GetComponent<RoleInfo>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (!God.god.IsStartGame)
            return;

        transform.Translate(new Vector3(0, 0, -info.Speed * Time.deltaTime), Space.World);

        if (info.Timer(info.ShootTiming, info.ShootCD) && transform.position.z <= God.god.worldPosTopRight.y) //充能
        {
            info.Shoot();
        }
    }
}
