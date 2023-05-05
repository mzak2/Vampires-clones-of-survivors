using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditorInternal;
using UnityEngine;



[Serializable]
public class EnemyStats
{

    public int hp = 999;
    public int damage = 1;
    public int experience_reward = 400;
    public float moveSpeed = 1f;
    

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.experience_reward= stats.experience_reward;
        this.moveSpeed = stats.moveSpeed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress); //multiplies hp based on time to increase enemy difficult
        this.damage = (int)(damage * progress); //multiplies damage based on time to increase difficulty
    }
}



public class Enemy : MonoBehaviour, IDamagable
{
    Transform targetDestination; //place gameobject (player in this case) to tell it what to follow in inspector
    GameObject targetGameObject;
    Character targetCharacter;


    Rigidbody2D rgdbd2d;

    public EnemyStats stats;

    private void Awake()
    {
        rgdbd2d= GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    internal void UpdateStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }

    private void FixedUpdate() //use fixed update when basing movement on player
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized; //gets players position and this objects position to create vector and normalizes to avoid speed from changing
        rgdbd2d.velocity= direction * stats.moveSpeed; //gives rigidbody speed and will chase the player based on direction variable above
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    private void OnCollisionStay2D(Collision2D collision) //calls this method when a collision occurs between this and another rigidbody2d
    {
        if(collision.gameObject == targetGameObject)   //if collision with another gameobject and it has "Character" script then...
        {
            Attack();

        }
    }

    private void Attack() 
    {
        if(targetCharacter == null) 
        {
            targetCharacter = targetGameObject.GetComponent<Character>(); //call reference to character script on player
        }

        targetCharacter.TakeDamage(stats.damage); //calls the takedamage method from player to minus hp = damage value
    }

    public void TakeDamage(int damage) //method for removing hp value from enemies
    {
        stats.hp -= damage; //hp int minus an int equal to damage variable

        if(stats.hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(stats.experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            EnemyDeathSound.instance.PlayDeathSound();
            Destroy(gameObject); //when Hp of this enemy is less than 1 destroy itself
        }
    }
}
