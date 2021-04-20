using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyLogic_02 : MonoBehaviour
{
    RoleInfo info;


    float X;
    bool IsRight;
    float dis;
    private void Awake()
    {
        info = transform.GetComponent<RoleInfo>();
    }
    private void Start()
    {
        X = transform.position.x; //横向坐标
        dis = Random.Range(1, 6); //距离
        IsRight = (Random.Range(0, 2) == 1 ? false : true);
    }
    // Start is called before the first frame update
    void Update()
    {
        //print(transform.position.x);
        if (!God.god.IsStartGame)
            return;

        if (transform.position.x >= God.god.worldPosTopRight.x)
        {
            IsRight = false;
        }
        else if (transform.position.x <= God.god.worldPosLeftBottom.x)
        {
            IsRight = true;
        }

        if (transform.position.z <= God.god.worldPosTopRight.y)
        {
            Vector3 posY = new Vector3(X += (IsRight ? 0.01f * info.Speed : -0.01f * info.Speed), 0, dis) + God.god.Player.transform.position;
            transform.position = Vector3.Lerp(transform.position, posY, info.Speed * 0.1f * Time.deltaTime * Vector3.Distance(transform.position, God.god.Player.transform.position));

            info.LookPlayer(transform); //看向玩家

            //限制范围
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, God.god.worldPosLeftBottom.x, God.god.worldPosTopRight.x),
                                             transform.position.y,
                                             Mathf.Clamp(transform.position.z, God.god.worldPosLeftBottom.y, God.god.worldPosTopRight.y));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -info.Speed * Time.deltaTime), Space.World);
        }

        if (info.Timer(info.ShootTiming, info.ShootCD) && transform.position.z <= God.god.worldPosTopRight.y) //充能
        {
            info.Shoot();
        }
    }
}
