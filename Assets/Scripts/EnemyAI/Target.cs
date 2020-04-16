using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float hitEffectTime = .3f;
    Color baseColor;
    public Color flashColor = Color.red;
    public MeshRenderer renderer;

    void ColorFlash()
    {
        renderer.material.color = flashColor;
        Invoke("ResetColor", hitEffectTime);
    }

    void ResetColor()
    {
        renderer.material.color = baseColor;
    }

    public void TakeDamage(float amount) {
        ColorFlash();
        health -= amount;
        if (health <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }


    private void Start()
    {
        baseColor = renderer.material.color;
    }
}
