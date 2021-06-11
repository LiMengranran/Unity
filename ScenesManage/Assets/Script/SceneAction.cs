using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAction : MonoBehaviour
{
    void Awake()
    {

    }
    void Start()
    {

    }
    void cao(params int[] obj)
    {
        print("made");
    }
    int[] obj = new int[] { 1, 1 };
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadSceneManage.instance.LoadScene("Scene2", cao);
        }
    }
}