using UnityEngine;
using System.Collections;

/*
    [ARCHIVED]
    Script Name : Boss
    Author : Nurhidayat

    Description : This script was used at the start before 1st Client Meeting.
                  This script holds information of the boss and also handles health calculations of the boss
*/
public class Boss : MonoBehaviour {

    // Private Variables
    // Boss Health
    int i_health;
    // Boss Max Health
    int i_maxHealth;


	// Use this for initialization
	void Start () {
        i_maxHealth = 500;
        i_health = 0;
	}
	

    // Setters
    public void SetBossHealth(int health)
    {
        i_health = health;
    }

    // Getters
    public int GetBossHealth()
    {
        return i_health;
    }

    public int GetBossMaxHealth()
    {
        return i_maxHealth;
    }

    // Methods
    public void MinusBossHealth(int damage)
    {
        i_health -= damage;
        if (i_health < 0)
            i_health = 0;
    }
    public void AddBossHealth(int heal)
    {
        i_health += heal;
        if (i_health > i_maxHealth)
            i_health = i_maxHealth;
    }
}
