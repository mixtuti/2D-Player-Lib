using UnityEngine;
using GameLib2D.Core;

namespace GameLib2D.Action
{
    public class CharacterFlipLib
    {
        // プレイヤーのスケールを反転させる
        public static void FlipScale(Transform characterTransform, bool flipRight)
        {
            Vector3 newScale = characterTransform.localScale;

            if (flipRight && newScale.x < 0)
            {
                newScale.x = Mathf.Abs(newScale.x);  // 右向きに反転
            }
            else if (!flipRight && newScale.x > 0)
            {
                newScale.x = -Mathf.Abs(newScale.x); // 左向きに反転
            }

            characterTransform.localScale = newScale;
        }

        // 現在のプレイヤーの向きに基づいて反転させる
        public static void FlipCharacterScale(Transform characterTransform)
        {
            // GameLib2DTransform からプレイヤーの向きを取得
            int facingDirection = GameLib2DTransform.GetPlayerFacingDirection();

            // プレイヤーが右向きか左向きかに基づいてスケールの反転
            bool flipRight = facingDirection == 1;

            // スケールの反転を行う
            FlipScale(characterTransform, flipRight);
        }

        // プレイヤーのスプライトを反転させる
        public static void FlipSprite(SpriteRenderer spriteRenderer, bool flipRight)
        {
            spriteRenderer.flipX = !flipRight;
        }

        // 現在のプレイヤーの向きに基づいてスプライトを反転させる
        public static void FlipCharacterSprite(SpriteRenderer spriteRenderer)
        {
            // GameLib2DTransform からプレイヤーの向きを取得
            int facingDirection = GameLib2DTransform.GetPlayerFacingDirection();

            // プレイヤーが右向きか左向きかに基づいて反転
            bool flipRight = facingDirection == 1;

            // スプライトの反転を行う
            FlipSprite(spriteRenderer, flipRight);
        }
    }
}
