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


        // 입력
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 회전
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        // 애니메이터
        bool isWalk = 0 < moveDirection.magnitude;
        // moveDirection.magnitude : 백터의 길이를 반환합니다.
        // 입력 값을 받으면 백터의 길이가 0보다 커지면서 True를 반환합니다.
        anicon_Santa.SetBool("ISWALK", isWalk); //SetBool (파라미터의 이름, 설정 값)


        //공격
        if(Input.GetMouseButton(0))
        {
            anicon_Santa.SetTrigger("ISATTACK");
        }

        //댄스 : 키보드 위에 숫자 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anicon_Santa.SetTrigger("DANCE01");
        }

        //점프 : 스페이스바
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anicon_Santa.SetTrigger("JUMP");
        }


        //anicon_Santa.SetInteger() : Int
        //anicon_Santa.SetFloat() : Float
        //anicon_Santa.SetBool() : Bool
        //anicon_Santa.SetTrigger() : Trigger

        // anicon_PicoChan이라는 애니메이터를 담을 변수를 생성합니다.
        // Bool 타입의 Parameter를 생성하였기에 SetBool함수를 사용합니다.

    }
}
