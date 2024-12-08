using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterAutoMoveTf : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector3 autoMoveDirectionTf = new Vector3(1, 0, 0);

    void Update()
    {
        // Transform で自動移動
        CharacterMoveLib.AutoMoveTf(transform, autoMoveDirectionTf, moveSpeed);
    }
}
