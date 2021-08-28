using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponProperties properties;

    bool readyShot;
    GameObject modelGun;
    GameObject exitBullet;

    public Weapon()
    {
        properties = new WeaponProperties();
        readyShot = true;
        //put the stuff for the model and exitBullet position;
        exitBullet = new GameObject();
    }

    private void Start()
    {
        readyShot = true;
        StartCoroutine("checkShootStatus");        
    }

    //sends to game controller, that this weapon is firing. Should receive back
    //a bullet to move to the end of the barrel. This method should have nothing
    //else to do with the bullet.
    public bool canShoot()
    {
        if (readyShot)
        {
            readyShot = false;
            return true;
        }
        else
            return false;
    }


    //script for the cooldown of the gun. 
    IEnumerator checkShootStatus ()
    {
        Debug.Log("starting fire status checker");
        while (this.gameObject.activeSelf)
        {
            //wait until the thing is firing
            while (!readyShot) yield return null;
            //firing, start cooldown
            yield return new WaitForSeconds(properties.firerate);
            readyShot = true;
        }
    }
}

