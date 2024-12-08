using UnityEngine;

namespace GameLib2D.Core
{
    public class GameLib2DTransform
    {
        // 現在のプレイヤーの向きを取得
        // -1: 左向き, 1: 右向き, 0: 入力なし
        public static int GetPlayerFacingDirection()
        {
            float horizontalMovement = GameLib2DInput.GetHorizontalMovement();

            if (horizontalMovement < 0)
            {
                return -1;  // 左向き
            }
            else if (horizontalMovement > 0)
            {
                return 1;   // 右向き
            }
            else
            {
                return 0;   // 動いていない
            }
        }
    }
}

