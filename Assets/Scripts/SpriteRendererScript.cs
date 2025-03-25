using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererScript : MonoBehaviour
{
    private SpriteRenderer spriteRendererObj;
    public Sprite[] sprites;
    public Sprite[] IdleSprites;
    public Sprite[] AttackSprites;
    private int spriteIndex = 0;
    public float spriteRate = 0.1f;
    public bool isRunning = false;
    public bool isIdling = false;
    public bool isAttacking = false;
    void Awake()
    {
        spriteRendererObj = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AnimateSprite", 0, spriteRate);
    }

    void AnimateSprite()
    {
        if (isRunning)
        {
            spriteIndex++;
            if (spriteIndex >= sprites.Length)
            {
                spriteIndex = 0;
            }
            spriteRendererObj.sprite = sprites[spriteIndex];
        }

        if (isIdling)
        {
            spriteIndex++;
            if (spriteIndex >= IdleSprites.Length)
            {
                spriteIndex = 0;
            }
            spriteRendererObj.sprite = IdleSprites[spriteIndex];
        }
        if (isAttacking)
        {
            spriteIndex++;
            if (spriteIndex >= AttackSprites.Length)
            {
                spriteIndex = 0;
            }
            spriteRendererObj.sprite = AttackSprites[spriteIndex];
        }

    }
}
