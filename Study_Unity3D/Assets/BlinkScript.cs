using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    //오브젝트가 켜질때마다 x가 0~10, z가 0~10 구간에 오브젝트가 배치되어야 한다.

    void OnEnable()
    {
        transform.position = new Vector3(Random.Range(0f, 10f), 0f, Random.Range(0f, 10f)); // x가 0~10, z가 0~10
    }
}
