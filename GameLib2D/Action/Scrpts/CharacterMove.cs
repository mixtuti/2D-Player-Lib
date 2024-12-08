using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CharacterMoveLib.CharacterMoveHorizontalRb(rb, moveSpeed);
    }
}
