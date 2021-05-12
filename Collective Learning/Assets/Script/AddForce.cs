using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody cube, cube2, cube3, cube4;
    GameObject cubeRigidBody;
    void Awake()
    {
        cubeRigidBody = Resources.Load<GameObject>("CubeRigidbody");
    }
    int Nub = 6;
    float posIncrease;

    int cubeNub = 1;
    void Start()
    {
        //for (int i = 0; i < 6; i++)
        //{
        //    for (int j = 0; j < Nub; j++)
        //    {
        //        GameObject go = Instantiate(cubeRigidBody);
        //        go.transform.position = new Vector3(j + posIncrease + 10, i, 0);
        //    }
        //    posIncrease += 0.5f;
        //    Nub--;
        //} //生成2D金字塔

        for (int i = 3; i > 0; i--)
        {
            for (int j = 0; j < Mathf.Sqrt(cubeNub); j++)
            {
                for (int n = 0; n < Mathf.Sqrt(cubeNub); n++)
                {
                    GameObject go = Instantiate(cubeRigidBody);
                    go.transform.position = new Vector3(n - (3 - i), i, j - (3 - i));
                }
            }
            float temp = Mathf.Sqrt(cubeNub);
            cubeNub = (Mathf.FloorToInt(temp) + 2) * (Mathf.FloorToInt(temp) + 2);
        } //生成金字塔

    }
    void Update()
    {
        //print(Vector3.forward);
        cube.AddForce(Vector3.forward, ForceMode.Acceleration); //加速度
        cube2.AddForce(Vector3.forward, ForceMode.Force);  //和质量有关
        cube3.AddForce(Vector3.forward, ForceMode.Impulse);  //冲量
        //cube4.AddForce(Vector3.forward , ForceMode.VelocityChange); //关注速度
        cube4.AddForceAtPosition(Vector3.forward, new Vector3(2, 2, 2));
    }
}