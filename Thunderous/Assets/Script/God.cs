using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class God : MonoBehaviour
{
    public static God god;
    GameObject player;

    public bool IsStartGame = false;
    GameObject Ui;
    GameObject BeginUi;
    GameObject GameUi;
    public float DifficultValue;
    public string DifficultText;
    public int EnemiesNum; //敌人出场数量
    public int MaxEnemiesNum; //最大敌人出场数量
    //Button StartGame;


    public GameObject BulletPool;

    GameObject StandbyPool;

    public GameObject AnimationPool;
    public GameObject ExpAnimator;

    public Vector2 worldPosLeftBottom;
    public Vector2 worldPosTopRight;


    public GameObject cube;

    public GameObject Player { get => player; set => player = value; }
    private void Awake()
    {
        god = this;

        player = GameObject.Find("Player");

        ExpAnimator = Resources.Load<GameObject>("ExpAnimator");
        AnimationPool = GameObject.Find("AnimationPool");
        //----------------------------敌人-----------------------------

        BulletPool = GameObject.Find("BulletPool"); //子弹缓存
        StandbyPool = GameObject.Find("StandbyPool"); //待机 缓存

        //----------------------------UI-----------------------------
        Ui = GameObject.Find("Canvas"); //UI
        if (Ui)
        {
            BeginUi = FindSon(Ui.transform, "StartInterface").gameObject; //开始界面
            GameUi = FindSon(Ui.transform, "GameUi").gameObject;
        }
        FindSon(BeginUi.transform, "StartGame").gameObject.GetComponent<Button>().onClick.AddListener(IsStartGameButton);
        FindSon(GameUi.transform, "IconSet").gameObject.GetComponent<Button>().onClick.AddListener(IsStartGameButton);
        //----------------------------屏幕范围-----------------------------
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        worldPosLeftBottom = new Vector2(worldPosLeftBottom.x, transform.position.z - 5);
        worldPosTopRight = new Vector2(worldPosTopRight.x, transform.position.z + 5);

        //print(worldPosLeftBottom+"---"+ worldPosTopRight);
    }



    private void FixedUpdate()
    {
        if (!IsStartGame)
        {
            BeginUi.SetActive(true);
            //布置难度
            DifficultValue = FindSon(BeginUi.transform, "difficultMode").gameObject.GetComponent<Slider>().value;

            float Num = DifficultValue * 3 * 5f + 5; //根据难度调整出场数量
            MaxEnemiesNum = int.Parse((Mathf.Round(Num).ToString()));
            //print("最大敌人" + MaxEnemiesNum);
            //MaxEnemiesNum=Mathf()
            if (DifficultValue <= 0.3f)
            {
                DifficultText = "简单";
            }
            else if (DifficultValue <= 0.6f)
            {
                DifficultText = "困难";
            }
            else if (DifficultValue < 1f)
            {
                DifficultText = "普通";
            }
            else
            {
                DifficultText = "地狱";
            }
            FindSon(BeginUi.transform, "DifficultyDisplay").gameObject.GetComponent<Text>().text = DifficultText;
            GameUi.SetActive(!BeginUi.activeSelf); //与开始界面 激活状态相反
            return;
        }
        else
        {
            BeginUi.SetActive(false);
            GameUi.SetActive(!BeginUi.activeSelf); //与开始界面 激活状态相反
        }

        FindSon(GameUi.transform, "EnemiesNum").gameObject.GetComponent<Text>().text = "敌人：" + EnemiesNum.ToString();
        //print(EnemiesNum + "-----" + MaxEnemiesNum);
    }

    public Transform FindSon(Transform parent, string name)
    {
        if (parent.name == name)
            return parent;

        if (parent.childCount == 0)
            return null;

        Transform obj = null;
        for (int i = 0; i < parent.childCount; i++)
        {
            obj = (FindSon(parent.GetChild(i), name));
            if (obj != null)
                break;
        }
        return obj;
    }//找儿子


    public GameObject GetBulletPool_Game()
    {
        if (BulletPool == null) BulletPool = GameObject.Find("BulletPool");
        return BulletPool;
    }
    public GameObject GetStandbyPool_Game()
    {
        if (StandbyPool == null) StandbyPool = GameObject.Find("StandbyPool");
        return StandbyPool;
    }
    void IsStartGameButton()
    {
        God.god.IsStartGame = !God.god.IsStartGame;
    }//开始游戏按钮
}
