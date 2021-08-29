using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float activeTime;

    Rigidbody2D thisRigidbody;


    void Awake()
    {
        if (speed == 0)
        {
            speed = 1000;
        }
        if(activeTime == 0)
        {
            activeTime = 3;
        }

        thisRigidbody = gameObject.GetComponent<Rigidbody2D>();
           
    }

    void OnEnable()
    {
        StartCoroutine("bulletEnabled");
    }

    IEnumerator bulletEnabled()
    {
        thisRigidbody.AddForce(transform.right * speed);
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }

}
