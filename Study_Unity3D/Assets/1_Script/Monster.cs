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

    public GameObject GoopSpray; // 피격 VFX 프리팹

    public void TakeDamage(Vector3 hitPoint)
    {
        // 이펙트 생성
        Instantiate(GoopSpray, hitPoint, Quaternion.identity);

        // 체력 감소 처리 등...
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
