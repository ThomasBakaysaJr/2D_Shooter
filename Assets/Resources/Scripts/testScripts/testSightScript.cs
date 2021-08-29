using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSightScript : MonoBehaviour
{
    public string id;
    public SeeingUnit controllerScript;

    void Awake()
    {
        id = this.name;
        //soldierControllerScript = this.transform.GetComponent<
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        controllerScript.sightedHostile(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        controllerScript.lostSightHostile(collision.gameObject);
    }
}
