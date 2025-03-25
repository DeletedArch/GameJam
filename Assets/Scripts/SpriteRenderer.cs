using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererScript : MonoBehaviour
{
    private SpriteRenderer spriteRendererObj;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    public float spriteRate = 0.1f;
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
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRendererObj.sprite = sprites[spriteIndex];
    }
}
