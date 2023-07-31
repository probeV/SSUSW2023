using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //Component
    Rigidbody2D rigid;
    Animator anim;

    //Player Move 
    Vector2 moveVec;

    Vector2 previousPlayerPosition;

    float hPlayerMoveDirection;
    float vPlayerMoveDirection;

    public float speed;

    //Player Raycast
    float rayDistance = 0.6f;

    [HideInInspector]
    public RaycastHit2D raycastDown, raycastUp, raycastLeft, raycastRight;

    //Player Animation
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
        if (anim.GetInteger("hAxisRaw") != hPlayerMoveDirection)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)hPlayerMoveDirection);
        }
        else if (anim.GetInteger("vAxisRaw") != vPlayerMoveDirection)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)vPlayerMoveDirection);
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
        //Input Limit
        if (rigid.velocity==Vector2.zero)
        {
            rigid.position = new Vector2(Mathf.Round(rigid.position.x), Mathf.Round(rigid.position.y));
            previousPlayerPosition = rigid.position;

            hPlayerMoveDirection = Input.GetAxisRaw("Horizontal");
            vPlayerMoveDirection = Input.GetAxisRaw("Vertical");

            //Input D   
            if (hPlayerMoveDirection > 0)
            {
                //Move
                moveVec = new Vector2(1, 0);
            }
            //Input A
            else if (hPlayerMoveDirection < 0)
            {
                //Move
                moveVec = new Vector2(-1, 0);
            }
            //Input W
            else if (vPlayerMoveDirection > 0) 
            {
                //Move
                moveVec = new Vector2(0, 1);
            }
            //Intput S
            else if (vPlayerMoveDirection < 0)
            {
                //Move
                moveVec = new Vector2(0, -1);
            }
        }
    }

    void MoveInput()
    {
        if (Input.touchCount == 1 && rigid.velocity == Vector2.zero)
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
                        hPlayerMoveDirection = 1;
                        moveVec = new Vector2(1, 0);
                    }
                    //Move Left
                    else
                    {
                        hPlayerMoveDirection = -1;
                        moveVec = new Vector2(-1, 0);
                    }

                }
                //Moved Y
                else
                {
                    //Move Up
                    if (checkMove.y > 0)
                    {
                        vPlayerMoveDirection = 1;
                        moveVec = new Vector2(0, 1);
                    }
                    //Move Down
                    else
                    {
                        vPlayerMoveDirection = -1;
                        moveVec = new Vector2(0, -1);
                    }
                }
            }
        }
    }

    void PlayerMove()
    {
        rigid.velocity = moveVec * speed;

        AudioManager.instance.isMoving = (rigid.velocity == Vector2.zero);

        if ((previousPlayerPosition - rigid.position).magnitude >= 0.97f)
        {
            moveVec = Vector2.zero;

            PlayerRaycast();
        }
    }

    void PlayerRaycast()
    {
        Vector2 raycastDownPosition     = new Vector2(rigid.position.x, rigid.position.y - 0.5f - rayDistance);
        Vector2 raycastUpPosition       = new Vector2(rigid.position.x, rigid.position.y - 0.5f + rayDistance );
        Vector2 raycastLeftPosition     = new Vector2(rigid.position.x - rayDistance, rigid.position.y - 0.5f);
        Vector2 raycastRightPosition    = new Vector2(rigid.position.x + rayDistance, rigid.position.y - 0.5f);

        raycastDown     = Physics2D.Raycast(raycastDownPosition, Vector2.down, rayDistance);
        raycastUp       = Physics2D.Raycast(raycastUpPosition, Vector2.up, rayDistance);
        raycastLeft     = Physics2D.Raycast(raycastLeftPosition, Vector2.left, rayDistance);
        raycastRight    = Physics2D.Raycast(raycastRightPosition, Vector2.right, rayDistance);

        Debug.DrawRay(raycastDownPosition, new Vector2(0, -rayDistance), new Color(0, 1, 0));
        Debug.DrawRay(raycastUpPosition, new Vector2(0, rayDistance), new Color(0, 1, 0));
        Debug.DrawRay(raycastLeftPosition, new Vector2(-rayDistance, 0), new Color(0, 1, 0));
        Debug.DrawRay(raycastRightPosition, new Vector2(rayDistance, 0), new Color(0, 1, 0));

        Debug.Log("Down " + raycastDown.collider);
        Debug.Log("Up " + raycastUp.collider);
        Debug.Log("Right " + raycastRight.collider);
        Debug.Log("Left " + raycastLeft.collider);

        AudioManager.instance.channelIndex= 0;

        //Up Raycast
        if (raycastUp.collider == null)
            AudioManager.instance.TakeNavi(AudioManager.Navi.Up, AudioManager.Navi.PathGuide);
        else if (!raycastUp.collider.CompareTag("BorderLine"))
            AudioManager.instance.TakeNaviObject(AudioManager.Navi.Up, raycastUp.collider.GetComponent<AudioSource>());

        //Down Raycast
        if (raycastDown.collider == null)
            AudioManager.instance.TakeNavi(AudioManager.Navi.Down, AudioManager.Navi.PathGuide);
        else if (!raycastDown.collider.CompareTag("BorderLine"))
            AudioManager.instance.TakeNaviObject(AudioManager.Navi.Down, raycastDown.collider.GetComponent<AudioSource>());

        //Left Raycast
        if (raycastLeft.collider == null)
            AudioManager.instance.TakeNavi(AudioManager.Navi.Left, AudioManager.Navi.PathGuide);
        else if (!raycastLeft.collider.CompareTag("BorderLine"))
            AudioManager.instance.TakeNaviObject(AudioManager.Navi.Left, raycastLeft.collider.GetComponent<AudioSource>());

        //Right Raycast
        if (raycastRight.collider == null)
            AudioManager.instance.TakeNavi(AudioManager.Navi.Right, AudioManager.Navi.PathGuide);
        else if (!raycastRight.collider.CompareTag("BorderLine"))
            AudioManager.instance.TakeNaviObject(AudioManager.Navi.Right, raycastRight.collider.GetComponent<AudioSource>());

        AudioManager.instance.PlayNavi();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player Collision Borderline 
        if (collision.gameObject.CompareTag("BorderLine"))
        {
            //Reset Player Position
            moveVec = Vector2.zero;
            rigid.position = new Vector2(Mathf.Round(rigid.position.x), Mathf.Round(rigid.position.y));

            AudioManager.instance.channelIndex = 0;

            AudioManager.Navi direction=0;

            if (vPlayerMoveDirection > 0)
                direction = AudioManager.Navi.Up;
            else if (vPlayerMoveDirection < 0)
                direction = AudioManager.Navi.Down;
            else if (hPlayerMoveDirection < 0)
                direction = AudioManager.Navi.Left;
            else if (hPlayerMoveDirection > 0)
                direction = AudioManager.Navi.Right;

            AudioManager.instance.TakeNavi(direction, AudioManager.Navi.WallBlock);

            AudioManager.instance.PlayNavi();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            rigid.position = collision.transform.Find("TP").position;
        }
        else if(collision.CompareTag("ObjectInteraction"))
        {

        }
    }

    void PlayerInteraction()
    {
        moveVec = Vector2.zero;
    }

}
