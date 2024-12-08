using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterJump : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 checkOffset = new Vector2(0f, -0.5f);
    [SerializeField] Vector2 checkSize = new Vector2(0.5f, 0.1f);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameLib2DHitCheck.SetCheckOffset(checkOffset);
        GameLib2DHitCheck.SetCheckSize(checkSize);
        CharacterJumpLib.SetGroundLayer(groundLayer);
    }

    void Update()
    {
        CharacterJumpLib.Jump(rb, jumpForce);
    }

    private void OnDrawGizmos()
    {
        // 判定範囲を可視化
        GameLib2DHitCheck.DrawGroundCheckRange(transform);
    }
}
