using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerLib2DCore : MonoBehaviour
    {
        // プレイヤーの基本的なパラメータ
        private float baseMoveSpeed = 5f;
        private float baseJumpForce = 10f;
        private float baseGravityScale = 0f;

        // Rigidbody2Dコンポーネント
        protected Rigidbody2D rb;

        // 外部モジュールからアクセスするためのプロパティ
        public Rigidbody2D Rb => rb;

        // 移送速度
        public virtual float moveSpeed
        {
            get { return baseMoveSpeed; }
            set { baseMoveSpeed = value; }
        }

        // ジャンプ力
        public virtual float jumpForce
        {
            get { return baseJumpForce; }
            set { baseJumpForce = value; }
        }

        // 重力
        public virtual float gravityScale
        {
            get { return baseGravityScale; }
            set { baseGravityScale = value; }
        }

        // 初期化処理
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
            rb.gravityScale = 0f; // 重力を無効化
        }
    }
}
