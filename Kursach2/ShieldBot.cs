using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBot : MonoBehaviour
{
    Target target;
    Player player;

    float botSpeed = 0;
    float smoothTime = 4f;
    float newPosition;
    float distance;
    public float newsmoothTime;


    public void Death()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        player.score = player.score + 150 * player.gameSpeed;
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
            newsmoothTime = 0.75f;
        }
    }
    
    void Update()
    {
        Acceleration();
        distance = Vector2.Distance(transform.position, target.transform.position);
        newPosition = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref botSpeed, smoothTime);
        transform.position = new Vector2(newPosition, transform.position.y);
        if ((distance < 1) | (gameObject.activeSelf is false))
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player"))
        {
            if (player.isAttack) { Death(); } else { player.Death(); }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.Death();
        }
    }
}
