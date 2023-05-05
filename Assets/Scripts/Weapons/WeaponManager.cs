using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;

    [SerializeField] WeaponData startingWeapon;
    List<WeaponBase> weapons;

    private void Awake()
    {
        weapons= new List<WeaponBase>();
    }

    private void Start()
    {
        AddWeapon(startingWeapon); //adds starting weapon to character
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase= weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
        Level level = GetComponent<Level>();
        if(level != null) 
        {
            level.AddUpgradesIntoListOfAvailableUpgrades(weaponData.upgrades);
        }
    }

    public void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
