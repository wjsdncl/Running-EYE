using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public float jump_power = 0.003f;

    public bool isJump;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isJump = true;
    }

    void Jump()
    {
        if(isJump == true)
        {
            rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
            isJump = false;
        }
        else
        {
            return;
        }
            
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.CompareTo("Player") == 0)
        {
            isJump = true;
        }
    }

    void GameOver()
    {
        Vector3 dieVelocity = new Vector3(0, 0.006f, 0);
        rb.AddForce(dieVelocity, ForceMode.Impulse);

        BoxCollider coll = gameObject.GetComponent<BoxCollider>();
        coll.enabled = false;
    }
}
