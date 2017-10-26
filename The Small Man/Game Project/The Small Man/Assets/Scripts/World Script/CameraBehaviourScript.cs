using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour {

    // Vital Stats
    public GameObject Owner;
    public float statbased_DistanceFromPlayer;
    public float statbased_PlayerRangeofSight;
    public Vector3 mousePosition;
    private Vector3 FreeMovingPosition;
    private Vector3 CharacterLockedPosition;
    // Use this for initialization
    void Start () {
        statbased_PlayerRangeofSight = -20.0f;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = statbased_PlayerRangeofSight;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDistance();
    }
    void UpdateDistance()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = statbased_PlayerRangeofSight;
        float CheckDistance = Vector3.Distance(Owner.transform.position, new Vector3(mousePosition.x, mousePosition.y, 0.0f));
        
        if (!Owner.GetComponent<Player>().Moving && CheckDistance > 15.0f)
        {
            FreeMovingPosition = new Vector3(mousePosition.x, mousePosition.y, statbased_PlayerRangeofSight);
            CharacterLockedPosition = new Vector3(Mathf.Clamp(FreeMovingPosition.x, Owner.transform.position.x-statbased_DistanceFromPlayer, Owner.transform.position.x+statbased_DistanceFromPlayer),   // X Coordinate
                                                              Mathf.Clamp(FreeMovingPosition.y, Owner.transform.position.y - statbased_DistanceFromPlayer, Owner.transform.position.y + statbased_DistanceFromPlayer),   // Y coordinate
                                                              statbased_PlayerRangeofSight);
            transform.position = Vector3.Lerp(transform.position, CharacterLockedPosition, 5 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Owner.transform.position.x, Owner.transform.position.y, statbased_PlayerRangeofSight), 2 * Time.deltaTime);
        }

    }
}
