using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 100;

    void Start()
    {
        gameObject.SetActive(true);

        turnSpeed = 150;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider trg)
    {
        if (trg.gameObject.tag.CompareTo("Player") == 0)
        {
            ScoreManager.Instance.coin += 1;

            gameObject.SetActive(false);
        }
    }
}
