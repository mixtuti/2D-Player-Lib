using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player2D
{
    [RequireComponent(typeof(PlayerLib2DCore))]
    public class Player2DJump : PlayerLib2DCore
    {
        // ジャンプ力を変更するためのプロパティ
        [SerializeField] float customJumpForce = 15f;
        [SerializeField] float customGravityScale = 1f;
        [SerializeField] KeyCode jumpKey = KeyCode.Space;
        [SerializeField] bool canAirJump = false; // 空中ジャンプの可否
        [SerializeField] string groundTag = "Ground"; 
        [SerializeField] int maxAirJumps = 1; // 空中ジャンプ可能回数

        private int currentAirJumps = 0; // 現在の空中ジャンプ回数
        private bool isGrounded = false; // 接地状態を判定

        public bool IsAirborne => !isGrounded;  // 地面にいないなら空中と見なす

        void Start()
        {
            // 初期化時に重力を設定
            gravityScale = customGravityScale;
            rb.gravityScale = gravityScale;
        }

        void Update()
        {
            // ジャンプ力をオーバーライド
            jumpForce = customJumpForce;  // ここで baseJumpForce をオーバーライド

            // ジャンプ入力を処理
            if (Input.GetKeyDown(jumpKey))
            {
                if (isGrounded)
                {
                    Jump(); // 地上ジャンプ
                    currentAirJumps = 0; // 空中ジャンプ回数をリセット
                }
                else if (canAirJump && currentAirJumps < maxAirJumps)
                {
                    Jump(); // 空中ジャンプ
                    currentAirJumps++;
                }
            }
        }

        private void Jump()
        {
            // 現在の速度を取得
            Vector2 velocity = rb.velocity;

            // 垂直方向の速度だけ上書きしてジャンプ力を加える
            velocity.y = jumpForce;

            // 新しい速度をRigidbody2Dに適用
            rb.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 地面に接触している場合に接地状態を更新
            if (collision.gameObject.CompareTag(groundTag))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            // 地面から離れたら接地状態を更新
            if (collision.gameObject.CompareTag(groundTag))
            {
                isGrounded = false;
            }
        }
    }
}
