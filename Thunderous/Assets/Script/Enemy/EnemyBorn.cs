using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{


    List<Transform> EnemyGoPos = new List<Transform>();
    List<char> CreateEnemyList = new List<char>();

    //GameObject this;

    int MaxNumb = 03;
    GameObject Enemy01;
    GameObject Enemy02;
    GameObject Enemy03;

    bool IsBossAppear = false;
    GameObject Boss01;

    private void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            EnemyGoPos.Add(this.transform.GetChild(i).transform);
        }
        Enemy01 = Resources.Load<GameObject>("Enemy_01");
        Enemy02 = Resources.Load<GameObject>("Enemy_02");
        Enemy03 = Resources.Load<GameObject>("Enemy_03");
        Boss01 = Resources.Load<GameObject>("Boss01");
    }
    // Start is called before the first frame update
    void Start()
    {
        //----------------------------生成敌人-----------------------------
        //生成出发位置
        float range = -God.god.worldPosLeftBottom.x + God.god.worldPosTopRight.x;
        float interval = range / (this.transform.childCount + 1);
        //-----------生成位置------------|

        this.transform.position += Vector3.right * God.god.worldPosLeftBottom.x;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            EnemyGoPos[i].position += new Vector3(interval * (i + 1), 0, 0); //出发口布局
        }
        while (true)
        {
            if (God.god.BornEnemyDigitalString.Length % 13 != 0)
                God.god.BornEnemyDigitalString += '0';
            else
                break;
        }//凑整12的倍数
        for (int i = 0; i < God.god.BornEnemyDigitalString.Length; i++)
        {
            CreateEnemyList.Add(God.god.BornEnemyDigitalString[i]);
        }
        BornGenerateTime();
    }
    float GenerateEnemyTiming;
    float GenerateTime;
    private void FixedUpdate()
    {
        //return;

        if (!God.god.IsStartGame)
        {
            return;
        }

        if (CreateEnemyList.Count >= 2) //判断 还有没有 Tips 通常不会是大于2
        {
            if (God.god.EnemiesNum >= God.god.MaxEnemiesNum)
                return;


            if (GenerateEnemyTiming >= GenerateTime)//当起飞时间大于起飞CD就可以 起飞 欸 飞~
            {
                for (int i = 0; i < EnemyGoPos.Count; i++) //有多少个起飞点   就飞几个编号
                {
                    string NB = CreateEnemyList[0] + "" + CreateEnemyList[1] + ""; //数字合并
                    if (int.Parse(NB) > MaxNumb)
                    {
                        NB = Random.Range(0, MaxNumb + 1).ToString();
                        if (NB.Length == 1)
                        {
                            NB = "0" + NB;
                        }
                    }//编号 随机
                    CreateEnemyList.RemoveAt(0); //删除两个编号
                    CreateEnemyList.RemoveAt(0); //

                    switch (NB)
                    {
                        case "01":
                            BornEnemy(Enemy01, EnemyGoPos[i].position, EnemyGoPos[i].rotation);
                            break;
                        case "02":
                            BornEnemy(Enemy02, EnemyGoPos[i].position, EnemyGoPos[i].rotation);
                            break;
                        case "03":
                            BornEnemy(Enemy03, EnemyGoPos[i].position, EnemyGoPos[i].rotation);
                            break;
                        default:

                            break;
                    }//获取编号 芜湖 起飞！ 欸~ 飞~
                }
                if (CreateEnemyList.Count >= 12)
                {
                    BornGenerateTime();
                }//免报错
            }
            else
            {
                GenerateEnemyTiming += Time.fixedDeltaTime;
            } //起飞时间
        }
        else
        {
            if (!IsBossAppear)
            {
                BornBoss();
            }
            //print("飞完了");
        }
    }//生成敌人
    void BornEnemy(GameObject enemy, Vector3 pos, Quaternion dir)
    {
        GameObject go;
        if (God.god.FindSon(God.god.GetStandbyPool_Game().transform, enemy.name + "(Clone)")) //判断有无这架飞机 缓冲池
        {
            go = God.god.FindSon(God.god.GetStandbyPool_Game().transform, enemy.name + "(Clone)").gameObject;
            go.transform.parent = null;
            go.SetActive(true);
        }
        else
        {
            go = GameObject.Instantiate(enemy);
        }
        go.transform.position = pos;
        go.transform.rotation = dir;
        God.god.EnemiesNum += 1; //出场数量 +自己 +1
    } //敌人出生
    void BornGenerateTime()
    {
        GenerateTime = float.Parse(CreateEnemyList[12] + "");
        GenerateTime = Mathf.Clamp(GenerateTime, 3, 8);
        CreateEnemyList.RemoveAt(12);
        GenerateEnemyTiming = 0;
    }//赋予 生成敌人的时间

    void BornBoss()
    {
        GameObject go = GameObject.Instantiate(Boss01);
        go.transform.position = new Vector3(0, 0, 8);
        go.transform.rotation = EnemyGoPos[0].rotation;
        IsBossAppear = true;
    }
}
