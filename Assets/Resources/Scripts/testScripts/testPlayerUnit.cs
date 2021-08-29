using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerUnit : SeeingUnit
{ 

    public Weapon weapon;

    public bool shooting;

    void Start()
    {
        //the sight script should be the same for all things that use sight, the parent can change parameters in the script itself but
        //there should only be one sight script.
        
        this.GetComponentInChildren<testSightScript>().controllerScript = this.GetComponent<testPlayerUnit>();
        //FOR TESTING: HARD CODED WEAPON TYPE
        //weapon = gameObject.AddComponent<Weapon>();
        shooting = false;
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
        //if  not shooting, start shooting. This should stop from double firing or something else stupid like that
        if (!shooting)
            StartCoroutine("startShooting");
    }

    void lowerWeapon()
    {
        shooting = false;
    }

   IEnumerator startShooting()
    {
        shooting = true;
        while(shooting)
        {
            GameControllerScript.Instance.shootWeapon(weapon);
            yield return new WaitForSeconds(weapon.properties.firerate);
        }
    }
}
