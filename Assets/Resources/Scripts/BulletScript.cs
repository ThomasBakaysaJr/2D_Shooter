using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    int count = 0;

    private void OnEnable()
    {
        count = 0;
    }

    public void Update()
    {
        float posX = transform.position.x;
        gameObject.transform.position = new Vector3(posX + 0.2f, 0, 0);
        count += 1;
        if (count > 500)
        {
            count = 0;
            gameObject.SetActive(false);
        }
    }
}
