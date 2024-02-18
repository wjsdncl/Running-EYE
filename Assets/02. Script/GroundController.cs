using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

    public float groundSpeed;

    void Start()
    {
        groundSpeed = GameManager.GroundSpeed;
    }

    void Update()
    {
        groundSpeed = GameManager.GroundSpeed;
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);
        if (transform.position.x <= -150)
        {
            Destroy(this.gameObject);
        }
    }
}