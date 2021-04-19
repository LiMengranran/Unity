using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleInfo : MonoBehaviour
{
    public string TypesId;
    public float Hp;
    float StaticHp;
    public float Attk;
    public float Speed;
    public float ShootSpeed;
    float shootCD;

    private GameObject bulletPool;
    private GameObject bullet;

    float shootTiming;
    public Transform Emitter;
    public GameObject AimingLine;
    public Vector3 AimingLineScale;
    public Vector3 Static_AimingLine;
    public float ShootCD { get => shootCD; set => shootCD = value; }
    public float ShootTiming { get => shootTiming; set => shootTiming = value; }
    public GameObject BulletPool { get => bulletPool; set => bulletPool = value; }
    public GameObject Bullet { get => bullet; set => bullet = value; }


    // Start is called before the first frame update
    private void Awake()
    {
        shootCD = 1.01f - Mathf.Clamp(ShootSpeed, 0, 100) / 100;

        StaticHp = Hp;

    }
    void Start()
    {

        bullet = Resources.Load<GameObject>("Bullet"); //加载子弹
        Emitter = God.god.FindSon(transform, "Emitter"); //找射击口
        BulletPool = God.god.GetBulletPool_Game(); // 缓冲池

        if (God.god.FindSon(transform, "ShootAimingLine"))
        {
            AimingLine = God.god.FindSon(transform, "AimingLine").gameObject;
            AimingLineScale = AimingLine.transform.localScale; //赋值大小
            Static_AimingLine = AimingLineScale; //静态大小赋值
        }//赋值预判线


    }
    private void FixedUpdate()
    {
        //print(transform.GetComponent<Collider>().bounds.extents);

        if (!God.god.IsStartGame)
            return;
        if (shootTiming < ShootCD) //子弹计时充能
            shootTiming += Time.fixedDeltaTime;


        if (Hp <= 0
            || transform.position.x > God.god.worldPosTopRight.x + 3
            || transform.position.x < God.god.worldPosLeftBottom.x - 3
            || transform.position.z < God.god.worldPosLeftBottom.y - 3)
        {
            Dead();
            God.god.EnemiesNum -= 1;

            Hp = StaticHp; //变0后 进缓冲池血量回复
        }
    }
    public void Dead()
    {
        transform.parent = God.god.GetStandbyPool_Game().transform;
        transform.gameObject.SetActive(false);
        //transform.position
        ExpAnimation();

    }
    void ExpAnimation()
    {
        GameObject explosion;
        if (God.god.FindSon(God.god.AnimationPool.transform, "ExpAnimator(Clone)"))
        {
            explosion = God.god.FindSon(God.god.AnimationPool.transform, "ExpAnimator(Clone)").gameObject;
            explosion.transform.parent = null;
            explosion.gameObject.SetActive(true);
            //print("找到了");
        }
        else
        {
            explosion = Instantiate(God.god.ExpAnimator);
            //print("找不到了");
        }
        explosion.transform.position = transform.position;
        explosion.transform.localScale = transform.GetChild(0).localScale * 2;
    } //爆炸动画 完了进池子
    public void Shoot()
    {
        shootTiming = 0; //重置射击充能
        GameObject go;
        if (BulletPool.transform.childCount > 0)
        {
            go = BulletPool.transform.GetChild(0).gameObject;
            go.transform.parent = null;
            go.SetActive(true);
        }
        else
        {
            go = Instantiate(bullet);
        }
        go.GetComponent<Bullet_Control>().Masetaa = transform.gameObject;
        go.transform.position = Emitter.transform.position;
        go.transform.rotation = Emitter.transform.rotation;
    } //射击
    

    public void LookPlayer(Transform tran)
    {
        Quaternion dir = Quaternion.LookRotation(God.god.Player.transform.position - transform.position);
        tran.rotation = Quaternion.Lerp(transform.rotation, dir, 0.1f);
        //return tran.rotation;
    }
    public bool Timer(float Timing, float NeedTime)
    {
        if (Timing >= NeedTime)
        {
            return true;
        }
        return false;
    }//计时

}
