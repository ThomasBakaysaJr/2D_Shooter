using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefabData : MonoBehaviour
{
    public GameObject barrelEndObj;
    public GameObject laserSightObj;
    public GameObject flashLightObj;
    public GameObject ExtendedMagObj;

    //Activate the attachments for this specific weapon.
    public void enableAttachment(Attachments attached)
    {
        if (!laserSightObj || !flashLightObj || !ExtendedMagObj)
            Debug.LogError(name + " IS MISSING ATTACHMENT OBJECTS.");
        //stuff for the sights here
        //bla bla bla
        laserSightObj.SetActive(attached.laser);
        flashLightObj.SetActive(attached.flashlight);
        ExtendedMagObj.SetActive(attached.extendedMag);
    }

    public GameObject getBulletExit()
    {
        return barrelEndObj;
    }
}
