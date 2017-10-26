using UnityEngine;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// A parent script used to be inherited by other weapon types.
/// </summary>
public enum WeaponType
{
    hands,
    shield,
    spear,
    sword,
    bow,
    battlehammer,
    mace,
};
public enum WeaponElement
{
    Normal,
    Fire,
    Ice,
    Poison,
};
public class WeaponScript : GeneralItem {

    // Vital Stats
    public WeaponType weaponType;
    public WeaponElement weaponElement;
    public int dmg_Minimum;
    public int dmg_Maximum;
    public int def_Minimum;
    public int def_Maximum;
    // Booleans to Check if Weapon is being used
    public bool weapon_Activate;
    // Passive Stats
    public float criticalChance;
    public float accuracy;
    // Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
    public int CalculateDamage()
    {
        return Random.Range(dmg_Minimum, dmg_Maximum);
    }
    public int CalculateDefense()
    {
        return Random.Range(def_Minimum, def_Maximum);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (weapon_Activate)
        {
            if (collision.gameObject.GetComponent<AliveScript>())
            {
                if (weaponElement != WeaponElement.Normal)
                {
                    switch (weaponElement)
                    {
                        case WeaponElement.Fire:
                            // Instantiate Status_Burn -> Attach to Character
                            break;
                        case WeaponElement.Ice:

                            break;
                        case WeaponElement.Poison:

                            break;
                    }
                }
                else
                {
                    collision.gameObject.GetComponent<AliveScript>().TakingDamagePhysical(CalculateDamage());
                }
            }
        }
    }
}
