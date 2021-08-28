using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameControllerScript : MonoBehaviour
{
    private static GameControllerScript _Instance;
    public static GameControllerScript Instance
    {
        get
        {
            //if there is no game controller script for some reason.
            if(!_Instance)
            {
                var prefab = Resources.Load<GameObject>("Prefabs/GameController");
                var inScene = Instantiate<GameObject>(prefab);
                _Instance = inScene.GetComponentInChildren<GameControllerScript>();
                //no controllerScript, make it
                if (!_Instance) _Instance = inScene.AddComponent<GameControllerScript>();
            }
            return _Instance;
        }
    }

    private void Awake()
    {
        _Instance = GetComponent<GameControllerScript>();
    }

    /*
     * PUBLIC VARIABLES
     * for such things as the list of weapons and equipment currently being used
     * yada yada. Probably will have something to do with the current mission, I'm not
     * sure yet.
     */
    public List<WeaponProperties> propertiesWeaponsMission;
    public Legend legend;


    /*
     * PRIVATE VARIABLES. DONT want anyone calling the poolers and creators directly except me.
     */
    private List<Weapon> weaponsMission;
    private List<Weapon> weaponsAll;
    private CreatorScript creator;
    private PoolingScript pooler;

    public void Start()
    {
        DontDestroyOnLoad(Instance.gameObject);
        //Check to make sure pooling and creator scripts are attached
        if (!creator)
        {
            creator = gameObject.AddComponent<CreatorScript>();
        }
        if(!pooler)
        {
            pooler = gameObject.AddComponent<PoolingScript>();
        }

        legend = new Legend();
        pooler.setCreator(creator);
        //TESTING CODE: add some weapons to not error out
        WeaponProperties newProp = new WeaponProperties();
        newProp.caliber = legend.PISTOLINT;
        newProp.name = "Test Pistol";
        newProp.firerate = 1;
        newProp.damage = 10;
        newProp.chanceHit = 100;

        propertiesWeaponsMission.Add(newProp);
        propertiesWeaponsMission.Add(newProp);


        pooler.startPooling();
    }


    //called by weapon scripts to get a bullet
    //THIS IS A METHOD THAT CAN FAIL CAUSE OF A BULLET BEING TAKEN BY TWO WEAPONS
    public void shootWeapon(Weapon weapon, Vector2 newPosition)
    {
        if (!weapon.canShoot())
            return;
        Debug.Log("shooting");
        GameObject bullet = null;
        bullet = pooler.getPistolBullet(weapon.properties.caliber);

        Assert.IsNotNull(bullet);
        bullet.transform.position = newPosition;
        bullet.SetActive(true);

        //look, changes to code!
    }


}


