using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealthProperties
{
    public float max;
    public float current;
}

[Serializable]
public class WeaponProperties
{
    public string name;
    public int caliber;
    public int damage;
    public float firerate;
    public float chanceHit;

    public WeaponProperties ()
    {
        name = "pistol";
        caliber = 0;
        damage = 100;
        firerate = 0.2f;
        chanceHit = 100;
    }
}

[Serializable]
public class Legend
{
    public int PISTOLINT;
    public string PISTOLSTRING;
    public int NumberOfWeapons;

    public Legend()
    {
        PISTOLINT = 0;
        PISTOLSTRING = "pistol";
        NumberOfWeapons = 1;
    }
}

[Serializable]
public class BulletList
{
    public List<GameObject> bullets;

    public BulletList ()
    {
        Debug.Log("called");
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
    public HealthProperties healthProperties;
    public WeaponProperties weaponProperties;
}
