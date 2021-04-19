using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Control : MonoBehaviour
{
    // Start is called before the first frame update
    float Timing;
    GameObject masetaa;
    float MoveSpped;
    public GameObject Masetaa { get => masetaa; set => masetaa = value; }

    void Start()
    {
        MoveSpped = Masetaa.GetComponent<RoleInfo>().Speed;
    }
    private void Update()
    {
        transform.Translate(0, 0, 10 * Time.deltaTime * MoveSpped / 10);
        Timing += Time.fixedDeltaTime;
        if (Timing > 20 || transform.position.z > God.god.worldPosTopRight.y + 0.5f || transform.position.z < God.god.worldPosLeftBottom.y - 0.5f)
        {
            EnterBulletPool();
            Timing = 0;
        }

    }
    //private void FixedUpdate()
    //{
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RoleInfo>())
        {
            other.GetComponent<RoleInfo>().Hp -= Masetaa.GetComponent<RoleInfo>().Attk;
            //print(other.GetComponent<RoleInfo>().Hp);
            EnterBulletPool();
        }
    }
    //private void OnTriggerStay(Collider other)
    //{

    //    Debug.Log(other + "停留");
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log(other + "离开");
    //}
    void EnterBulletPool()
    {
        this.transform.parent = God.god.GetBulletPool_Game().transform;
        this.transform.gameObject.SetActive(false);
    }//其咩萝 消失

}
