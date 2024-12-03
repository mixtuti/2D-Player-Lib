using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player2D
{
    [RequireComponent(typeof(PlayerLib2DCore))]
    public class Player2DMove : PlayerLib2DCore
    {
        public enum MoveDirection
        {
            X, // X軸のみ移動
            Y, // Y軸のみ移動
            XY // X軸とY軸両方移動
        }

        [SerializeField,Header("移動方向")] private MoveDirection moveDirection = MoveDirection.XY;
        [SerializeField] private float customMoveSpeed = 10f; // 新しい移動速度
        [SerializeField] private bool normalizeDiagonal = true;

        private bool canMove = true; // 移動可能かどうかのフラグ

        // 更新処理
        void Update()
        {
            if (canMove)
            {
                moveSpeed = customMoveSpeed; // moveSpeedをオーバーライドして設定

                // 入力処理
                float moveInputX = Input.GetAxisRaw("Horizontal"); // 左右移動入力を取得
                float moveInputY = Input.GetAxisRaw("Vertical");   // 上下移動入力を取得

                // 移動処理
                MovePlayer(moveInputX, moveInputY);
            }
            else
            {
                return;
            }
        }

        // プレイヤーの移動処理
        void MovePlayer(float moveInputX, float moveInputY)
        {
            Vector2 velocity = rb.velocity;

            switch (moveDirection)
            {
                case MoveDirection.X:
                    // X軸のみ移動
                    velocity.x = moveInputX * moveSpeed;
                    break;

                case MoveDirection.Y:
                    // Y軸のみ移動
                    velocity.y = moveInputY * moveSpeed;
                    break;

                case MoveDirection.XY:
                    // X軸とY軸両方移動
                    velocity.x = moveInputX * moveSpeed;
                    velocity.y = moveInputY * moveSpeed;
                    break;
            }

            // 斜め移動の際にノーマライズを適用
            if (normalizeDiagonal && velocity.magnitude > moveSpeed)
            {
                velocity.Normalize(); // ノーマライズすることで斜め移動のスピードを一定に保つ
                velocity *= moveSpeed; // ノーマライズ後に移動速度を再適用
            }

            // 設定した速度をRigidbody2Dに適用
            rb.velocity = new Vector2(velocity.x, rb.velocity.y); // Y軸の速度はジャンプで制御される
        }

        // 移動を無効にするメソッド
        public void DisableMovement()
        {
            canMove = false; // 移動を無効化
        }

        // 移動を有効にするメソッド
        public void EnableMovement()
        {
            canMove = true; // 移動を有効化
        }
    }
}
