using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public GameObject Back;
    public GameObject back_1;
    public GameObject back_2;
    public float MoveSpeed;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    private void FixedUpdate()
    {
        if (!God.god.IsStartGame)
            return;
        //transform.Translate(0, MoveSpeed * Time.fixedDeltaTime, 0);
        //if (transform.position.z - back_1.transform.position.z >= 10)
        //{
        //    back_1.transform.position += new Vector3(0, 0, 20);
        //}
        //else if (transform.position.z - back_2.transform.position.z >= 10)
        //{
        //    back_2.transform.position += new Vector3(0, 0, 20);
        //}
        //print(back_2.transform.position.z);
        Back.transform.Translate(0, 0, -MoveSpeed * Time.fixedDeltaTime);
        if (back_2.transform.position.z <= 0)
        {
            back_1.transform.position += new Vector3(0, 0, 10);
            GameObject temp = back_2;
            back_2 = back_1;
            back_1 = temp;

        }
    }
}
