using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBot : MonoBehaviour
{
    Rigidbody2D rg;
    Target target;
    public GameObject arrowPrefab;
    public List<GameObject> arrowsList;

    float botSpeed = 0;
    float smoothTime = 3f;
    float newPosition;
    float distanceToTarget;
    float distanceToBow;
    int degree;
    public int amountArrows;


    float timeToShoot;
    float timeToGo;
    float elapsedTime;
    bool readyToShoot;
    bool readyToGo;

    bool isTriggered = false;


    public void Death()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Target>();
        elapsedTime = timeToShoot;
        degree = 0;
        arrowsList.Clear();
    }

    void Shoot()
    {
        elapsedTime -= Time.deltaTime;
        if (elapsedTime < 0)
        {
            GameObject arrow= Instantiate(arrowPrefab, gameObject.transform.position,Quaternion.Euler(0,0,0));
            arrowsList.Add(arrow);
        }
    }

    void BeforeShoot()
    {
        distanceToBow = Vector2.Distance(new Vector2(0.05f, -14.95f), gameObject.transform.position);
        transform.position = transform.position + Vector3.left * Time.deltaTime;
        if (distanceToBow < 0) { degree++; }
    }

    void AfterShoot()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
        newPosition = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref botSpeed, smoothTime);
        transform.position = new Vector2(newPosition, transform.position.y);

        if ((distanceToTarget < 1) | (gameObject.activeSelf is false))
        {
            Death();
        }
    }

    void Update()
    {
        switch (degree)
        {
            case 0:
                BeforeShoot();
                break;

            case 1:
                Shoot();
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Death();
        }
    }
}
