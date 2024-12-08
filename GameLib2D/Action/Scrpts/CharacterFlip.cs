using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFlip : MonoBehaviour
{
    void Update()
    {
        CharacterFlipLib.FlipCharacterScale(transform);
    }
}
