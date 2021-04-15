using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMapQuaternion : MonoBehaviour
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
        Vector3 NewDir = BigCube.transform.rotation * dir;
        print(NewDir);
    }
}
