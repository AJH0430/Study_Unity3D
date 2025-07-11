using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] Animator anicon_Santa;
    // Update is called once per frame
    void Update()
    {


        // �Է�
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ȸ��
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        // �ִϸ�����
        bool isWalk = 0 < moveDirection.magnitude;
        // moveDirection.magnitude : ������ ���̸� ��ȯ�մϴ�.
        // �Է� ���� ������ ������ ���̰� 0���� Ŀ���鼭 True�� ��ȯ�մϴ�.
        anicon_Santa.SetBool("ISWALK", isWalk); //SetBool (�Ķ������ �̸�, ���� ��)


        //����
        if(Input.GetMouseButton(0))
        {
            anicon_Santa.SetTrigger("ISATTACK");
        }

        //�� : Ű���� ���� ���� 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anicon_Santa.SetTrigger("DANCE01");
        }

        //���� : �����̽���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anicon_Santa.SetTrigger("JUMP");
        }


        //anicon_Santa.SetInteger() : Int
        //anicon_Santa.SetFloat() : Float
        //anicon_Santa.SetBool() : Bool
        //anicon_Santa.SetTrigger() : Trigger

        // anicon_PicoChan�̶�� �ִϸ����͸� ���� ������ �����մϴ�.
        // Bool Ÿ���� Parameter�� �����Ͽ��⿡ SetBool�Լ��� ����մϴ�.

    }
}
