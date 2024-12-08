using UnityEngine;
using GameLib2D.Core;

namespace GameLib2D.Action
{
    public class CharacterGridMoveLib
    {
        // グリッド上で移動 (Transform)
        public static void MoveGridTf(Transform characterTransform, float moveSpeed, float gridSize)
        {
            // 入力方向を取得 (WASD または 矢印キー)
            Vector2Int direction = GameLib2DInput.GetInputDirection();

            // 目標座標を設定
            Vector3 targetPosition = new Vector3(
                Mathf.Round(characterTransform.position.x / gridSize) * gridSize + direction.x * gridSize,
                Mathf.Round(characterTransform.position.y / gridSize) * gridSize + direction.y * gridSize,
                characterTransform.position.z
            );

            // 移動先に向かってスムーズに移動
            characterTransform.position = Vector3.MoveTowards(characterTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        // グリッド上で移動 (Rigidbody2D)
        public static void MoveGridRb(Rigidbody2D rb, float moveSpeed, float gridSize)
        {
            // 入力方向を取得 (WASD または 矢印キー)
            Vector2Int direction = GameLib2DInput.GetInputDirection();

            // 現在のグリッド座標を基準に移動
            Vector2 targetPosition = new Vector2(
                Mathf.Round(rb.position.x / gridSize) * gridSize + direction.x * gridSize,
                Mathf.Round(rb.position.y / gridSize) * gridSize + direction.y * gridSize
            );

            // Rigidbody2D を使って移動
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime));
        }

        // 現在の位置からグリッド座標を取得
        public static Vector2Int GetGridPosition(Vector2 currentPosition, float gridSize)
        {
            // 現在の位置をグリッド座標に変換
            int x = Mathf.RoundToInt(currentPosition.x / gridSize);
            int y = Mathf.RoundToInt(currentPosition.y / gridSize);
            return new Vector2Int(x, y);
        }
    }
}
