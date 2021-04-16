using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogicMain : MonoBehaviour
{
    RoleInfo info;
    GameObject target;

    public RoleInfo Info { get => info; set => info = value; }
    public GameObject Target { get => target; set => target = value; }

    private void Awake()
    {
        info = transform.GetComponent<RoleInfo>();
        target = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
