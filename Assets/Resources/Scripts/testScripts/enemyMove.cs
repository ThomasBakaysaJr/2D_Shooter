using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rbody;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        StartCoroutine(moveUpAndDown());
    }

    IEnumerator moveUpAndDown()
    {
        rbody.AddForce(Vector3.up * speed);
        while (true)
        {            
            while (transform.position.y < 4)
            {
                yield return new WaitForSeconds(0.1f);
            }
            rbody.AddForce(Vector3.down * (speed*2));
            while (transform.position.y > -4)
            {
                yield return new WaitForSeconds(0.1f);
            }
            rbody.AddForce(Vector3.up * (speed*2));
        }
    }

}
