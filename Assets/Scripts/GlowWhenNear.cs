using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlowWhenNear : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform transform;
    private Vector3 originalScale;
    public float glowAmount = 0.1f; // how much to scale the object for the glow
    public float glowSpeed = 2.0f; // speed of the glow effect
    public bool glow;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (glow)
        {
            float glow = Mathf.Sin(Time.time * glowSpeed) * glowAmount;
            
            transform.localScale = originalScale * (1.0f + glow);

        }

    }
}

