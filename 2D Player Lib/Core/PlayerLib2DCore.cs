using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLib2D
{
    public enum MoveType
    {
        XAxisOnly,
        YAxisOnly,
        XYMovement
    }

    public static class PlayerLib2DCore
    {
        public static void MoveRigidbody2D(Rigidbody2D rb, float moveInputX, float moveInputY, float moveSpeed, MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.XAxisOnly:
                    rb.velocity = new Vector2(moveInputX * moveSpeed, rb.velocity.y);
                    break;

                case MoveType.YAxisOnly:
                    rb.velocity = new Vector2(rb.velocity.x, moveInputY * moveSpeed);
                    break;

                case MoveType.XYMovement:
                    rb.velocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);
                    break;
            }
        }

        public static void MoveTransform(Transform playerTransform, float moveInputX, float moveInputY, float moveSpeed, MoveType moveType)
        {
            Vector3 newPosition = playerTransform.position;

            switch (moveType)
            {
                case MoveType.XAxisOnly:
                    // X軸のみ移動
                    newPosition.x += moveInputX * moveSpeed * Time.deltaTime;
                    break;

                case MoveType.YAxisOnly:
                    // Y軸のみ移動
                    newPosition.y += moveInputY * moveSpeed * Time.deltaTime;
                    break;

                case MoveType.XYMovement:
                    // XY両軸移動
                    newPosition.x += moveInputX * moveSpeed * Time.deltaTime;
                    newPosition.y += moveInputY * moveSpeed * Time.deltaTime;
                    break;
            }

            playerTransform.position = newPosition;
        }

        public static void Flip(Transform playerTransform, ref bool isFacingRight, float moveInputX)
        {
            // 右に移動していて左向き、または左に移動していて右向きなら反転
            if (moveInputX > 0 && !isFacingRight || moveInputX < 0 && isFacingRight)
            {
                isFacingRight = !isFacingRight;
                // X軸のスケールを反転させて向きを変える
                Vector3 theScale = playerTransform.localScale;
                theScale.x *= -1;
                playerTransform.localScale = theScale;
            }
        }

        // プレイヤーの向き変更（スプライト）
        public static void FlipSprite(SpriteRenderer spriteRenderer, float moveInputX)
        {
            if (moveInputX > 0 && spriteRenderer.flipX || moveInputX < 0 && !spriteRenderer.flipX)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }

        public static void Jump(Rigidbody2D rb, float jumpForce, bool isHit)
        {
            if (isHit)
            {
                // 地面にいるときはジャンプ力を適用
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                // 空中でもジャンプできる場合の処理
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        public static void JumpInAir(Rigidbody2D rb, ref float currentJumpForce, bool isGrounded, bool canJumpInAir, ref int jumpCount, int maxJumpCount, float jumpDecay)
        {
            if (isGrounded || (canJumpInAir && jumpCount < maxJumpCount))
            {
                // 空中ジャンプの場合は回数をカウント
                jumpCount++;
                // ジャンプ力を適用
                rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
                
                // ジャンプ力を減衰させる
                currentJumpForce *= jumpDecay;
            }
        }

        public static bool IsHit(Rigidbody2D rb, LayerMask layerMask, Vector2 direction, float CheckDistance)
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, CheckDistance, layerMask);
            Debug.DrawRay(rb.position, direction * CheckDistance, Color.red, 0.1f);
            return hit.collider != null;
        }
    }
}