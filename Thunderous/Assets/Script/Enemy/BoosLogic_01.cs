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

    float X;

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

        X = Random.Range(God.god.worldPosLeftBottom.x, God.god.worldPosTopRight.x + 1); //距离
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (!God.god.IsStartGame)
            return;

        if (transform.position.z <= God.god.worldPosTopRight.y)
        {
            if ((X < 0 ? transform.position.x <= X + 0.1f : transform.position.x >= X - 0.1f))
            {
                X = Random.Range(God.god.worldPosLeftBottom.x, God.god.worldPosTopRight.x + 1); //距离
            }
            Vector3 posY = new Vector3(0, 0, 4);
            transform.position = Vector3.Lerp(transform.position, posY, info.Speed * 0.1f * Time.deltaTime);


            //限制范围
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, God.god.worldPosLeftBottom.x, God.god.worldPosTopRight.x),
                                             transform.position.y,
                                             Mathf.Clamp(transform.position.z, God.god.worldPosLeftBottom.y, God.god.worldPosTopRight.y));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -info.Speed * Time.deltaTime), Space.World);
        }

        MachineGunShoot();
        MachineGun[0].Rotate(new Vector3(0, 1, 0));
        MachineGun[1].Rotate(new Vector3(0, -1, 0));
        FancyShoot();


        //for (int i = 0; i < MachineGun.Count; i++)
        //{
        //    FancyShoot(MachineGun[i]);
        //}
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
    void FancyShoot()
    {


        if (info.Timer(FancyShootTiming, 0.1f) && transform.position.z <= God.god.worldPosTopRight.y) //充能
        {
            FancyShootTiming = 0; //重置射击充能
            for (int i = 0; i < MachineGun.Count; i++)
            {
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
                go.transform.position = MachineGun[i].position;
                go.transform.rotation = MachineGun[i].rotation;
            }
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
