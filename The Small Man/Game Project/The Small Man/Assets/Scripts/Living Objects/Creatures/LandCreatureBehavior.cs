using UnityEngine;
using System.Collections;
/// <summary>
/// Set as a primary Behaviour Tree for All Horneous Creatures
/// </summary>
public class LandCreatureBehavior : AliveScript
{
    private int statusNumber;
    // Calculations
    private Vector3 LookAtPosition;
    private Transform LockedTarget;

    // Movements
    private bool Focus;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FacingOrientation();
    }
    public void FacingOrientation()
    {
        if (Focus)
        {
            transform.right = LockedTarget.position - transform.position;
            
        }
        else
        {

        }
    }

    // Obtain Next Position Depending on Behavior
    Vector3 ObtainNextPosition()
    {
        Vector3 NewPosition = new Vector3();
        switch (status_BehaviorType)
        {
            case BehaviorType.Territorial:
                /*
                 *  Requires to have Food Nearby
                 */
                break;
            case BehaviorType.Conqueror:
                /*
                 * Eats up all the food quickly and once the food is gone goes to another territory
                 * that has the same food type
                 */
                break;
            case BehaviorType.Nomad:
                /*
                 * Keeps on roaming to safe places, eats the food nearest to them.
                 */
                break;
        }
        return NewPosition;
    }
    // Check Status of the creature
    int CheckStatus()
    {
        int status = new int();
        if (!statusBased_Combat_Engage)
        {
            if (statusBased_Food_hungry || statusBased_Food_starving)
            {
                status = 2;
            }
            else if (statusBased_Energy_sleepy)
            {
                status = 3;
            }
        }
        else
        {
            status = 1;
        }
        return status;
    }
    // Check if the Person in Sight
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if Part of the Body or Not
        if (collision.transform.parent)
        {
            if (collision.transform.parent.GetComponent<AliveScript>())
            {
                LockedTarget = collision.transform.parent.transform;
                Focus = true;
            }
        }
    }
    // Check Relationship with the creature on sight
    public void CheckRelationship(GameObject thisObject)
    {

    }
    /* BASIC MOVEMENTS
     * 1.) Vision
     *        - What to do if he sees :
     *            a.  Neutral
     *            b.  Ally
     *            c.  Enemy
     *  2.) Movement
     *        - Based on the situation :
     *            a. Engaging Enemy
     *            b. Hungry
     *            c. Sleepy
     */
}
