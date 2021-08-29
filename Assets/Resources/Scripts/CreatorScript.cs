using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible with the creation of things, will be in charge of holding the originals 
 * and passing them on to scripts that require them (pooling script will use a lot)
 * */
public class CreatorScript : MonoBehaviour
{
    GameObject pistolBullet;
    GameObject pistol_01;

    public void Start()
    {
        LoadAllAssets();
    }

    void LoadAllAssets()
    {
        pistolBullet = Resources.Load<GameObject>("Prefabs/pistolBullet");
        pistol_01 = Resources.Load<GameObject>("Prefabs/pistol_01");
    }

    public GameObject getPistolBullet()
    {
        if (!pistolBullet)
            LoadAllAssets();

        return Instantiate(pistolBullet);
    }

    public GameObject getPistol()
    {
        if (!pistol_01)
            LoadAllAssets();

        return Instantiate(pistol_01);
    }

    public GameObject getWeapon(int weaponCode)
    {
        return Instantiate(selectWeapon(weaponCode));
    }

    GameObject selectWeapon(int weaponCode)
    {
        if (weaponCode == GameControllerScript.Instance.legend.PISTOLINT_01)
            return pistol_01;
        //this is so that all paths return something. Maybe the default returns a dinky pistol lol
        return pistol_01;
    }

}