using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBot : MonoBehaviour
{
    Target target;
    Player player;

    float botSpeed = 0;
    float smoothTime = 3f;
    float newPosition;
    float distance;
    public float newsmoothTime;

    bool isTriggered = false;


    public void Death()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        player.score = player.score + 100 * player.gameSpeed;
    }

    void Awake()
    {
        target = FindObjectOfType<Target>();
        player = FindObjectOfType<Player>();
    }

    void Acceleration()
    { 
        newsmoothTime = smoothTime - player.gameSpeed * 0.2f;
        if (newsmoothTime < 0.5)
        {
            newsmoothTime = 0.5f;
        }
    }

    void Update()
    {
        Acceleration();
        distance = Vector2.Distance(transform.position, target.transform.position);
        newPosition = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref botSpeed, newsmoothTime);
        transform.position = new Vector2(newPosition, transform.position.y);

        //transform.position = Vector2.

        if ((distance < 1)|(gameObject.activeSelf is false))
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (player.isAttack) { Death(); } else { player.Death(); }
        }
    }
}
