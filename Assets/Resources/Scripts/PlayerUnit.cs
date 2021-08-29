using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : SeeingUnit
{
    public bool shooting;
    //data that comes with the player, since they don't have to be attached to an object.
    //Changing these after the weapon has been instantiated and attached won't change the actual weapon
    public Attachments attachments;
    public WeaponProperties weaponPropeties;

    //doesn't come with this. The weapon will be built in scene using the prefabs.
    //This should never be called by any other function directly.
    Weapon weapon;

    void Start()
    {
        StartCoroutine("waitForController");
    }

    //wait for the controller to initialize and then do your things
    IEnumerator waitForController()
    {
        while (!GameControllerScript.Instance.finishedStartup) yield return new WaitForSeconds(0.05f);
        defaultProperties.name = "Yoooo";
        defaultProperties.copy(currentProperties);
        //the sight script should be the same for all things that use sight, the parent can change parameters in the script itself but
        //there should only be one sight script.
        sightArea = new GameObject();
        sightArea.transform.position = transform.position;
        //set the sight area as a child to this object (important or the sight script will be lost :( );
        sightArea.transform.SetParent(transform);
        sightArea.AddComponent<SightScript>();

        //ask for weapon
        GameObject weaponObj = GameControllerScript.Instance.getWeapon(weaponPropeties.weaponCode);
        //attache the weapon to the player
        weaponObj.transform.SetParent(transform);
        weaponObj.transform.position = transform.position;
        weapon = new Weapon();
        weapon.setUpWeapon(weaponObj, weaponPropeties, attachments);


        shooting = false;
        lowerWeapon();
    }


    /*
     * WILL NEED TO ACTUALLY IMPLEMENT PLAYER FUNCTIONS PROPERLY
     * 
     */


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

    void checkHostile()
    {
        if (knownHostiles.Count >= 1)
            readyWeapon();
        else
            lowerWeapon();
    }

    void readyWeapon()
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
        while (shooting)
        {
            GameControllerScript.Instance.shootWeapon(weapon);
            yield return new WaitForSeconds(weapon.properties.firerate);
        }
    }
}
