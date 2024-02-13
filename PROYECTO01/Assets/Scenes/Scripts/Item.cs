using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public string Type;
    public string Description;
    public Sprite Icon;
    public string Name;

    [HideInInspector]
    public bool recogido;

    [HideInInspector]
    public bool equipped;

    public GameObject weaponManager;
    public GameObject weapon;

    public bool playersWeapon;



    private void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        if (!playersWeapon)
        {
            int allweapons = weaponManager.transform.childCount;
            for (int i = 0; i < allweapons; i++) 
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().itemID == itemID)
                {
                    weapon=weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }
    private void Update()
    {
        if(equipped)
        {
            if (Input.GetKeyUp(KeyCode.E)) 
            {
                equipped = false;
            }
            if (equipped==false)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void ItemUsage()
    {
        if (Type == "weapon")
        {
            weaponManager.SetActive(true);
            weaponManager.GetComponent<Item>().equipped = true;
        }
    }
}
