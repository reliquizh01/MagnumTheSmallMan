using UnityEngine;
using System.Collections;

public class Player : Head {
    public float speed = 5;
    public bool Moving;
    // Player Vital Stats
    private float statbased_InteractionDistance;
    // Mechanics
    public bool ControlOrientation;
    // Calculations
    private Vector3 calculation_previousPosition;
    private Vector3 mousePosition;
    // Use this for initialization
	void Start () {
        InAction = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        CharacterCommands();
        CheckClick();
        //Debug.Log(Moving);
       
    }
   public void Movement()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        //CharacterLook
        if (Focus)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (Input.GetKey(KeyCode.W))
        {
           transform.position = new Vector3(transform.position.x, transform.position.y + speed / 100);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed / 100);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed / 100, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed / 100, transform.position.y);
        }


        // Check 
        if(calculation_previousPosition != transform.position)
        {
            calculation_previousPosition = transform.position;
            Moving = true;
        }
        else
        {
            Moving = false;
        }
    }
   public void Interacting(GameObject thisItem)
    {
        float CheckDistance = Vector3.Distance(transform.position, thisItem.transform.position);

    }
   public void CharacterCommands()
    {
        // Sheathing Weapons
        if (Input.GetKeyDown(KeyCode.X))
        {
            Sheathe = !Sheathe;
            CheckWeaponEquipped();
            MainHand.HoldWeapon();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Focus = !Focus;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ControlOrientation = !ControlOrientation;
        }
    }

    public void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // if Weapon is not Wielded
            if (Sheathe)
            {
                // Check The Object Im Interacting with
                GameObject check = CheckInteraction();
                // If clicked on someone
                if (check)
                {

                }
            }
            // 
            else
            {

            }
        }
    }
    public GameObject CheckInteraction()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null)
        {
            return hit.collider.transform.gameObject;
        }
        else
        {
            return null;
        }
    }

    public void ActivateWeapon()
    {
        MainHand.UseWeapon();
    }
}
