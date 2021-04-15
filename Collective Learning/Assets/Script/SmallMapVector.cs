using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMapVector : MonoBehaviour
{
    public GameObject SmallCube;
    public GameObject SmallSphere;
    public GameObject BigCube;
    public GameObject BigSphere;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = BigSphere.transform.position - BigCube.transform.position;
        Vector3 pos = dir / 3;
        print(pos);
        Vector3 NewPos = new Vector3(Mathf.Clamp(pos.x, -4, 4), 0, Mathf.Clamp(pos.z, -4, 4));
        SmallSphere.transform.position = SmallCube.transform.position + NewPos;
        //Vector3 NewDir = dir * 
    }
}
