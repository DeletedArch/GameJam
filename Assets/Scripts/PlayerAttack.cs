using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public SpriteRendererScript spriteRendererScript;

    public void Awake()
    {
        spriteRendererScript = gameObject.GetComponent<SpriteRendererScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool Shoot = Input.GetButtonDown("Fire1");
        if (Shoot)
        {
            spriteRendererScript.isAttacking = true;
            CallAfterDelay.Create(0.2f, () => spriteRendererScript.isAttacking = false);
        }
    }
}
