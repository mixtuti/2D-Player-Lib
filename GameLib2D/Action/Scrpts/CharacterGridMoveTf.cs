using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterGridMoveTf : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridSize = 1f;

    void Update()
    {
        CharacterGridMoveLib.MoveGridTf(transform, moveSpeed, gridSize);
    }
}
