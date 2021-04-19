using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyLogic_03 : MonoBehaviour
{
    RoleInfo info;

    float DazeTime;
    float dazeTiming;
    private void Awake()
    {
        info = transform.GetComponent<RoleInfo>();
        DazeTime = Random.Range(1.5f,2.6f);
    }
    // Start is called before the first frame update
    void Update()
    {
        if (!God.god.IsStartGame)
            return;
        if (transform.position.z <= God.god.worldPosTopRight.y)
        {

            BarbarbProcess();
            //限制范围
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, God.god.worldPosLeftBottom.x, God.god.worldPosTopRight.x),
                                             transform.position.y,
                                             Mathf.Clamp(transform.position.z, God.god.worldPosLeftBottom.y, God.god.worldPosTopRight.y));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -info.Speed * Time.deltaTime), Space.World);
        }

    }
    public void BarbarbProcess()
    {
        //print(dazeTiming);
        if (dazeTiming >= DazeTime)
        {
            IsAimingLine();
        }
        else
        {
            dazeTiming += Time.deltaTime;
            info.LookPlayer(transform);
        }
    }
    public void IsAimingLine()
    {
        if (info.AimingLineScale.x <= 0 && dazeTiming >= DazeTime)
        {
            info.AimingLine.SetActive(false);
            Barbarb();
        }
        else
        {
            if (info.AimingLineScale.x <= 0.1f)
            {
                info.AimingLineScale.x = 0;
            }
            info.AimingLine.transform.localScale = new Vector3(info.AimingLineScale.x -= 0.5f * Time.deltaTime, info.AimingLineScale.y, info.AimingLineScale.z);
        }

    }//瞄准 提示线条
    Vector3 BarbarbPos;
    public void Barbarb()
    {
        //BarbarbPos = transform.forward * 10;
        //print(transform.forward + "____" + BarbarbPos);
        transform.Translate(0, 0, 5 * Time.deltaTime * info.Speed);
        if (transform.position.x >= God.god.worldPosTopRight.x
         || transform.position.x <= God.god.worldPosLeftBottom.x
         || transform.position.z >= God.god.worldPosTopRight.y
         || transform.position.z <= God.god.worldPosLeftBottom.y)
        {
            info.AimingLineScale = info.Static_AimingLine;
            info.AimingLine.SetActive(true);

            dazeTiming = 0;
            BarbarbProcess();
        }
    } //蛮王冲撞

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RoleInfo>())
        {
            other.GetComponent<RoleInfo>().Hp -= info.Attk;
            //print(other.GetComponent<RoleInfo>().Hp);
            //EnterBulletPool();
        }
    }
}
