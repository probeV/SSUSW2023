using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigid;
    Animator anim;

    Vector2 moveVec;

    Vector2 previousPlayerPosition;

    float h;
    float v;
    bool isMove = true;

    int specialAnimationCount = 0;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Player Move Input
        //MoveInput();
        MoveInput_Test();

        //Player Animation
        PlayerAnimation();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerAnimation()
    {
        //Move Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //Spcial idle Animation 
        if (specialAnimationCount <= 1800 && (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Down_idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Down_idle_Special")))
        {
            specialAnimationCount++;
            if (specialAnimationCount == 1200)
            {
                anim.SetBool("isSpecialDownidle", true);
            }
        }
        else
        {
            specialAnimationCount = 0;
            anim.SetBool("isSpecialDownidle", false);
        }
    }

    void MoveInput_Test()
    {
        //Input
        if (isMove)
        {
            rigid.position = new Vector2(Mathf.Round(rigid.position.x), Mathf.Round(rigid.position.y));
            previousPlayerPosition = rigid.position;

            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            if (h != 0 || v != 0)
            {
                isMove = false;
            }

            if (h > 0)
                moveVec = new Vector2(1, 0);
            else if (h < 0)
                moveVec = new Vector2(-1, 0);

            if (v > 0)
                moveVec = new Vector2(0, 1);
            else if (v < 0)
                moveVec = new Vector2(0, -1);
        }
    }

    void MoveInput()
    {
        if (Input.touchCount == 1 && isMove)
        {
            rigid.position = new Vector2(Mathf.Round(rigid.position.x), Mathf.Round(rigid.position.y));
            previousPlayerPosition = rigid.position;

            //First Touch
            Touch touch = Input.GetTouch(0);

            //Moved Touch Position
            Vector2 previousTouchPosition = Vector2.zero, currentTouchPosition;

            //Began Touch
            if (touch.phase == TouchPhase.Began)
            {
                previousTouchPosition = touch.position;
            }
            //Moved Touch
            else if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPosition = touch.position;

                //Checking Touch Change
                Vector2 checkMove = currentTouchPosition - previousTouchPosition;

                //Move x
                if (Mathf.Abs(checkMove.x) > Mathf.Abs(checkMove.y))
                {
                    //Move Right
                    if (checkMove.x > 0)
                    {
                        h = 1;
                        moveVec = new Vector2(1, 0);
                    }
                    //Move Left
                    else
                    {
                        h = -1;
                        moveVec = new Vector2(-1, 0);
                    }

                }
                //Moved Y
                else
                {
                    //Move Up
                    if (checkMove.y > 0)
                    {
                        v = 1;
                        moveVec = new Vector2(0, 1);
                    }
                    //Move Down
                    else
                    {
                        v = -1;
                        moveVec = new Vector2(0, -1);
                    }
                }
            }
        }
    }

    void PlayerMove()
    {
        rigid.velocity = moveVec * speed;
        if ((previousPlayerPosition - rigid.position).magnitude >= 0.97f)
        {
            isMove = true;
            moveVec = Vector2.zero;
        }
    }
}
