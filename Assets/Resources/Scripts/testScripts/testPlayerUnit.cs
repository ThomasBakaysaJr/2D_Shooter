using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerUnit : seeingUnit
{ 

    Weapon weapon;

    public bool firing;

    void Start()
    {
        Debug.Log("Start was called");
        //the sight script should be the same for all things that use sight, the parent can change parameters in the script itself but
        //there should only be one sight script.
        this.GetComponentInChildren<testSightScript>().controllerScript = this.GetComponent<testPlayerUnit>();
        //FOR TESTING: HARD CODED WEAPON TYPE
        weapon = new Weapon();
        firing = false;
        lowerWeapon();
    }

    public override void sightedHostile(GameObject hostile)
    {
        if (!knownHostiles.Contains(hostile))
        {
            knownHostiles.Add(hostile);
        }
        checkHostile();
    }

    public override void lostSightHostile(GameObject hostile)
    {
        if (knownHostiles.Contains(hostile))
        {
            knownHostiles.Remove(hostile);
        }
        else
            Debug.Log(this.name + " has not seen " + hostile.name);
        checkHostile();
    }

    void checkHostile   ()
    {
        if(knownHostiles.Count >= 1)
            readyWeapon();
        else
            lowerWeapon();
    }

    void readyWeapon ()
    {
        firing = true;
    }

    void lowerWeapon()
    {
        firing = false;
    }

    IEnumerator ShotDetector()
    {
        if(firing)
        {
            GameControllerScript.Instance.shootWeapon(weapon, transform.position);
        }
        yield return new WaitForSeconds(weapon.properties.firerate);
    }
}
