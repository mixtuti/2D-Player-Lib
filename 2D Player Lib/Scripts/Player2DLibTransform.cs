using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerLib2D;

[RequireComponent(typeof(SpriteRenderer))]
public class Player2DLibTransform : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] MoveType moveType = MoveType.XYMovement;

    // ダッシュに関する設定
    [SerializeField] bool canDash = true;
    [SerializeField] KeyCode dashKey = KeyCode.LeftShift;
    [SerializeField] float dashSpeed = 15f;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
    }

    void Update()
    {
        if (rb == null) return;

        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        // ダッシュ処理
        float currentSpeed = (canDash && Input.GetKey(dashKey)) ? dashSpeed : moveSpeed;

        // 移動処理
        PlayerLib2DCore.MoveTransform(transform, moveInputX, moveInputY, currentSpeed, moveType);

        // キャラクターの向きを変更
        PlayerLib2DCore.Flip(transform, ref isFacingRight, moveInputX);
    }
}
