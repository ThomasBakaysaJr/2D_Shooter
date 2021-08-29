using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitProperties
{

    public string name;
    public float health;

    public float sightRange;

    public UnitProperties()
    {
        health = 100;
        name = "Default";
        sightRange = 10;
    }

    //copy the variables from one property to the other
    public void copy(UnitProperties newProp)
    {
        newProp.health = health;
        newProp.name = name;
        newProp.sightRange = sightRange;
    }

}


[Serializable]
public class WeaponProperties
{
    public string name;
    public int weaponCode;
    public int caliber;
    public int damage;
    public float firerate;
    public float chanceHit;

    public WeaponProperties ()
    {
        name = "pistol";
        weaponCode = 0;
        caliber = 0;
        damage = 100;
        firerate = 1f;
        chanceHit = 100;
    }
}

[Serializable]
public class Legend
{
    public int PISTOLINT_01;
    public string PISTOLSTRING_01;
    public int NumberOfWeapons;

    public Legend()
    {
        PISTOLINT_01 = 0;
        PISTOLSTRING_01 = "pistol";
        NumberOfWeapons = 1;
    }
}

[Serializable]
public class BulletList
{
    public List<GameObject> bullets;

    public BulletList ()
    {
        bullets = new List<GameObject>();
    }

    public void Add(GameObject toAdd)
    {
        bullets.Add(toAdd);
    }

    public int Count ()
    {
        return bullets.Count;
    }

    public GameObject GetBullet(int index)
    {
        return bullets[index];
    }
}

public class Data : MonoBehaviour
{

}
