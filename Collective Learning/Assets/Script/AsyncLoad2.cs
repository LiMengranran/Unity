using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoad2 : MonoBehaviour
{
    void Awake()
    {

    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); //莫纳塔瓦乃！卡蜜达！
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("cao");

            StartCoroutine("IELoadScene", "AsyncLoad");

        }
    }
    AsyncOperation async = null;
    IEnumerator IELoadScene(string name)
    {
        print("xingmeiyou1");
        async = SceneManager.LoadSceneAsync(name);
        yield return async;
        print("xingmeiyou2");//没执行！
    }
}