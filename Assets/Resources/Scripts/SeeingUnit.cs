using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingUnit : MonoBehaviour
{
    public List<GameObject> knownHostiles;
    public UnitProperties defaultProperties;
    public UnitProperties currentProperties;

    public Rigidbody2D rigidBody2D;
    public GameObject sightArea;

    public virtual void sightedHostile(GameObject hostile)
    {       
    }

    public virtual void lostSightHostile(GameObject hostile)
    {       
    }
}
