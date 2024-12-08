using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMoveTf : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    void Update()
    {
        CharacterMoveLib.CharacterMoveTf(transform, moveSpeed);
    }
}
