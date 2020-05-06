using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float hitEffectTime = .3f;
    Color baseColor;
    public Color flashColor = Color.red;
    public MeshRenderer renderer;

    public int damagePoints = 20;
    public int killPoints = 100;

    GameObject scoreObj;

   

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
        else // Occurs if enemy is hit by player but not killed.
        {
            //Adds damagePoints to the total Score of the player on an enemy hit
            ScoreUpdate scoreUpdate = ScoreManager.instance.score.GetComponent<ScoreUpdate>();
            scoreUpdate.setCurrScore(damagePoints);
        }
    }

    void Death()
    {
        Destroy(gameObject);
        //Adds killPoints to the total score of the player on an enemy kill
        ScoreUpdate scoreUpdate = ScoreManager.instance.score.GetComponent<ScoreUpdate>();
        scoreUpdate.setCurrScore(killPoints);
    }

 

    private void Start()
    {
        scoreObj = ScoreManager.instance.gameObject;
        baseColor = renderer.material.color;
    }
}





