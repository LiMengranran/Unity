using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigabon : MonoBehaviour
{
    NavMeshAgent my;
    public GameObject target;
    void Awake()
    {
        my = gameObject.GetComponent<NavMeshAgent>();

    }
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            my.SetDestination(target.transform.position);
        }
    }
}