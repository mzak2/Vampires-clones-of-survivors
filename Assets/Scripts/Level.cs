using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;

    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanel;


    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField] List<UpgradeData> acquiredUpgrades;

    WeaponManager weaponManager;
    PassiveItems passiveItems;

    [SerializeField] List<UpgradeData> upgradesAvailableOnStart;

    private void Awake()
    {
        weaponManager= GetComponent<WeaponManager>();
        passiveItems= GetComponent<PassiveItems>();
    }

    int TO_LEVEL_UP
    {
        get
        {
            return level * 500; //original value was 1000, took to long to level up, reduced to 500
        }
    }

    internal void AddUpgradesIntoListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null) { return; } //exit gate to avoid making new lists
        this.upgrades.AddRange(upgradesToAdd);
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        AddUpgradesIntoListOfAvailableUpgrades(upgradesAvailableOnStart);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if(acquiredUpgrades == null) { acquiredUpgrades= new List<UpgradeData>(); }


        switch(upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                if (upgradeData.item != null) //if the upgrade data is left empty instead of the EmptyItem placeholder is used, then it should skip
                {
                    passiveItems.Equip(upgradeData.item); //added to test barb armor+ functionallity, **works**
                }
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(upgradeData.item);
                AddUpgradesIntoListOfAvailableUpgrades(upgradeData.item.upgrades);
                break;
        }

        acquiredUpgrades.Add(upgradeData); //adds upgrade to player
        upgrades.Remove(upgradeData); //removes acquired upgrade from pool
    }

    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if(selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); } //store the 3 upgrades that we initially give the player
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        upgradePanel.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList =  new List<UpgradeData>();

        if(count > upgrades.Count) //if game goes long enough, then player will have no more upgrades to select
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++) //get random upgrades from our list to choose from
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }


}
