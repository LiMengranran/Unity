using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosLogic_01 : MonoBehaviour
{
    RoleInfo info;

    float FancyShootTiming;
    //Dictionary<Transform,float> MachineGun = new Dictionary<Transform, float>();

    List<Transform> MachineGun = new List<Transform>();
    List<Transform> LaserRunning = new List<Transform>();

    private void Awake()
    {
        info = transform.GetComponent<RoleInfo>();
        //shootCD = 1.01f - Mathf.Clamp(ShootSpeed, 0, 100) / 100;

        //吧机枪口加入
        for (int i = 1; i <= 2; i++)
        {
            MachineGun.Add(transform.Find("Emitter" + i));
        }
        //加入激光炮
        for (int i = 1; i < 4; i++)
        {
            LaserRunning.Add(transform.Find("LaserCannon" + i));
        }
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        MachineGunShoot();
        MachineGun[0].Rotate(new Vector3(0, 1, 0));
        MachineGun[1].Rotate(new Vector3(0, -1, 0));

        for (int i = 0; i < MachineGun.Count; i++)
        {
            FancyShoot(MachineGun[i]);
        }
    }
    void MachineGunShoot()
    {
        Quaternion dir = Quaternion.LookRotation(God.god.Player.transform.position - info.Emitter.position);
        info.Emitter.transform.rotation = Quaternion.Lerp(info.Emitter.transform.rotation, dir, 0.1f);
        if (info.Timer(info.ShootTiming, info.ShootCD) && transform.position.z <= God.god.worldPosTopRight.y) //充能
        {
            info.Shoot();
        }
    }//机枪射击
    void FancyShoot(Transform tran)
    {
        if (info.Timer(FancyShootTiming, info.ShootCD) && transform.position.z <= God.god.worldPosTopRight.y) //充能
        {

            FancyShootTiming = 0; //重置射击充能
            GameObject go;
            if (God.god.BulletPool.transform.childCount > 0)
            {
                go = God.god.BulletPool.transform.GetChild(0).gameObject;
                go.transform.parent = null;
                go.SetActive(true);
            }
            else
            {
                go = Instantiate(info.Bullet);
            }
            go.GetComponent<Bullet_Control>().Masetaa = transform.gameObject;
            go.transform.position = tran.position;
            go.transform.rotation = tran.rotation;
        }
        else
        {
            FancyShootTiming += Time.deltaTime;
        }
    } //花式射击
    void LaserRunningShoot()
    {

    }
    //public void Shoot(Transform Tran)
    //{

    //}
}
