using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WhipWeapon : WeaponBase
{

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMove playerMove;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f); //adjust whip size and hit box

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if (e != null) //checks to make sure Enemy exists
            {
                PostMessage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage); //gets the component from any colliders hit in attack and calls the TakeDamage metthod to remove HP based on whip damage
            }
        }
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f); //detects all colliders that the whip hits
                ApplyDamage(colliders); //cycles through all of the colliders names so we can apply Damage to them
            }
            else
            {
                leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f); //detects all colliders that the whip hits
                ApplyDamage(colliders); //cycles through all of the colliders names so we can apply Damage to them
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
