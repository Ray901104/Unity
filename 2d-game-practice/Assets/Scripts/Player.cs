using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // MonoBehaviour를 상속 받았을 경우
    // gameObject, transform 변수 가지고 있다.
    public float speed;
    public float jumpPower;
    public bool isJump = false;
    public Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input.GetKey (키가 눌려있는 동안)
        // Input.GetKeyDown (키가 한 번 눌렸을 때)
        // Input.GetKeyUp (키가 떼어졌을 때)
        // Input.MouseButton (마우스를 누르고 있는 동안)
        // Input.MouseButtonDown (마우스를 한 번 눌렀을 경우)
        // Input.MouseButtonUp (마우스를 눌렀다가 떼었을 때)
        if(Input.GetKey(KeyCode.RightArrow))
        {
            // transform.position += new Vector3(speed, 0.0f, 0.0f);
            
            // Translate(x,y,z) -> Object를 x,y,z만큼 이동시킨다.
            // Time.deltaTime -> 1초를 프레임으로 나눈 값 -> 모든 컴퓨터 프레임에서 동일한 설정값으로 동작하게끔 (1초에 60번)
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.position += new Vector3(-speed, 0.0f, 0.0f);
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            rigidBody.velocity = new Vector2(0.0f, rigidBody.velocity.y);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            isJump = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
        }

        if (rigidBody.velocity.y == 0.0f)
        {
            isJump = false;
        }
    }
}
