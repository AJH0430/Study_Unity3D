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
        float h = Input.GetAxis("Horizontal"); // A/D �Ǵ� ��/��
        float v = Input.GetAxis("Vertical");   // W/S �Ǵ� ��/��

        Vector3 inputDirection = new Vector3(h, 0, v).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // ī�޶� ���� ���� ���
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * inputDirection.z + camRight * inputDirection.x;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);

            // ĳ���Ͱ� �̵� ������ �ٶ󺸰� ȸ��
            transform.forward = moveDir;
        }
    }
}
