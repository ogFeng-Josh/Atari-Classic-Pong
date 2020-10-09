/*
Unity Skeleton Script
Written by Josh Y. (ogfeng)
Contact - ogfeng.streamers.site
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Additional Libraries:
//================================
//using System; //Allows us to use Array.ETC
//using UnityEngine.Audio; //Libraries Assets for Unity Audio System
//using UnityEngine.UI; //Libraries Assets for Unity UI
//using UnityEngine.SceneManagement; //Libraries Assets for Unity Scene Transition/Management
//using UnityEngine.Video; //Libraries Assets for Unity Video Component

//Documentations:
//================================
//[HelpUrl("URL")] Allows user to set a link to a documentation for reference

public class ballmanager : MonoBehaviour
{
    //================================
    #region Variables:
    //[Header("Variables:")]
    //int i1;
    //string s1;
    //float f1;
    //bool b1;
    //Ball in play
    public int ballActive = 0;

    //Player Last Touched
    bool player1 = false;
    bool player2 = false;
    public GameObject shield;
    public Transform[] shieldLocation;

    public GameObject[] distractions;
    public Transform[] particleSpawner;

    public float ballspeed = 7.0f;
    public Vector2 startingPosition = new Vector2 (7.0f, 0.0f);

    //Ball direction after spawning
    public bool redscored = false;
    public bool greenscored = false;

    public GameObject p1;
    public GameObject p2;

    public Vector2 p1Spawn = new Vector2(-7.0f, 0.0f);
    public Vector2 p2Spawn = new Vector2(7.0f, 0.0f);

    //Respawn Process
    public bool outofplay = false;
    
    //Ball Prefab
    public GameObject ballPrefab;
    public GameObject decoyPrefab;

    //Ball Data
    //public ballsystem balldata;
    
    //[Space]
    #endregion

    //================================

    #region Unity Methods:

    // Start is called before the first frame update
    private void Awake()
    {
        //balldata = GameObject.FindObjectOfType<ballsystem>();
    }
    
    private void Start()
    {
        //DeclaredVariable = GameObject.Find("gameObjectName").GetComponent<ComponentName>();
        //ballPrefab = GameObject.Find("ball");
        //Give countdown to RNG spawn
        rngSpawn();

    }

    // Update is called once per frame
    private void Update()
    {
        if(outofplay == true && ballActive <= 0)
        {
            resetround();
            //Destroy(ballPrefab);
        }
    }

    private void FixedUpdate()
    {

    }
    //[Space]
    #endregion

    //================================

    #region Methods:
    /*
    private void methodName()
    {
        //Do Something()
    }
    */
    public void rngSpawn()
    {
        //Returns to center for proper spawn location (ADD INSTANTIATE PREFAB TO MAKE PROPER SPAWN )
        //Instantiate(ballPrefab, transform.position, Quaternion.identity);
        //ballPrefab.transform.position = new Vector3(0f, 0f, 0f);
        GameObject ballTemp = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        
        int spawnpick = Random.Range (0, 2);
        ++ballActive;
        if(spawnpick == 0)
        {
            ballTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed, 0f);
        }
        else if(spawnpick == 1)
        {
            ballTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed, 0f);
        }

    }

    public void resetround()
    {
        outofplay = false;
        ++ballActive;
        //ballTemp2.transform.position = new Vector3(0f, 0f, 0f);
        p1.transform.position = p1Spawn;
        p2.transform.position = p2Spawn;
        GameObject ballTemp2 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ballTemp2.transform.position = new Vector3(0f, 0f, 0f);
        //transform.localPosition = (Vector3)startingPosition;

        //StartCoroutine(spawnTimer());

        if(greenscored == true)
        {
            greenscored = false;
            //StartCoroutine(spawnTimer());
            ballTemp2.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed, 0f);
        }
        else if(redscored == true)
        {
            redscored = false;
            //StartCoroutine(spawnRed());
            ballTemp2.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed, 0f);
        }

    }

    public void greenPoint()
    {
        greenscored = true;
        outofplay = true;
    }

    public void redPoint()
    {
        redscored = true;
        outofplay = true;
    } 

    public void boost()
    {
        StartCoroutine(boostTimer());
        
    }

    public void upCount()
    {
        ++ballActive;
    }
    public void deductCount()
    {
        --ballActive;
    }

    public void distraction()
    {
        StartCoroutine(distractionTimer());
        GameObject part1 = Instantiate(distractions[0], particleSpawner[0].transform.position, Quaternion.identity);
        GameObject part2 = Instantiate(distractions[0], particleSpawner[1].transform.position, Quaternion.identity);
        GameObject part3 = Instantiate(distractions[0], particleSpawner[2].transform.position, Quaternion.identity);
        Destroy(part1, 10.0f);
        Destroy(part2, 10.0f);
        Destroy(part3, 10.0f);
    }

    public void distraction2()
    {
        GameObject part1 = Instantiate(distractions[1], particleSpawner[0].transform.position, Quaternion.identity);
        GameObject part2 = Instantiate(distractions[1], particleSpawner[1].transform.position, Quaternion.identity);
        GameObject part3 = Instantiate(distractions[1], particleSpawner[2].transform.position, Quaternion.identity);
        Destroy(part1, 8.0f);
        Destroy(part2, 8.0f);
        Destroy(part3, 8.0f);
    }

    public void angelBarrier()
    {
        if(player1 == true && player2 == false)
        {
            Instantiate(shield, shieldLocation[0].transform.position, Quaternion.identity);
        }
        else if(player1 == false && player2 == true)
        {
            Instantiate(shield, shieldLocation[1].transform.position, Quaternion.identity);
        }
    }

    public void playerGreen()
    {
        player1 = true;
        player2 = false;
        //Debug.Log("Player1 is " + player1);
        //Debug.Log("Player2 is " + player2);
    }
    public void playerRed()
    {
        player1 = false;
        player2 = true;
        //Debug.Log("Player1 is " + player1);
        //Debug.Log("Player2 is " + player2);
    }

    public void cluster()
    {
        if(player1 == true)
        {
            ballActive += 2;
            GameObject ballTemp = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            GameObject ballTemp2 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ballTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed - 5, 0f);
            ballTemp2.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed - 7, 0f);
        }
        else if(player2 == true)
        {
            ballActive += 2;
            GameObject ballTemp = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            GameObject ballTemp2 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ballTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed + 5, 0f);
            ballTemp2.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed + 7, 0f);
        }
        
    }
    public void decoy()
    {
        if(player1 == true)
        {
            GameObject ballTemp = Instantiate(decoyPrefab, transform.position, Quaternion.identity);
            GameObject ballTemp2 = Instantiate(decoyPrefab, transform.position, Quaternion.identity);
            ballTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed - 5, 0f);
            ballTemp2.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed - 7, 0f);
        }
        else if(player2 == true)
        {
            GameObject ballTemp = Instantiate(decoyPrefab, transform.position, Quaternion.identity);
            GameObject ballTemp2 = Instantiate(decoyPrefab, transform.position, Quaternion.identity);
            ballTemp.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed + 5, 0f);
            ballTemp2.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed + 7, 0f);
        }
        
    }

    //[Space]
    #endregion

    //================================

    #region Collision Check:
    /*
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Do Something();
    }
    */


    //[Space]
    #endregion

    //================================

    #region RNG Systems:
    
    //StartCoroutine(MethodName());
    IEnumerator boostTimer()
    {
        ballspeed += 5;
        Debug.Log("Increased speed");
        yield return new WaitForSeconds(13.0f);
        ballspeed -= 5;
        Debug.Log("Decreased speed");
    }
    IEnumerator distractionTimer()
    {
        ballspeed += 5;
        Debug.Log("Increased speed");
        yield return new WaitForSeconds(10.0f);
        ballspeed -= 5;
        Debug.Log("Decreased speed");
    }

    IEnumerator spawnRed()
    {
        yield return new WaitForSeconds(3.0f);
    }

    //[Space]
    #endregion
    //================================
}

//================================
/*
[RequireComponent(typeof(ComponentName))]
Script requires specific component if needed
Player & Inventory script, attach both script to work or it 
will auto add required script/component if needed

[HideInInspector]
Hides the specific attributes if needed

[Tooltip("This is a definintion")]
Helps define what certain attributes do when you hover your mouse over the attributes title

[Range(0, 20)]
Adds a slider and type option for setting attributes for your Inspector

[DisallowedMultipleComponents]
//Prevents duplicates of same scripts/asses

[Multiline]
Multiple Lines to allow a better view of your paragraph inspector sentences

[System.Serializable]
Shows anything below declared header on Unity Inspector Menu
Also, if you have a class that isn't a Mono-behavior. Having this above the class will show the member of the class
Use an array to have multiple or list to have multiple and add ons with class members showcasing for each attributes
Use dot OP to access 
*/
//================================