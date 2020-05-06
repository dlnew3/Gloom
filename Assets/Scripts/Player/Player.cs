using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
	//Used for the Regeneration and Degeneration Pick-Ups: Acts as the interval in which the Player gets Healed/Damaged.
	public float interpolationPeriod = 0.5f;

	public float RegenerationDuration;
	public float DegenerationDuration;
	public float InvincibilityDuration;

	public float InvincibilityRespawnDuration;
	public float HealthRespawnDuration;
	public float RegenerationRespawnDuration;
	public float DegenerationRespawnDuration;
	
	
	/*All Timers are left to be initialized to 0*/
	public float RegenerationTimer = 0.0f;
	public float DegenerationTimer = 0.0f;
	public float InvincibilityTimer = 0.0f;
	
	public float HealthRespawnTimer = 0.0f;
	public float InvincibilityRespawnTimer = 0.0f;
	public float MaxHealthRespawnTimer = 0.0f;
	public float RegenerateHealthRespawnTimer = 0.0f;
	public float DegenerateHealthRespawnTimer = 0.0f;
	public int counterDegenerate = 0;
	public int counterRegenerate = 0;
	public int maxDegenerate;
	public int maxRegenerate;

	//Instantiate an Object from the HealthBar class	
	public HealthBar healthBar;
	//Instantiating an Object from the HealthSystem class and using the Constructor to initialize Max Health of Player to 200.
	HealthSystem healthSystem = new HealthSystem(200);
	//Instantiating an Object from the PickUp_Invincibility class
	PickUp_Invincibility invincible = new PickUp_Invincibility();

	//The Following are Objects correlating to each Perk available
	public GameObject HealthBox;
	public GameObject InvincibilityBox;
	public GameObject MaxHealthBox;
	public GameObject RegenerateBox;
	public GameObject DegenerateBox;


	/*NEW ADDITIONS FOR FINAL ITERATION*/


	public GameObject my_pistol;
	Weapon my_pistol_script;
	public GameObject my_shotgun;
	Weapon my_shotgun_script;
	public GameObject my_SMG;
	Weapon my_SMG_script;


	public GameObject my_instantkill;
	Weapon my_instantkill_script;


	public float InfinitePistolDuration;
	public float InfiniteShotgunDuration;
	public float InfiniteSMGDuration;
	public float InstantKillDuration;
	public float InfinitePistolTimer = 0.0f;
	public float InfiniteShotgunTimer = 0.0f;
	public float InfiniteSMGTimer = 0.0f;
	public float InstantKillTimer = 0.0f;
	public bool instantKillPerk = false;

	/*FOR TESTING PURPOSES
	public float currPow;
	public float currAcc;
	*/

	void Start()
	{
		//We are initializing the Health Bar
		healthBar.SetMaxHealth(healthSystem.GetHealth());
		maxRegenerate = (int)(RegenerationDuration / interpolationPeriod);
		maxDegenerate = (int)(DegenerationDuration / interpolationPeriod);


		/*NEW ADDITIONS FOR FINAL ITERATION*/
		my_pistol_script = my_pistol.GetComponent<Weapon>();
		my_shotgun_script = my_shotgun.GetComponent<Weapon>();
		my_SMG_script = my_SMG.GetComponent<Weapon>();
		my_instantkill_script = my_instantkill.GetComponent<Weapon>();

		/*FOR TESTING PURPOSES
		currPow = my_instantkill_script.ReturnPower();
		currAcc = my_instantkill_script.ReturnAcc();
		*/
	}
	void Update()
	{
		/*FOR TESTING PURPOSES
		currPow = my_insantkill_script.ReturnPower();
		currAcc = my_instantkill_script.ReturnAcc();
		*/
		/*The first if block checks if the Inivincibility Perk was enabled. 
		 * If so, we start our timer and once it exceeds our time period, we
		 * disable the Perk effect and reset our timer.*/
		if (invincible.GetInvincibilityStatus())
        {
			healthBar.SetFillColor();
			InvincibilityTimer += Time.deltaTime;
			if (InvincibilityTimer > InvincibilityDuration)
            {
				invincible.SetInvincibility(false);
				InvincibilityTimer = 0.0f;
				healthBar.RevertFillColor();
			}
		}
		/*The second if block checks if the Invincibility Perk was told to respawn, if so,
		 * we start our respective timer, and once it exceeds our time period, we respawn the perk.
		 */
		if (invincible.GetInvincibilityRespawnStatus())
		{
			InvincibilityRespawnTimer += Time.deltaTime;
			if (InvincibilityRespawnTimer > InvincibilityRespawnDuration)
			{
				invincible.SetInvincibilityRespawn(false);
				InvincibilityRespawnTimer = 0.0f;
				InvincibilityBox.gameObject.SetActive(true);
			}
		}
		/*The third if block checks if the Health Perk was told to respawn, if so,
		 we start out respective timer, and once it exceeds our time period, we respawn the perk.*/
		if (healthSystem.GetHealthRespawnStatus())
		{
			HealthRespawnTimer += Time.deltaTime;
			if (HealthRespawnTimer > HealthRespawnDuration)
			{
				healthSystem.SetHealthRespawn(false);
				HealthRespawnTimer = 0.0f;
				HealthBox.gameObject.SetActive(true);
			}
		}
		/*The fourth if block checks if the Regenerate Perk was told to respawn, if so, we start
		 * both timers. The nested if checks if invincibility is active, if the regenerationlength timer is greater than our
		 * set interpolation period, and if our counter is less than 10. Essentially, when our code notices that the Regeneration Perk
		 * was triggered, a timer starts and this timer is compared to our interpolation const time (this enables us to choose how often the
		 * player should get healed. For example, if interpolation period is = 1.0f, then we will heal every 1 second.) The counter is
		 * used to keep track of how many times we've entered the "healing" stage. We can use this to limit how long the effect can last.
		 * For example, if interpolation period = 1.0f and our counter restriction is 10, then that means the effect will last for 10 second. (10/1)
		 * Once all 3 conditions are met, we increase counter, Reset our regeneration timer, heal, update the health bar, and keep the color
		 *  of our health bar silver, because we still have invincibility.
		 * Now we check the else if condition, which is the same as before instead of the invincibility check. We continue with
		 * the same proceedings the only difference is that we do not keep the color of the health bar silver.
		 * This whole time the RegenerateHealthRespawn timer has been increasing, the finl if checks is this value has
		 * exceeded our set time, if so we respawn the perk, and reset all respective variables.
		 */
        if (healthSystem.GetRegenerateRespawnStatus())
        {
			RegenerateHealthRespawnTimer += Time.deltaTime;
			RegenerationTimer += Time.deltaTime;
			if (invincible.GetInvincibilityStatus() && RegenerationTimer >= interpolationPeriod && counterRegenerate <= maxRegenerate)
			{
				counterRegenerate++;
				RegenerationTimer = 0.0f;
				healthSystem.Heal(10);
				healthBar.SetHealth(healthSystem.GetHealth());
				healthBar.SetFillColor();
			}
			else if (RegenerationTimer >= interpolationPeriod && counterRegenerate <= maxRegenerate)
            {
				counterRegenerate++;
				RegenerationTimer = 0.0f;
				healthSystem.Heal(10);
				healthBar.SetHealth(healthSystem.GetHealth());
			}
            
			if(RegenerateHealthRespawnTimer > RegenerationRespawnDuration)
            {
				healthSystem.SetRegenerateRespawn(false);
				RegenerateHealthRespawnTimer = 0.0f;
				RegenerationTimer = 0.0f;
				RegenerateBox.gameObject.SetActive(true);
				counterRegenerate = 0;
			}
		}
		/*Same concept as Regenerate above, except that it is tailored for the Degenerate Perk (damage instead of heal)
		 Also, when we are invincible damage will not be taken from this anti-perk*/
		if (healthSystem.GetDegenerateRespawnStatus())
		{
			DegenerateHealthRespawnTimer += Time.deltaTime;
			DegenerationTimer += Time.deltaTime;
			if (invincible.GetInvincibilityStatus() && DegenerationTimer >= interpolationPeriod && counterDegenerate <= maxDegenerate)
            {
				counterDegenerate++;
				DegenerationTimer = 0.0f;
			}
			else if (DegenerationTimer >= interpolationPeriod && counterDegenerate <= maxDegenerate)
			{
				counterDegenerate++;
				DegenerationTimer = 0.0f;
				healthSystem.Damage(5);
				healthBar.SetHealth(healthSystem.GetHealth());
			}

			if (DegenerateHealthRespawnTimer > DegenerationRespawnDuration)
			{
				healthSystem.SetDegenerateRespawn(false);
				DegenerateHealthRespawnTimer = 0.0f;
				DegenerationTimer = 0.0f;
				DegenerateBox.gameObject.SetActive(true);
				counterDegenerate = 0;
			}

		}
		/*WORK IN PROGRESS
		if (healthSystem.GetMaxStatus())
		{
			MaxHealthRespawn += Time.deltaTime;
			if (MaxHealthRespawn > 5.0f)
			{
				healthSystem.DisableMaxRespawn();
				MaxHealthRespawn = 0.0f;
				MaxHealthBox.gameObject.SetActive(true);
			}
		}*/



		/*NEW ADDITIONS FOR FINAL ITERATION*/
		if (my_pistol_script.InfiniteStatus())
        {
			InfinitePistolTimer += Time.deltaTime;
			if (InfinitePistolTimer > InfinitePistolDuration)
			{
				my_pistol_script.InfiniteAmmo(false);
				InfinitePistolTimer = 0.0f;
			}
		}
		if (my_shotgun_script.InfiniteStatus())
		{
			InfiniteShotgunTimer += Time.deltaTime;
			if (InfiniteShotgunTimer > InfiniteShotgunDuration)
			{
				my_shotgun_script.InfiniteAmmo(false);
				InfiniteShotgunTimer = 0.0f;
			}
		}
		if (my_SMG_script.InfiniteStatus())
		{
			InfiniteSMGTimer += Time.deltaTime;
			if (InfiniteSMGTimer > InfiniteSMGDuration)
			{
				my_SMG_script.InfiniteAmmo(false);
				InfiniteSMGTimer = 0.0f;
			}
		}
		if (instantKillPerk)
		{
			InstantKillTimer += Time.deltaTime;
			if (InstantKillTimer > InstantKillDuration)
			{
				instantKillPerk = false;
				InstantKillTimer = 0.0f;
                my_instantkill_script.SetPower(15.0f);
                my_instantkill_script.SetAccuracy(80.0f);
			}
		}

	}

	void OnTriggerEnter(Collider other)
    {
		/*The first if block checks if the Player picked up the Invincible Perk,
		 * if so, we set the object activity to false(despawn), let the program know it should respawn the perk,
		 * and set the Invincibility to true.*/
		if (other.gameObject.CompareTag("InvinciblePerk"))
		{
			other.gameObject.SetActive(false);
			invincible.SetInvincibilityRespawn(true);
			invincible.SetInvincibility(true);
		}
		/*The second if block checks if the Player picked up the Health Perk, if so, we
		 * despawn the Perk, heal the Player, and update the Health Bar*/
		if (other.gameObject.CompareTag("HealthPerk"))
		{
			other.gameObject.SetActive(false);
			healthSystem.SetHealthRespawn(true);
			healthSystem.Heal(30);
			healthBar.SetHealth(healthSystem.GetHealth());
		}
		/*The third if block checks if we picked up the Regenerate Perk, if so, 
		 * we despawn it and let the program know it should respawn the perk*/
		if (other.gameObject.CompareTag("RegeneratePerk"))
		{
			other.gameObject.SetActive(false);
			healthSystem.SetRegenerateRespawn(true);
		}
		/*The fourth if block checks if we picked up the Degenerate Perk, if so, 
		 * we despawn it and let the program know it should respawn the perk*/
		if (other.gameObject.CompareTag("DegenerateHealth"))
		{
			other.gameObject.SetActive(false);
			healthSystem.SetDegenerateRespawn(true);
			
		}
		/*
		 * WORK IN PROGRESS, AT THE MOMENT THE PERK TO INCREASE MAX HEALTH IS NOT WORKING PROPERLY
		if (other.gameObject.CompareTag("MaxHealthPerk"))
		{
			other.gameObject.SetActive(false);
			healthSystem.EnableMaxRespawn();
			healthSystem.UpdateMaxHealth(200);
			healthBar.UpdateMaxHealth(healthSystem.GetHealth());
		}
		*/


		/*NEW ADDITIONS FOR FINAL ITERATION*/
		if (other.gameObject.CompareTag("InfiniteAmmo"))
		{
			other.gameObject.SetActive(false);
			my_pistol_script.InfiniteAmmo(true);
			my_shotgun_script.InfiniteAmmo(true);
			my_SMG_script.InfiniteAmmo(true);
		}
		if (other.gameObject.CompareTag("InstantKill"))
		{
			other.gameObject.SetActive(false);
			instantKillPerk = true;
			my_instantkill_script.SetPower(10000000.0f);
			my_instantkill_script.SetAccuracy(101.0f);
		}
	}
	
    // Appended by Dennis for use with pre-existing enemy model
    public void EnemyDamage(int damage)
    {
        if (!invincible.GetInvincibilityStatus())
        {
            healthSystem.Damage(damage);
            healthBar.SetHealth(healthSystem.GetHealth());
            if(healthSystem.GetHealth() <= 0)
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
                //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(nextSceneIndex));
            }
            
        }
    }

}
