using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall: MonoBehaviour
{
    public int itemCount;
    public float JumpPower = 30;
    public float maxMoveForce = 5;
    public float acceleration = 1;
    bool isJump;
    public GameManager manager;
    Rigidbody rigid;
    AudioSource audio1;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpPower, 0), ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveForce = new Vector3(h, 0, v) * acceleration;
        moveForce = Vector3.ClampMagnitude(moveForce, maxMoveForce);

        rigid.AddForce(moveForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio1.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }

        if (other.tag == "Respawn")
        {
            transform.position = new Vector3(-1,0,0);
        }

        if (other.tag == "Finish")
        {
            if(itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene(manager.stage + 1);
            } else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
