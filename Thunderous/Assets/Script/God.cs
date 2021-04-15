using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class God : MonoBehaviour
{
    public static God god;

    public bool IsStartGame = false;
    GameObject Ui;
    GameObject BeginUi;
    //Button StartGame;


    GameObject BulletPool;

    GameObject StandbyPool;

    public GameObject AnimationPool;
    public GameObject ExpAnimator;

    public Vector2 worldPosLeftBottom;
    public Vector2 worldPosTopRight;

    private void Awake()
    {
        god = this;

        ExpAnimator = Resources.Load<GameObject>("ExpAnimator");
        AnimationPool = GameObject.Find("AnimationPool");
        //----------------------------敌人-----------------------------

        BulletPool = GameObject.Find("BulletPool"); //子弹缓存
        StandbyPool = GameObject.Find("StandbyPool"); //待机 缓存
        
        //----------------------------UI-----------------------------
        Ui = GameObject.Find("Canvas"); //UI
        if (Ui)
            BeginUi = FindSon(Ui.transform, "StartInterface").gameObject; //开始界面
        FindSon(BeginUi.transform, "StartGame ").gameObject.GetComponent<Button>().onClick.AddListener(StartGameButton);
        //----------------------------屏幕范围-----------------------------
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);

    }

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        if (!God.god.IsStartGame)
            return;
        else
        {
            BeginUi.SetActive(false);
        }
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
    void StartGameButton()
    {
        God.god.IsStartGame = true;
    }//开始游戏按钮
}
