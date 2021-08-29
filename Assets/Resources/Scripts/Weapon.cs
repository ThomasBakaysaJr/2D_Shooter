using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    public WeaponProperties properties;
    public Attachments attachments;

    bool readyShot;

    public GameObject modelGun;
    public GameObject exitBullet;

    public Weapon()
    {
        properties = new WeaponProperties();
        attachments = new Attachments();
        readyShot = true;
        //put the stuff for the model and exitBullet position;
        //exitBullet = new GameObject();
    }


    private void Start()
    {
        readyShot = false;
    }

    //Set's up this specific weapons. clonedWeapon should be an ALREADY CLONED prefab.
    //this will take care of assinging the variables and then adjusting the attachemnts
    public void setUpWeapon(GameObject clonedWeapon, WeaponProperties newProperties, Attachments newAttachments)
    {
        //I think this just passes pointers, so If I start getting problems with values, might have to amke
        //copy functions and do that instead off passing pointers.
        modelGun = clonedWeapon;
        attachments = newAttachments;
        properties = newProperties;
        //get the prefab data already on this object (all prefab weapons should come with it)
        WeaponPrefabData cloneData = clonedWeapon.GetComponent<WeaponPrefabData>();
        if (!cloneData)
            Debug.LogError("A WEAPON SCRIPT HAS RECEIVED A CLONEDWEAPON WITH NO PREFAB DATA");
        
        exitBullet = cloneData.getBulletExit();
        cloneData.enableAttachment(attachments);

        readyShot = true;
    }

    //sends to game controller, that this weapon is firing. Should receive back
    //a bullet to move to the end of the barrel. This method should have nothing
    //else to do with the bullet.
    public bool canShootWillShoot()
    {
        if (readyShot)
        {
            readyShot = false;
            return true;
        }
        else
            return false;
    }
}

[Serializable]
public class Attachments
{
    public bool laser;
    public bool flashlight;
    public bool extendedMag;
    public int sight;

    public Attachments()
    {
        laser = false;
        flashlight = false;
        extendedMag = false;
        sight = 0;
    }
} 

