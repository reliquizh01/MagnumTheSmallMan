using UnityEngine;
using System.Collections;

public class GeneralItem : MonoBehaviour {
    public string ItemName;
    public float durability;
    public string Description;


    // Sets the Description
    public virtual void SetDescription(string text)
    {
        Description = text;
    }
}
