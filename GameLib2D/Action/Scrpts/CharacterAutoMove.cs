using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterAutoMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector2 autoMoveDirectionRb = new Vector2(1, 0);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CharacterMoveLib.AutoMoveRb(rb, autoMoveDirectionRb, moveSpeed);
    }
}
