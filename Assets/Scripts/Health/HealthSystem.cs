using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*READ ME FIRST TO UNDERSTAND THE PURPOSE OF THIS CODE
    :This class is meant to be implemented to any object, it is of type non monobehavior, so that they
    operate similarily to classes outside of Unity. This class is implemented to the Player object, and can be 
    referenced by any other object that should have health.*/
public class HealthSystem
{
    private int Maxhealth;
    private int currHealth;
    private bool HealthRespawn;
    private bool MaxHealthRespawn;
    private bool RegenerateRespawn;
    private bool DegenerateRespawn;

    /*Constructor to initialize health. Make sure to pass a parameter in the respective script that references this class when 
     a new object instance is created.*/
    public HealthSystem(int health)
    {
        Maxhealth = health;
        currHealth = Maxhealth;
        HealthRespawn = false;
    }
    public int GetHealth()
    {
        return currHealth;
    }
    public void Damage(int damageAmount)
    {
        currHealth -= damageAmount;
        if (currHealth < 0)
        {
            currHealth = 0;
        }
    }
    public void Heal(int healAmount)
    {
        currHealth += healAmount;
        if (currHealth > Maxhealth)
        {
            currHealth = Maxhealth;
        }
    }
    //FOR HEALTH PERK
    public void SetHealthRespawn(bool set)
    {
        if (set == true)
        {
            HealthRespawn = true;
        }
        else HealthRespawn = false;
    }
    public bool GetHealthRespawnStatus()
    {
        return HealthRespawn;
    }
    //FOR REGENERATE PERK
    public void SetRegenerateRespawn(bool set)
    {
        if (set == true)
        {
            RegenerateRespawn = true;

        }
        else RegenerateRespawn = false;
    }
    public bool GetRegenerateRespawnStatus()
    {
        return RegenerateRespawn;
    }
    //FOR DEGENERATE PERK 
    public void SetDegenerateRespawn(bool set)
    {
        if (set == true) {
            DegenerateRespawn = true;
        }
        else DegenerateRespawn = false;
    }
    public bool GetDegenerateRespawnStatus()
    {
        return DegenerateRespawn;
    }

    /*WORK IN PROGRESS
    public int GetMaxHealth()
    {
        return Maxhealth;
    }
    public void UpdateMaxHealth(int Max)
    {
        if (currHealth == Maxhealth)
        {
            Maxhealth += Max;
            currHealth = Maxhealth;
        }
        else
        {
            Maxhealth += Max;
        }
    }
    public void SetMaxRespawn(bool set)
    {
        if (set = true)
        {
            MaxHealthRespawn = true;
        }
        else MaxHealthRespawn = false;
    }
    public bool GetMaxRespawnStatus()
    {
        return MaxHealthRespawn;
    }
    */
}
