using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instances = null;

    [HideInInspector] public GameObject playerInstances;
    [HideInInspector] public Level currentLevel;

    public static GameManager instances
    {
        get 
        {
            return _instances; 
        }
        set 
        {
            _instances = value; 
        }
    }

    int _score = 0;
    int _lives = 1;
    public int maxlives = 3;
    public GameObject playerPrefabs;

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Score set to:" + score.ToString());
        }
    }
    public int lives
    {
        get { return _lives; }
        set
        {
            if(_lives > value)
            {
                Destroy(playerInstances);
                spawnPlayer(currentLevel.spawnPoint);
            }

            _lives = value;
            if (_lives > maxlives)
            {
                _lives = maxlives;
            }
            Debug.Log("Lives set to:" + lives.ToString());
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if(instances)
        {
            Destroy(gameObject);
        }
        else
        {
            instances = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(SceneManager.GetActiveScene().name == "TestScene")
            
                SceneManager.LoadScene("SampleScene");
            
            else
            
                SceneManager.LoadScene("TestScene");
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

    }

    public void spawnPlayer(Transform spawnLocation)
    {
        playerInstances = Instantiate(playerPrefabs, spawnLocation.position, spawnLocation.rotation);
    }


}
