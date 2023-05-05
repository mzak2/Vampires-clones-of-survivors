using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThrowingKnife : WeaponBase
{


    [SerializeField] GameObject knifePrefab;
    [SerializeField] float spread = 0.5f; //offsets the spawning of multiple knives

    PlayerMove playerMove; //variable to define player movement

    private void Awake()
    {
        playerMove= GetComponentInParent<PlayerMove>(); // gets player position 
    }


    public override void Attack()
    {
        
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) //determines number of knives that we could maximallyt throw
        {
            GameObject thrownKnife = Instantiate(knifePrefab); //creates variable to spawn the knife

            Vector3 newKnifePosition = transform.position;
            if(weaponStats.numberOfAttacks > 1) //makes it only more than 1 knife to spawn offset of 0, otherwise its direct from player
            {
                newKnifePosition.y -= (spread * weaponStats.numberOfAttacks-1) / 2; //calculates offset of knives
                newKnifePosition.y += i * spread; //spreadomg tje knives along a line
            }

            

            thrownKnife.transform.position = newKnifePosition; //dictates the spawn location of the knife
            ThrowingKnifeProjectile throwingKnifeProjectile = thrownKnife.GetComponent<ThrowingKnifeProjectile>();
            thrownKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f); //sets direction of the throwing knife based on player movement direction
            throwingKnifeProjectile.damage = weaponStats.damage;
        }
    }
}
