using UnityEngine;
using System.Collections;

public class MainHand : HandAction {

    public GameObject WeaponEquipped;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void UseWeapon()
    {
        WeaponEquipped.GetComponent<WeaponScript>().weapon_Activate = true;
    }
    public WeaponType GetWeaponType()
    {
        if (WeaponEquipped == null)
        {
            return WeaponType.hands;
        }
        else
        {
            return WeaponEquipped.GetComponent<WeaponScript>().weaponType;
        }
    }
}
