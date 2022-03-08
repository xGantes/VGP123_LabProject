using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int startingLives;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instances.lives = startingLives;
        GameManager.instances.spawnPlayer(spawnPoint);
        GameManager.instances.currentLevel = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
