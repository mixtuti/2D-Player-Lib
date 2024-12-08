# GameLib2D

![代替テキスト](https://img.shields.io/badge/Unity-2022.3+-orange) <img src="http://img.shields.io/badge/License-Unlicense license-blue.svg?style=flat"> <img src="http://img.shields.io/badge/Language-C%23-green.svg?style=flat"><br>
Unityで2Dゲームを作る際に少しでもプログラムの入力を簡単にするためのライブラリです。

## システム要件

Unity 2022.3.28 での動作は確認済みです。

## 概要

2Dゲームに特化したライブラリ(になる予定)

## 依存関係

なし

## 導入方法

### 1. プロジェクトへの導入
導入方法は大きく分けて2つあります。お好きな方法で導入してください。

#### 1. Unity Package Managerを使う方法
「Window > Package Manager」を開き、「Add Package from git URL」を選択します。<br>
その後、以下のURLを入力してください。
```
https://github.com/mixtuti/GameLib2D.git?path=GameLib2D
```

## スクリプトの解説

### 1. Core系のスクリプト
Coreのフォルダに入ったスクリプトは基本的には触ることはありません。ゲーム全般に使えそうな機能を作成しています。

#### 1. GameLib2DInput.cs
キー入力についての管理をしています。

##### 1. GetHorizontalMovement() 戻り値:float型
##### 2. GetVerticalMovement() 戻り値:float型
##### 3. GetInputDirection() 戻り値:Vector2Int型
##### 4. IsJumpPressed() 戻り値:bool値
##### 5. IsJumpHeld() 戻り値:bool値

#### 2. GameLib2DTransform.cs
プレイヤーの向きを取得するスクリプトです。

##### 1. GetPlayerFacingDirection() 戻り値:int値

#### 3. GameLib2DHitCheck.cs
当たり判定に関する処理をするスクリプトです。レイヤーマスクを使用しています。

##### 1. DrawGroundCheckRange(Transform transform)
##### 2. IsTouchingGround(Transform transform, LayerMask layerMask) 戻り値:bool値
##### 3. IsTouchingInDirection(Transform transform, Vector2 direction, LayerMask layerMask) 戻り値:bool値
##### 4. SetCheckOffset(Vector2 offset)
##### 5. SetCheckSize(Vector2 size)

### 2. Action系のスクリプト

#### 1. CharacterMoveLib.cs
キャラクターの移動に関するスクリプトです。Transform、Rigidbody、自動移動を可能にします。

##### 1. CharacterMoveHorizontalRb(Rigidbody2D rb, float moveSpeed)
##### 2. CharacterMoveVerticalRb(Rigidbody2D rb, float moveSpeed)
##### 3. CharacterMoveRb(Rigidbody2D rb, float moveSpeed)
##### 4. CharacterMoveHorizontalTf(Transform transform, float moveSpeed)
##### 5. CharacterMoveVerticalTf(Transform transform, float moveSpeed)
##### 6. CharacterMoveTf(Transform transform, float moveSpeed)
##### 7. AutoMoveRb(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed)
##### 8. AutoMoveTf(Transform transform, Vector3 moveDirection, float moveSpeed)

#### 2. CharacterGridMoveLib.cs
グリッドでキャラを移動させるスクリプトです。

##### 1. MoveGridTf(Transform characterTransform, float moveSpeed, float gridSize)
##### 2. MoveGridRb(Rigidbody2D rb, float moveSpeed, float gridSize)
##### 3. GetGridPosition(Vector2 currentPosition, float gridSize) 戻り値:Vector2Int型

#### 3. CharacterFlipLib.cs
キャラクターの反転に関するスクリプトです。

##### 1. FlipScale(Transform transform, bool flipRight)
##### 2. FlipCharacterScale(Transform characterTransform)
##### 3. FlipSprite(SpriteRenderer spriteRenderer, bool flipRight)
##### 4. FlipCharacterSprite(SpriteRenderer spriteRenderer)

#### 4. CharacterJumpLib.cs
キャラクターのジャンプに関するスクリプトです。

##### 1. Jump(Rigidbody2D rb, float jumpForce)
##### 2. SetGroundLayer(LayerMask layer)

### リファレンス
それぞれのフォルダ内に簡単な使い方などを書いたスクリプトがあるのでそれを見れば大体わかります。

#### 1. キャラクターの移動Rigidbody)
```cs
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
```

#### 2. 自動移動
```cs
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
```

#### 3. グリッド移動
```cs
using UnityEngine;
using GameLib2D.Action;
using GameLib2D.Core;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterGridMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gridSize = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CharacterGridMoveLib.MoveGridRb(rb, moveSpeed, gridSize);
    }
}
```

#### 4. キャラクターの反転
```cs
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
```

#### 5. キャラクターのジャンプ
```cs
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
```
