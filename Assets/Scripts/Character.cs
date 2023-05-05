using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public int maxHp = 1000;
    public int currentHp = 1000;

    public int armor = 0;

    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;


    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    private bool isDead;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if(hpRegenerationTimer > 1f ) 
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if(isDead == true) { return; }
        ApplyArmor(ref damage);

        currentHp -= damage;
        if(currentHp <= 0 ) 
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor; //minus armor value from damage taken

        if(damage < 0) { damage = 0; } //don't heal if armor is greater than damage dealth
    }

    public void Heal(int amount) //heals player based on amount
    {
        if(currentHp <= 0 ) //dont heal player at 0 hp
        {
            return;
        }

        currentHp += amount; //adds amount to currentHp variable
        if(currentHp > maxHp) //does not overheal the player
        {
            currentHp = maxHp; //cannot go above maxHP parameter
        }
        hpBar.SetState(currentHp, maxHp);
    }
}
