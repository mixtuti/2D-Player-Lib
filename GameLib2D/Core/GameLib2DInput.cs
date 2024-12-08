using UnityEngine;

namespace GameLib2D.Core
{
    public class GameLib2DInput
    {
        public static float GetHorizontalMovement()
        {
            return Input.GetAxis("Horizontal");
        }

        public static float GetVerticalMovement()
        {
            return Input.GetAxis("Vertical");
        }

        public static Vector2Int GetInputDirection()
        {
            // 入力値を取得
            float horizontal = GetHorizontalMovement();
            float vertical = GetVerticalMovement();

            // 移動方向を決定
            int horizontalDirection = (horizontal > 0) ? 1 : (horizontal < 0) ? -1 : 0;
            int verticalDirection = (vertical > 0) ? 1 : (vertical < 0) ? -1 : 0;

            return new Vector2Int(horizontalDirection, verticalDirection);
        }

        // ジャンプ入力を取得 (スペースキーが押された場合)
        public static bool IsJumpPressed()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        // ジャンプ入力を維持しているかチェック (スペースキーが押され続けている場合)
        public static bool IsJumpHeld()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}

