using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerLib2D;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player2DLibAction : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    // ジャンプに関する設定
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpDecay = 0.9f; // ジャンプ力の減衰率
    [SerializeField] int maxJumpCount = 2; // 最大ジャンプ回数
    [SerializeField] bool canJumpInAir = false; // 空中ジャンプが可能かどうか
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    // ダッシュに関する設定
    [SerializeField] bool canDash = true; // ダッシュ機能を使うかどうか
    [SerializeField] KeyCode dashKey = KeyCode.LeftShift; // ダッシュをトリガーするキー
    [SerializeField] float dashSpeed = 15f; // ダッシュの速度

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    private float currentJumpForce;
    private bool isFacingRight = true;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentJumpForce = jumpForce; // 初期ジャンプ力
        jumpCount = 0;
    }

    void Update()
    {
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        // 地面についているかをチェック
        isGrounded = PlayerLib2DCore.IsHit(rb, groundLayerMask, Vector2.down, 0.6f);

        // 地面にいる場合はジャンプ回数をリセット
        if (isGrounded)
        {
            jumpCount = 0;  // 地面にいる場合、ジャンプ回数リセット
            currentJumpForce = jumpForce; // ジャンプ力リセット
        }

        // ダッシュ処理
        if (canDash && moveInputX != 0 && Input.GetKey(dashKey))
        {
            isDashing = true;
        }

        // 移動処理
        float effectiveMoveSpeed = isDashing ? dashSpeed : moveSpeed; // ダッシュ中はダッシュ速度を使用
        PlayerLib2DCore.MoveRigidbody2D(rb, moveInputX, moveInputY, effectiveMoveSpeed, MoveType.XAxisOnly);

        // スプライトの向き変更
        PlayerLib2DCore.Flip(transform, ref isFacingRight, moveInputX);

        // ジャンプ処理
        if (Input.GetKeyDown(jumpKey))
        {
            if (isGrounded || (canJumpInAir && jumpCount < maxJumpCount))
            {
                // 空中ジャンプの場合は回数をカウント
                jumpCount++;
                PlayerLib2DCore.Jump(rb, currentJumpForce, isGrounded);

                // ジャンプ力を減衰させる
                currentJumpForce *= jumpDecay;
            }
        }

        // ダッシュ終了処理
        if (isDashing)
        {
            isDashing = false; // ダッシュが1フレームで終了
        }
    }
}
