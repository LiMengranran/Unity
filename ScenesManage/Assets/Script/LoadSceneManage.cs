using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManage : MonoBehaviour
{
    public static LoadSceneManage instance;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }
    void Update()
    {

    }
    public delegate void operate(params int[] obj);

    public void LoadScene(string name, operate o1, params int[] obj)
    {
        StartCoroutine(IELoadScene(name, o1, obj));
    }
    AsyncOperation async = null;
    public IEnumerator IELoadScene(string name, operate o1, params int[] obj)
    {
        async = SceneManager.LoadSceneAsync(name);
        yield return async;
        //print("woc");
        if (o1 != null)
        {
            o1(obj);
            //print(obj[0]);
        }
        async = null;
    }
}