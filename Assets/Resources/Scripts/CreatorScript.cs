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

    public void Start()
    {
        LoadAllAssets();
    }

    void LoadAllAssets()
    {
        pistolBullet = Resources.Load<GameObject>("Prefabs/pistolBullet");
    }

    public GameObject getPistolBullet()
    {
        if (!pistolBullet)
            LoadAllAssets();

        return pistolBullet;
    }
}