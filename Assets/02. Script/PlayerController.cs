using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameManager GM;

    public float jump_power = 10.0f;

    bool isJumping;
    bool isGround;

    bool isDie = false;

    Rigidbody rb;

    public int player_hp = 1;

    void Start()
    {
        isJumping = false;
        isGround = true;

        rb = GetComponent<Rigidbody>();

        player_hp = 1;
    }

    void Update()
    {
        if(player_hp == 0)
        {
            if (!isDie)
                Die();
            return;
        }
    }

    void FixedUpdate()
    {
        if (player_hp == 0)
            return;

        Jump();
    }

    //점프
    void Jump()
    {
        if(isGround)
        {
            if (!isJumping)
                return;

            rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);

            isGround = false;
            isJumping = false;
        }
    }

    //버튼을 누르면 isJumping을 true로
    public void Jump_btn()
    {
        isJumping = true;
    }

    public void No_jump()
    {
        isJumping = false;
    }

    void OnCollisionEnter(Collision col)
    {
        //땅에 닿았는지
        if (col.gameObject.tag.CompareTo("Ground") == 0)
        {
            isGround = true;
        }

        //몸이 가시에 부딫히면 사망
        if (col.gameObject.tag.CompareTo("Thorn") == 0)
        {
            player_hp = 0;
        }
    }
    
    void OnTriggerEnter(Collider trg)
    {
        //몸이 벽에 부딫히면 사망
        if (trg.gameObject.tag.CompareTo("Ground") == 0)
        {
            player_hp = 0;
        }

        //몸이 가시에 부딫히면 사망
        if (trg.gameObject.tag.CompareTo("Thorn") == 0)
        {
            player_hp = 0;
        }
    }

    //플레이어 사망
    void Die()
    {
        isDie = true;

        rb.velocity = Vector3.zero;

        SphereCollider[] colls = gameObject.GetComponents<SphereCollider>();
        colls[0].enabled = false;
        colls[1].enabled = false;

        BoxCollider coll = gameObject.GetComponent<BoxCollider>();
        coll.enabled = false;

        Vector3 dieVelocity = new Vector3(0, 30f, 0);
        rb.AddForce(dieVelocity, ForceMode.Impulse);

        GameObject.FindWithTag("GameController").SendMessage("GameOver");
        GameObject.FindWithTag("ScoreManager").SendMessage("GameOver");
        GameObject.FindWithTag("SoundManager").SendMessage("GameOver");
    }
}
