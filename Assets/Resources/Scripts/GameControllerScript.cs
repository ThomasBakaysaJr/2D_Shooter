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
        finishedStartup = false;
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
    public List<PlayerUnit> currentUnits;
    private List<Weapon> weaponsMission;
    private List<Weapon> weaponsAll;
    private CreatorScript creator;
    private PoolingScript pooler;
    public bool finishedStartup;

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
        setupLevel();
        pooler.startPooling();
        finishedStartup = true;
    }

    void setupLevel()
    {
        int index = 0;
        for(int count = currentUnits.Count; index < count; index++)
        {
            propertiesWeaponsMission.Add(currentUnits[index].weaponPropeties);
        }
        index = 0;
    }


    //called by weapon scripts to get a bullet
    //THIS IS A METHOD THAT CAN FAIL CAUSE OF A BULLET BEING TAKEN BY TWO WEAPONS
    public void shootWeapon(Weapon weapon)
    {
        GameObject bullet = null;
        bullet = pooler.getPistolBullet(weapon.properties.caliber);
        //BETTER have my bullet
        Assert.IsNotNull(bullet);
        bullet.transform.position = weapon.exitBullet.transform.position;
        bullet.SetActive(true);

    }

    public GameObject getWeapon(int weaponCode)
    {
        return creator.getWeapon(weaponCode);
    }


}


