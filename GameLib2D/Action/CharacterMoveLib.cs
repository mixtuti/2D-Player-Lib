using UnityEngine;
using GameLib2D.Core;

namespace GameLib2D.Action
{
    public class CharacterMoveLib
    {
        public static void CharacterMoveHorizontalRb(Rigidbody2D rb, float moveSpeed)
        {
            float moveDirection = GameLib2DInput.GetHorizontalMovement();
            Vector2 movement = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            rb.velocity = movement;
        }

        public static void CharacterMoveVerticalRb(Rigidbody2D rb, float moveSpeed)
        {
            float moveDirection = GameLib2DInput.GetVerticalMovement();
            Vector2 movement = new Vector2(rb.velocity.x, moveDirection * moveSpeed);
            rb.velocity = movement;
        }

        public static void CharacterMoveRb(Rigidbody2D rb, float moveSpeed)
        {
            float horizontalMovement = GameLib2DInput.GetHorizontalMovement();
            float verticalMovement = GameLib2DInput.GetVerticalMovement();

            Vector2 movement = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
            rb.velocity = movement;
        }

        public static void CharacterMoveHorizontalTf(Transform transform, float moveSpeed)
        {
            float moveDirection = GameLib2DInput.GetHorizontalMovement();
            Vector3 movement = new Vector3(moveDirection * moveSpeed, 0f, 0f);
            transform.position += movement * Time.deltaTime;
        }

        public static void CharacterMoveVerticalTf(Transform transform, float moveSpeed)
        {
            float moveDirection = GameLib2DInput.GetVerticalMovement();
            Vector3 movement = new Vector3(0f, moveDirection * moveSpeed, 0f);
            transform.position += movement * Time.deltaTime;
        }

        public static void CharacterMoveTf(Transform transform, float moveSpeed)
        {
            float horizontalMovement = GameLib2DInput.GetHorizontalMovement();
            float verticalMovement = GameLib2DInput.GetVerticalMovement();
            
            Vector3 movement = new Vector3(horizontalMovement * moveSpeed, verticalMovement * moveSpeed, 0f);
            transform.position += movement * Time.deltaTime;
        }

        // 自動移動 (Rigidbody2D)
        public static void AutoMoveRb(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed)
        {
            // 指定した方向と速度で自動的に移動
            Vector2 movement = moveDirection.normalized * moveSpeed;
            rb.velocity = movement;
        }

        // 自動移動 (Transform)
        public static void AutoMoveTf(Transform transform, Vector3 moveDirection, float moveSpeed)
        {
            // 指定した方向と速度で自動的に移動
            Vector3 movement = moveDirection.normalized * moveSpeed;
            transform.position += movement * Time.deltaTime;
        }
    }
}

