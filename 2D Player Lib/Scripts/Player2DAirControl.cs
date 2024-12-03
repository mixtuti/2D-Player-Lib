using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player2D
{
    [RequireComponent(typeof(Player2DJump))]
    [RequireComponent(typeof(Player2DMove))]
    public class Player2DAirControl : MonoBehaviour
    {
        [SerializeField] private bool canMoveInAir = true;  // 空中での移動を許可するかどうか

        private Player2DJump jumpScript;
        private Player2DMove moveScript;

        void Start()
        {
            jumpScript = GetComponent<Player2DJump>();
            moveScript = GetComponent<Player2DMove>();
        }

        void Update()
        {
            // 空中での移動可否を制御
            if (jumpScript.IsAirborne)
            {
                if (!canMoveInAir)
                {
                    // 空中では移動しないように移動スクリプトを無効化
                    moveScript.DisableMovement();
                }
            }
            else
            {
                // 地面にいる場合は移動を有効化
                moveScript.EnableMovement();
            }
        }
    }
}


