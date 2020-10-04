﻿/*
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
    public float ballspeed = 7.0f;

    //Ball direction after spawning
    public bool redscored = false;
    public bool greenscored = false;

    //Respawn Process
    public bool outofplay = false;
    
    //Ball Prefab
    public GameObject ballPrefab;

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

        //Give countdown to RNG spawn
        rngSpawn();


    }

    // Update is called once per frame
    private void Update()
    {
        if(outofplay == true)
        {
            resetround();
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
        ballPrefab.transform.position = new Vector3(0f, 0f, 0f);
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        
        int spawnpick = Random.Range (0, 2);

        if(spawnpick == 0)
        {
            ballPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed, 0f);
        }
        else if(spawnpick == 1)
        {
            ballPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed, 0f);
        }

    }

    public void resetround()
    {
        outofplay = false;
        ballPrefab.transform.position = new Vector3(0f, 0f, 0f);
        Instantiate(ballPrefab, transform.position, Quaternion.identity);

        if(greenscored == true)
        {
            greenscored = false;
            ballPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(ballspeed, 0f);
        }
        else if(redscored == true)
        {
            redscored = false;
            ballPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballspeed, 0f);
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
    /*
    //StartCoroutine(MethodName());
    IEnumerator MethodName()
    {
        yield return new WaitForSeconds(#f);
    }
    */

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