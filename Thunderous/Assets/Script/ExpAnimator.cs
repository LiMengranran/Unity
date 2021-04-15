using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpAnimator : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = anim.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            transform.parent = God.god.AnimationPool.transform;
            transform.gameObject.SetActive(false);
        }
        //print(animatorInfo.normalizedTime);
    }
}
