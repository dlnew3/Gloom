using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Invincibility {
    // Start is called before the first frame update
    bool invincibility;
    bool invincibilityRespawn;

    public PickUp_Invincibility()
    {
        invincibility = false;
        invincibilityRespawn = false;
    }

    public void SetInvincibility(bool set)
    {
        if( set == true)
        {
            invincibility = true;
        }
        else invincibility = false;
    }
    public bool GetInvincibilityStatus()
    {
        return invincibility;
    }
    public void SetInvincibilityRespawn(bool set)
    {
        if(set == true)
        {
            invincibilityRespawn = true;
        }
        else invincibilityRespawn = false;

    }
    public bool GetInvincibilityRespawnStatus()
    {
        return invincibilityRespawn;
    }
}
