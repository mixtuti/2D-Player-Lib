using UnityEngine;
using GameLib2D.Core;

namespace GameLib2D.Action
{
    public class CharacterJumpLib
    {
        private static LayerMask groundLayer;  // 地面レイヤー

        // ジャンプ処理
        public static void Jump(Rigidbody2D rb, float jumpForce)
        {
            // 地面に接触しているかどうかを確認
            if (GameLib2DHitCheck.IsTouchingGround(rb.transform, groundLayer) && GameLib2DInput.IsJumpPressed())
            {
                // Y軸に対してジャンプ力を加える
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // 地面レイヤーを設定
        public static void SetGroundLayer(LayerMask layer)
        {
            groundLayer = layer;
        }
    }
}
