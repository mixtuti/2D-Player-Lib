using UnityEngine;

namespace GameLib2D.Core
{
    public class GameLib2DHitCheck : MonoBehaviour
    {
        // 設置判定範囲の座標とサイズを設定できるようにする
        private static Vector2 checkOffset = new Vector2(0f, -0.5f); // 判定をキャラクターの下にオフセットを設定
        private static Vector2 checkSize = new Vector2(0.5f, 0.1f);  // 判定範囲のサイズ (幅と高さ)

        // 判定を可視化するための設定
        public static void DrawGroundCheckRange(Transform characterTransform)
        {
            // 判定範囲を表示（エディタ上で）
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(characterTransform.position + (Vector3)checkOffset, new Vector3(checkSize.x, checkSize.y, 1f));
        }

        // 地面や他のオブジェクトと接触しているか確認する
        public static bool IsTouchingGround(Transform characterTransform, LayerMask layerMask)
        {
            // キャラクターの位置と設定された範囲で判定
            return Physics2D.OverlapBox(characterTransform.position + (Vector3)checkOffset, checkSize, 0f, layerMask);
        }

        // 指定した方向に接触しているか確認する (オプション)
        public static bool IsTouchingInDirection(Transform characterTransform, Vector2 direction, LayerMask layerMask)
        {
            // キャラクターの位置から指定された方向に向かって判定を行う
            RaycastHit2D hit = Physics2D.Raycast(characterTransform.position, direction, checkSize.x, layerMask);
            return hit.collider != null;
        }

        // 設置判定範囲のオフセット設定
        public static void SetCheckOffset(Vector2 offset)
        {
            checkOffset = offset;
        }

        // 設置判定範囲のサイズ設定
        public static void SetCheckSize(Vector2 size)
        {
            checkSize = size;
        }
    }
}


