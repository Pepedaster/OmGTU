using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBotSpawner : MonoBehaviour
{
    public GameObject botSpawner;
    public GameObject botPrefab;
    public List<GameObject> botsList;
    Player player;
    public float baseTime;
    private float fTime;



    public void SpawnBot()
    {
        GameObject bot = (GameObject)Instantiate(botPrefab, botSpawner.transform.position, Quaternion.Euler(0,0,0));
        botsList.Add(bot);
    }

    void RandomSpawner()
    {
        fTime=Random.Range(baseTime - player.gameSpeed, baseTime);
    }

    void Counter()
    {
        fTime = fTime - Time.deltaTime;
        if (fTime < 0)
        {
            SpawnBot();
            RandomSpawner();
        }
    }

    private void Awake()
    {
        
        botsList.Clear();
        player = FindObjectOfType<Player>();
        RandomSpawner();
    }

    void Start()
    {

    }

    void Update()
    {
        Counter();
    }
}
