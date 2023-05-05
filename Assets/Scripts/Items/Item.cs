using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor = 0;
    public float hpRegenerationRate = 0f; //variable to define a stat
    public float speed = 0f; //movespeed item 
    

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
        hpRegenerationRate -= stats.hpRegenerationRate; // giving stat selection to item
        speed += stats.speed; //movespeed item 
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    public void Equip(Character character)
    {
        character.armor += stats.armor;
        character.hpRegenerationRate -= stats.hpRegenerationRate; //adds new item to character when equipped, stats are not applied here
    }

    public void UnEquip(Character character) 
    {
        character.armor -= stats.armor;
        character.hpRegenerationRate += stats.hpRegenerationRate; //removes item when new instance
    }

    public void IncreaseMovementSpeed(PlayerMove playerMove) //movespeed item 
    {
        playerMove.speed += stats.speed;
    }

    public void DecreaseMovementSpeed(PlayerMove playerMove) //movespeed item 
    {
        playerMove.speed -= stats.speed;
    }
}
