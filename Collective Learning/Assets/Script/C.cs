using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    int[,] list = new int[5, 5];

    void Start()
    {
        list[2, 2] = 100;
        print(list[2, 2]);

        //计算二进制 ！还没有倒转过来
        //Calculate(6);
        //print(result);
    }
    //void Update()
    //{

    //}


    string result;
    //计算二进制 ！还没有倒转过来
    void Calculate(int num)
    {
        if (num / 2 == 0)
        {
            result += num % 2 + "";
            return;
        }// 整数除以2 利用了取整的效果 很巧妙

        result += num % 2 + "";
        Calculate(num / 2);
    }
}