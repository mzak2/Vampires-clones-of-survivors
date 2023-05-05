using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;

    Character character;
    PlayerMove playerMove; //movespeed item 

  

    public void Awake()
    {
        character= GetComponent<Character>();
        playerMove= GetComponent<PlayerMove>(); //movespeed item 
    }

    private void Start()
    {
        
    }

    public void Equip(Item itemToEquip)
    {
        if (items == null)
        {
            items = new List<Item>();
        }
        
        Item newItemInstance = Item.CreateInstance<Item>(); 
        newItemInstance.Init(itemToEquip.Name);

        newItemInstance.stats.Sum(itemToEquip.stats);


        items.Add(newItemInstance); //adds new item to list
        newItemInstance.Equip(character);
        newItemInstance.IncreaseMovementSpeed(playerMove); //movespeed Item 
    }

    public void UnEquip(Item itemToEquip) 
    {

    }

    internal void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name); //finds the item to place on character and places it
        itemToUpgrade.UnEquip(character); //unequip to reset stats
        itemToUpgrade.DecreaseMovementSpeed(playerMove); //movespeed item 
        itemToUpgrade.stats.Sum(upgradeData.itemStats); //sums the two items together if multiple
        itemToUpgrade.Equip(character); // adds stats back to character to completely reset the values properly
        itemToUpgrade.IncreaseMovementSpeed(playerMove); //movespeed item 
    }
}
