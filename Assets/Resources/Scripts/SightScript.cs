using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{
    public SeeingUnit attachedUnit;
    public BoxCollider2D thisCollider;

    //should be attached to a child object of the actual unit. Will create the collider
    void Start()
    {
        attachedUnit = GetComponentInParent<SeeingUnit>();
        thisCollider = gameObject.AddComponent<BoxCollider2D>();
        thisCollider.isTrigger = true;
        thisCollider.size = new Vector2(attachedUnit.currentProperties.sightRange, 2f);
        thisCollider.offset = new Vector2(thisCollider.size.x / 2, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        attachedUnit.sightedHostile(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        attachedUnit.lostSightHostile(collision.gameObject);
    }
}
