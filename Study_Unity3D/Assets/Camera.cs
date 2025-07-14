using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D 또는 ←/→
        float v = Input.GetAxis("Vertical");   // W/S 또는 ↑/↓

        Vector3 inputDirection = new Vector3(h, 0, v).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // 카메라 기준 방향 계산
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * inputDirection.z + camRight * inputDirection.x;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);

            // 캐릭터가 이동 방향을 바라보게 회전
            transform.forward = moveDir;
        }
    }
}
