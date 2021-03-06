﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCoral : MonoBehaviour {

    public int baseHealth = 10;
    public int generalEnemeyDamage = 1;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        HitByEnemy(coll);
    }

    private void HitByEnemy(Collider2D damagingObject)
    {
        if (damagingObject.gameObject.CompareTag("Enemy"))
        {
            baseHealth -= generalEnemeyDamage; // Says anytime this object collides with an object tagged "Enemy", the baseHealth of this
            // object will be reduced by the value of generalEnemyDamage
            Debug.Log("The coral has " + baseHealth + " health left.");
            if (baseHealth <= 0)
            {
                FindObjectOfType<GameManagerScript>().LoseGame();
            }
        }
    }
}
