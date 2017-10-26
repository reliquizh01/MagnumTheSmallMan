using UnityEngine;
using System.Collections;

public class OffHand : HandAction {

    public GameObject WeaponEquipped;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // CHECK WEAPON TYPE
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
