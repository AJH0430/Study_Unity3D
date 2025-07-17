using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [SerializeField] Animator anicon;

    public void Damaged()
    {
        anicon.SetTrigger("DAMAGED");
    }

    public GameObject GoopSpray; // �ǰ� VFX ������

    public void TakeDamage(Vector3 hitPoint)
    {
        // ����Ʈ ����
        Instantiate(GoopSpray, hitPoint, Quaternion.identity);

        // ü�� ���� ó�� ��...
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            Vector3 hitPos = collision.contacts[0].point;
            TakeDamage(hitPos);
        }
    }
}
