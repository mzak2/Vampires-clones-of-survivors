using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock, //greg renames this to WeaponGet
    ItemUnlock //greg renames this to ItemGet
}


[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;

    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;

   
    public Item item;
    public ItemStats itemStats;
}
