using UnityEngine;
using System.Collections;
/// <summary>
///  This script is the brain of a creature, it is capable of the following
///  1.) This is where equipping items is/are.
///  2.) This is where the player receives the Damage
///         -> Calculates the Damage.
///   3.) Can Remove or Add a script that has the skillset
///   4.) Handles  the Animation type
/// </summary>
public class Head : AliveScript {

    // Body Parts
    public MainHand MainHand;
    public OffHand OffHand;
    //---------------------------------------------------
    public bool Sheathe;
    public bool Focus;
    public bool LockedTarget;
    public bool InAction;
    public void CheckWeaponEquipped()
    {
        WeaponType MainHandEquipped = MainHand.GetWeaponType();
        WeaponType OffHandEquipped = OffHand.GetWeaponType();
        Debug.Log("Mainhand: " + MainHandEquipped.ToString() + "  Offhand: " + OffHandEquipped.ToString());
        switch (MainHandEquipped)
        {
            case WeaponType.sword:
                if (OffHandEquipped == WeaponType.hands) SetAnimationType(1);
                else { }
                break;
        }
    }
    public void WeaponCombination()
    {

    }
    public void SetAnimationType(int WeaponNumber)
    {
        GetComponent<Animator>().SetInteger("Weapon Wielded", WeaponNumber);
    }
    public void SetIdleEquip()
    {
        GetComponent<Animator>().SetFloat("CurrentBehaviour", 1);
    }
}
