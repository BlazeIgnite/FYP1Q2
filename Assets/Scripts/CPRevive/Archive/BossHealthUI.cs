using UnityEngine;
using System.Collections;

/*
    [ARCHIVED]
    Script Name: Boss Health UI
    Author : Nurhidayat
 
    Description : This script handles the UI for the boss health
*/

public class BossHealthUI : MonoBehaviour {

    // This function is called everytime in Boss script
    public void UpdateHealth()
    {
        Boss boss = GameObject.Find("Boss").GetComponent<Boss>();

        float bossHP = boss.GetBossHealth();
        float bossMaxHP = boss.GetBossMaxHealth();
        float scale = bossHP / bossMaxHP;
        transform.localScale = new Vector3(scale, 1);
    }

}
