using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; // Rigidbody2D�R���|�[�l���g�ւ̎Q��
    private float xSpeed; // X�����ړ����x
    public CameraController cameraController; // �J��������N���X

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        // �J���������ʒu
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();

        // �J�����Ɏ��g�̍��W��n��
        cameraController.SetPosition(transform.position);
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.D)) // �E�����̈ړ�����
        {
            xSpeed = 6.0f;
        }
        else if (Input.GetKey(KeyCode.A)) // �������̈ړ�����
        {
            xSpeed = -6.0f;
        }
        else
        {
            xSpeed = 0.0f; // ���͂Ȃ� X�����̈ړ����~
        }
    }

    private void PlayerJump()
    {
        // �W�����v����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �W�����v�͂��v�Z
            float jumpPower = 10.0f;
            // �W�����v�͂�K�p
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }
    
    // FixedUpdate�i��莞�Ԃ��Ƃ�1�x�����s�E�������Z�p�j
    private void FixedUpdate()
    {
        // �ړ����x�x�N�g�������ݒl����擾
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = xSpeed; // X�����̑��x����͂��猈��

        // �v�Z�����ړ����x�x�N�g����Rigidbody2D�ɔ��f
        rigidbody2D.velocity = velocity;
    }
}
