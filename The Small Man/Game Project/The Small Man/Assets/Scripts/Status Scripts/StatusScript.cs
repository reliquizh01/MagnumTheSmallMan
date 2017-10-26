using UnityEngine;
using System.Collections.Generic;
using System.Collections;
/// <summary>
///  Used as the main script for statuses, prerequisites : DamageOverTime, StatusType, Duration, TargetEnemy.
/// </summary>
public enum StatusType
{
    burnt,
    frozen,
    poisoned,
};
public class StatusScript : MonoBehaviour
{

    public GameObject ThisObject;
    public float duration;
    public StatusType statusType;
    public bool status_Active;
    public int DamageOverTime;
    // Use this for initialization
    void Start()
    {
        ThisObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (status_Active)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                DeActivate();
            }
        }
    }
    public void InEffect()
    {
        ThisObject.GetComponent<AliveScript>().ElementalTakingDamage(DamageOverTime, statusType);
    }
    public void DeActivate()
    {
        switch (statusType)
        {
            case StatusType.burnt:
                ThisObject.GetComponent<AliveScript>().damage_status_burnt = false;
                status_Active = false;
                break;
            case StatusType.frozen:
                ThisObject.GetComponent<AliveScript>().damage_status_frozen = false;
                status_Active = false;
                break;
            case StatusType.poisoned:
                ThisObject.GetComponent<AliveScript>().damage_status_poisoned = false;
                status_Active = false;
                break;
        }
    }
}
