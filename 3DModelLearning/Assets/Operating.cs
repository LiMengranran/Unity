using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operating : MonoBehaviour
{
    Animator my_animation;
    void Awake()
    {
        my_animation = gameObject.GetComponent<Animator>();
    }
    void Start()
    {

    }
    void Update()
    {
        float w = Input.GetAxis("Vertical");
        print(w);
        if (w > 0)
        {
            my_animation.SetBool("Run", true);
            //my_animation.CrossFade("Run", 1f);
        }
        else if (w == 0)
        {
            my_animation.SetBool("Run", false);

            //my_animation
            my_animation.SetBool("idle", true);
            //my_animation.CrossFade("idle", 0.1f);
        };
        if (Input.GetKeyDown(KeyCode.J))
        {
            my_animation.CrossFade("Jab", 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            my_animation.CrossFade("J", 0.1f);
        }

    }
}