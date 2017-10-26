using UnityEngine;
using System.Collections.Generic;
using System.Collections;
/// <summary>
///  A parent script created to be inherited by non-playable/playable characters within the game
///  Has the following:
///  -Character Type
///  -Behaviour Type
///  - Feelings
///  - Food Type
///  - Receive Damage
///     -> Element Damage
///     -> Normal Damage
/// </summary>
public enum CharType
{
    Human,
    Undead,
    Elf,
    Mammal,
    Destructible,
};
public enum BehaviorType
{
    Territorial,
    Nomad,
    Conqueror,
};
public enum Feelings
{
    Threatened,
    Calm,
    Rage,
};
public enum FoodType
{
    Carnivore,
    Omnivore,
    Herbivore,
};
public class AliveScript : MonoBehaviour {
    
    public CharType status_CharType;
    public BehaviorType status_BehaviorType;
    public Feelings status_currentFeelings;
    //Vital Stats
    public float character_HP_cur;
    public float character_HP_max;
    public float character_STAM_cur;
    public float character_STAM_max;
    public float character_ENRGY_cur;
    public float character_ENRGY_max;
    // Passive Stats
    public int character_passive_ArmorResistance;
    public int character_passive_FireResistance;
    public int character_passive_WaterResistance;
    public int character_passive_PoisonResistance;
    public int character_passive_MagicResistance;
    //Status Check
    public bool statusBased_Status_Alive = true;
    public bool statusBased_Combat_Engage = false;
    public bool statusBased_Energy_sleepy = false;
    public bool statusBased_Energy_asleep = false;
    public bool statusBased_Food_hungry = false;
    public bool statusBased_Food_starving = false;
    // Damaging Status
    public bool damage_status_burnt = false;
    public bool damage_status_frozen = false;
    public bool damage_status_poisoned = false;


    public void TakingDamagePhysical(int thisDamage)
    {

        int DamageToReduce = thisDamage / (character_passive_ArmorResistance / 100);
        int TotalDamageTaken = thisDamage - DamageToReduce;
        DamageResult(TotalDamageTaken);
    }
    public void ElementalTakingDamage(int thisDamage, StatusType thisStatus)
    {
        int DamageToReduce = 0;
        int TotalDamageTaken;
        switch (thisStatus)
        {
            case StatusType.burnt:
                DamageToReduce = thisDamage / (character_passive_FireResistance / 100);
                damage_status_burnt = true;
                break;
            case StatusType.frozen:
                DamageToReduce = thisDamage / (character_passive_WaterResistance / 100);
                damage_status_frozen = true;
                break;
            case StatusType.poisoned:
                DamageToReduce = thisDamage / (character_passive_PoisonResistance / 100);
                damage_status_poisoned = true;
                break;
        }
        TotalDamageTaken = thisDamage - DamageToReduce;
        DamageResult(TotalDamageTaken);
    }
    public void TakingDamageMagic(int thisDamage)
    {
        int DamageToReduce = thisDamage / (character_passive_MagicResistance / 100);
        int TotalDamageTaken = thisDamage - DamageToReduce;
        DamageResult(TotalDamageTaken);
    }
    public void DamageResult(int ThisDamage)
    {
        if(character_HP_cur > 0)
        {
            character_HP_cur -= ThisDamage;
        }
        else
        {
            character_HP_cur = 0;
            statusBased_Status_Alive = false;
        }
    }
    public virtual void InteractWithMe() { }
}
