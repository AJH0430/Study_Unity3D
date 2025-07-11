using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube.transform.position += new Vector3(0.1f,0,0.1f); // x,y,z

        float distance = Vector3.Distance(transform.position, Vector3.zero);
        // Vector3.zero : Vector3(0,0,0)�� �����մϴ�.
        // Vector3.Dsitance(A,B) : A�� B�� ������ �Ÿ��� ��ȯ�մϴ�. 
        Debug.Log($"�Ÿ��� : {distance}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
