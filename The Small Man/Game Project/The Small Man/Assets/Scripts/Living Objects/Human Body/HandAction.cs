using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum HandType
{
    MainHand,
    OffHand,
};
public class HandAction : MonoBehaviour {

    public GameObject Head;
    public HandType HandType;
    public int CurrentAction;
    public float IdlePosition;
    public List<Sprite> React_Actions = new List<Sprite>();
    private bool ReactingToSomething;
    // Calculations
    private Vector3 currentContactPoint;
    private Vector3 currentPosition;
    private Vector3 stayPosition;
    private float CheckDistance;
    private bool HeldWeapon;
    // Use this for initialization
	void Start () {
            stayPosition = transform.localPosition ;
            HeldWeapon = false;
	}

    // Update is called once per frame
    void Update() {
        if (!GetComponentInParent<Player>().InAction)
        {
            Sheathed();
        }
	}
    private void Sheathed()
    {
        CheckDistance = Vector3.Distance(transform.localPosition, stayPosition);
        if (ReactingToSomething && CheckDistance < 0.75f)
        {
            transform.localPosition = new Vector3(0.0f, IdlePosition, 0.0f);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            transform.position = currentPosition;
        }
        else if (!GetComponentInParent<Player>().Sheathe)
        {
            transform.localPosition = new Vector3(0.0f, IdlePosition, 0.0f);
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }
        else if(!ReactingToSomething)
        {
            transform.localPosition = new Vector3(0.0f, IdlePosition, 0.0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /// REACTION ACTIONS:   Actions that takes place when the player is not wielding his sword
        ///                                        used to interacting with environment, such as touching walls.  
        if (GetComponentInParent<Player>().Sheathe)
        {
           CheckDistance = Vector3.Distance(transform.localPosition, stayPosition);
                if (CheckDistance < 0.75f )
                {

                    ContactPoint2D contact = collision.contacts[0];
                    Vector3 contactpoint = contact.point;
                    Debug.Log(contactpoint);
                    if (collision.gameObject.tag == "Obstruction")
                    {
                        currentPosition = transform.position;
                        ReactingToSomething = true;
                        CurrentAction = 1;
                        GetComponent<SpriteRenderer>().sprite = React_Actions[1];
                    }
                }
                else
                {
                    ReactingToSomething = false;
                }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        /// REACTION ACTIONS:   Actions that takes place when the player is not wielding his sword
        ///                                        used to interacting with environment, such as touching walls.  
        if (GetComponentInParent<Player>().Sheathe)
        {
            transform.localPosition = new Vector3(0.0f, IdlePosition, 0.0f);
             transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            ReactingToSomething = false;
            CurrentAction = 0;
            GetComponent<SpriteRenderer>().sprite = React_Actions[0];
        }
    }

    public void HoldWeapon()
    {
        HeldWeapon = !HeldWeapon;
        transform.GetChild(0).gameObject.SetActive(HeldWeapon);
        
        if (HeldWeapon)
        {
            GetComponent<SpriteRenderer>().sprite = React_Actions[2];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = React_Actions[0];
            // Returns the Animation to Hands only Upon sheathing the sword
            Head.GetComponent<Animator>().SetInteger("Weapon Wielded", 0);
            Head.GetComponent<Animator>().SetFloat("CurrentBehaviour", 0);
        }
    }
    public void colliderSwitch(bool thisSwitch)
    {
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }
}
