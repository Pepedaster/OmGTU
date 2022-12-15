using UnityEngine;
using System.Collections.Generic;

public class Ground : MonoBehaviour
{
    public Player player;
    public List<GameObject> grounds;
    public GameObject bg;
    public float test;
    public float baseSpeed;

    private float bgSpeed = 0.05f;

    void Move(GameObject ground)
    {
        if (ground.transform.position.x < -54)
        {
            
            ground.transform.position = new Vector3(11f, ground.transform.position.y,-25);
        }
        else
        {
            ground.transform.position = new Vector3(ground.transform.position.x - baseSpeed * player.gameSpeed * Time.deltaTime, ground.transform.position.y,-25);
        }
        bg.transform.position = new Vector3(bg.transform.position.x - bgSpeed * Time.deltaTime, bg.transform.position.y,10);
        //Debug.Log("?");
    }
    private void Update()
    {
        Move(grounds[0]);
        Move(grounds[1]);
    }

}