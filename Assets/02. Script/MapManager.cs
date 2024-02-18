using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] m_1;

    public float groundSpeed;

    void Start()
    {
        groundSpeed = GameManager.GroundSpeed;
    }
    
    void FixedUpdate() {
        groundSpeed = GameManager.GroundSpeed;
        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);

        if(transform.position.x < -49.7f)
        {
            transform.position = new Vector3(0, 0, 0);

            Vector3 position = new Vector3(140f, 0f, 0f);
            Instantiate(m_1[Random.Range(0, 3)], position, Quaternion.identity);
        }
    }
}
