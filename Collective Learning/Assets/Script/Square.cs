using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Cube;
    string BornCubeDigitalString;
    //List<char>
    private void Awake()
    {
        Cube = Resources.Load<GameObject>("Cube");
        BornCubeDigitalString = "111111001111";

    }
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                //int sequence = int.Parse(BornCubeDigitalString[i] + "") * 10 + int.Parse(BornCubeDigitalString[j] + ""); //从1到最后 
                int sequence = i * 10 + j; //从1到最后 
                print(int.Parse(BornCubeDigitalString[sequence] + "")); //把数字串循环一遍

                //if (int.Parse(BornCubeDigitalString[sequence] + "") == 1) //检测数字串==1就执行
                //{
                //    print(BornCubeDigitalString[sequence]);
                //    GameObject go = Instantiate(Cube);
                //    go.transform.position = new Vector3(j, i, 0);
                //    go.GetComponent<Id>().TestId = i * 10 + j;
                //}

                //int DigString = i*10+j;
                //print(DigString);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
