using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeingUnit : MonoBehaviour
{
    public List<GameObject> knownHostiles;

    public virtual void sightedHostile(GameObject hostile)
    {       
    }

    public virtual void lostSightHostile(GameObject hostile)
    {       
    }
}
