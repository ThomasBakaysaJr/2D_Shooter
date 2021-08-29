using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Anything and everything to do with pooling goes here. Mostly for bullets
public class PoolingScript : MonoBehaviour
{
    public CreatorScript creator;

    public List<WeaponProperties> currentWeapons;
    public List<BulletList> bulletsList;


    Legend legend;
    int index;
    int count;

    private void Start()
    {
        index = 0;
        count = 0;

    }

    public void setCreator(CreatorScript newCreator)
    {
        creator = newCreator;
        legend = GameControllerScript.Instance.legend;
        //initialize the list of bullets, and the list of list of bullets so it has someplace to go
        bulletsList = new List<BulletList>();
        for (int i = legend.NumberOfWeapons; i > 0; i--)
        {
            bulletsList.Add(new BulletList());
        }
    }

    //manually called to start pooling the repetative objects required for the level
    public void startPooling()
    {
        currentWeapons = GameControllerScript.Instance.propertiesWeaponsMission;
        index = 0;
        count = currentWeapons.Count;

        //create a pool of bullets for the weapons
        while(index < count)
        {
            WeaponProperties curProp = currentWeapons[index];
            createBullet(curProp.caliber, 5);
            index++;
        }
    }

    public GameObject getPistolBullet(int caliber)
    {
        int count;
        GameObject returnObj = null;

        while(returnObj == null)
        {
            count = bulletsList[caliber].Count();
            for (int i = 0; i < count; i++)
            {
                if (!(returnObj = bulletsList[caliber].GetBullet(i)).activeSelf)
                    return returnObj;
            }
            returnObj = null;
            //if all pistolBullets are active, ask for more from creatorScript
            createBullet(caliber, 5);
        }

        Debug.LogError("GET PISTOL BULLET HAS RETURNED NULL");
        return returnObj;
    }


    void createBullet(int caliber, int howMany)
    {
        GameObject curToSpawn = null;
        
        if(caliber == legend.PISTOLINT_01)
        {
            curToSpawn = creator.getPistolBullet();
        }
        else
        {
            Debug.LogError("CALIBER NOT FOUND + " + caliber);
        }
        createMultipleBullet(curToSpawn, caliber, howMany);
    }

    void createMultipleBullet(GameObject toSpawn, int listCode, int howMany)
    {
        toSpawn.SetActive(false);
        //howMany - 1 because we are adding the bullet that we were giving, since it's also a clone
        //of the original
        for(int i = 0; i < (howMany - 1); i++)
        {
            GameObject newObj;
            newObj = Instantiate(toSpawn);
            bulletsList[listCode].Add(newObj);
        }
        bulletsList[listCode].Add(toSpawn);
    }
}