using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferPool2 : MonoBehaviour
{
    static BufferPool2 instance;


    public static BufferPool2 Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject pool;
    public GameObject Buffer1;
    public GameObject Buffer2;

    Dictionary<string, List<GameObject>> Pool = new Dictionary<string, List<GameObject>>();
    List<GameObject> ListBuffer1 = new List<GameObject>();
    List<GameObject> ListBuffer2 = new List<GameObject>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        Buffer1 = Resources.Load<GameObject>("Buffer1");
        Buffer2 = Resources.Load<GameObject>("Buffer2");
    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject go = null;
            go = GetPool("Buffer1");
            if (!go)
            {
                go = Instantiate(Buffer1);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            GameObject go = null;
            go = GetPool("Buffer2");
            if (!go)
            {
                go = Instantiate(Buffer2);
            }
        }
    }
    public GameObject GetPool(string name)
    {
        GameObject go = null;
        if (Pool.ContainsKey(name))
        {
            if (Pool[name].Count > 0)
            {
                go = Pool[name][Pool[name].Count - 1];
                Pool[name].Remove(go);
                go.SetActive(true);
                go.transform.parent = null;

            }
        }

        return go;
    }
    public void PushPool(string name, GameObject go)
    {
        go.SetActive(false);
        go.transform.parent = pool.transform;
        if (Pool.ContainsKey(name))
        {
            Pool[name].Add(go);
        }
        else
        {
            Pool.Add(name, new List<GameObject>() { go });
        }
    }
}