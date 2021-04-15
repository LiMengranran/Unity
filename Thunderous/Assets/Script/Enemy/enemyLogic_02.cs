using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyLogic_02 : MonoBehaviour
{
    RoleInfo info;
    GameObject target;
    private void Awake()
    {
        info = transform.GetComponent<RoleInfo>();
        target = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    //void Update()
    //{

    //}
    private void FixedUpdate()
    {
        if (!God.god.IsStartGame)
            return;
        transform.Translate(new Vector3(0, 0, -info.Speed * Time.fixedDeltaTime), Space.World);
        //Quaternion dir = Quaternion.LookRotation(target.transform.position - transform.position);
        //transform.rotation = Quaternion.Lerp(transform.rotation, dir, 0.5f);

        if (info.Timer(info.ShootTiming, info.ShootCD) && transform.position.z <= God.god.worldPosTopRight.y) //充能
        {
            info.Shoot();
        }
    }
}
