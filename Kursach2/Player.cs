using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    #region Initialization
    public Rigidbody2D rg;
    public SpriteRenderer spriteRenderer;
    public GameObject panel;
    public Text scoreText;
    private SpriteRenderer sr;
    public List<Sprite> sprites;
    public List<Sprite> spritesAttack;
    public Text debug;
    //public Banner add;

    public int PlayerVelocityY;
    public int PlayerVelocityX;

    public float jumpThrust;
    public float secondJumpThrust;

    public bool onGround;
    private bool secondJump;

    public bool isAttack = false;
    private float elapsedTimeAttack;
    private float attackAnimationTime = 0.5f;

    private float accTime = 15;
    public int gameSpeed = 1;

    public int score = 0;

    private int spriteNumber = 0;
    private int speedAn = 5;
    private bool attAnim = false;
    #endregion


    #region Input

    void PCInput()
    {
        if (((Input.GetAxis("Vertical")> 0))&(onGround is true))
        {
            SimpleJump();
        }
        if ((Input.GetAxis("Vertical")<0)&(onGround is false)&(secondJump is false))
        {
            DoubleJump();
        }
        if ((Input.GetAxis("Fire2") > 0))
        {
            SimpleAttack();
        }
    }

    public void MobileInput(string button)
    {
        if ((button == "Jump") & (onGround is true)) { SimpleJump(); }
        if ((button == "Attack")) { SimpleAttack(); }
        if ((button == "Jump") & (onGround is false) & (secondJump is false)) { DoubleJump(); }

    }
    
    public void MobileInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            debug.text = touch.position.x.ToString();
            if (touch.position.x > -1080)
            {
                SimpleAttack();
            }
            else
            {
                if (onGround) { SimpleJump(); }
                if ((!onGround) & (!secondJump)) { DoubleJump(); }
            }
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(1);
                if (touch.position.x > -1080)
                {
                    SimpleAttack();
                }
                else
                {
                    if (onGround) { SimpleJump(); }
                    if ((!onGround) & (!secondJump)) { DoubleJump(); }
                }
            }
        }
    }
    #endregion


    #region Actions
    void SimpleJump()
    {
        rg.AddForce(transform.up * jumpThrust);
    }

    void DoubleJump()
    {
        rg.AddForce(-transform.up * secondJumpThrust);
        secondJump = true;
    }

    void SimpleAttack()
    {
        if (isAttack is false)
        {
            //spriteRenderer.color = Color.green;
            elapsedTimeAttack = attackAnimationTime;
            isAttack = true;
            attAnim = true;
        }

    }

    void AttackAnimationTimer()
    {
        elapsedTimeAttack = elapsedTimeAttack - Time.deltaTime;
        if (elapsedTimeAttack < 0)
        {
            //spriteRenderer.color = Color.white;
            isAttack = false;
            attAnim = true;
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    //public void Animation()
    //{
    //    timeForChangeSprite = timeForChangeSprite - Time.deltaTime;
    //    if (timeForChangeSprite <= 0)
    //    {
    //        if (isAttack)
    //        {

    //        }
    //        else
    //        {
    //            timeForChangeSprite = 0.5f;
    //            sr.sprite = sprites[spriteNumber];
    //            spriteNumber++;
    //            if (spriteNumber == maxSpriteNumber)
    //            {
    //                spriteNumber = 0;
    //            }
    //        }

    //    }
    //}

    public void FixedAnimation(List<Sprite> sprites, int i)
    {
        if (attAnim) { spriteNumber = 0;    attAnim = false; }
        if ((speedAn== 0)|(i==24))
        {
            sr.sprite = sprites[spriteNumber];
            spriteNumber++;
            if (spriteNumber == i)
            {
                spriteNumber = 0;
            }
            speedAn = 5 - gameSpeed;
        }
        else
        {
            speedAn--;
        }


    }
    #endregion


    #region Game
    public void Acceleration()
    {
        accTime = accTime - Time.deltaTime;
        if (accTime < 0)
        {
            accTime = 15;
            if (gameSpeed <= 5) { gameSpeed++; }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion


    #region Unity
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();
        //add.ShowAd();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
            secondJump = false;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Ground")&(rg.transform.position.y>=-15.34))
        {
            onGround = false;
        }
    }

    void Update()
    {
        if (isAttack is true)
        {
            AttackAnimationTimer();
        }
        Acceleration();
        scoreText.text = "Score:" + score;
    }

    private void FixedUpdate()
    {
        PCInput();
        if (isAttack) { FixedAnimation(spritesAttack,24); } else { FixedAnimation(sprites,21); }
    }

    #endregion
}

