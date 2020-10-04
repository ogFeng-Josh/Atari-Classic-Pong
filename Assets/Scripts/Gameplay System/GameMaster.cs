/*
Unity Skeleton Script
Written by Josh Y. (ogfeng)
Contact - ogfeng.streamers.site
*/

//Disable/Enable 2nd player controller or Ai Player
//Counts score / Set active scene for Win/Lost scene and timescale


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Additional Libraries:
//================================
using TMPro;
//using System; //Allows us to use Array.ETC
//using UnityEngine.Audio; //Libraries Assets for Unity Audio System
using UnityEngine.UI; //Libraries Assets for Unity UI
using UnityEngine.SceneManagement; //Libraries Assets for Unity Scene Transition/Management
//using UnityEngine.Video; //Libraries Assets for Unity Video Component

//Documentations:
//================================
//[HelpUrl("URL")] Allows user to set a link to a documentation for reference

public class GameMaster : MonoBehaviour
{
    //================================
    #region Variables:
    //[Header("Variables:")]
    //int i1;
    //string s1;
    //float f1;
    //bool b1;

    //Max score set by player
    public int maxScore1 = 3;
    public int maxScore2 = 5;
    public int maxScore3 = 7;
    public int setLimit = 2;

    //Player score 
    public int p1Score = 0;
    public int p2Score = 0;

    public TextMeshProUGUI p1Display;
    public TextMeshProUGUI p2Display; 

    //Game Over System
    public bool gameover = false;
    public GameObject winScreen;
    
    //[Space]
    #endregion

    //================================

    #region Unity Methods:

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    
    private void Start()
    {
        //DeclaredVariable = GameObject.Find("gameObjectName").GetComponent<ComponentName>();
        p1Score = 0;
        p2Score = 0;
        gameover = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(gameover == true)
        {
            gameOver();
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
    public void greenScored()
    {
        if(p1Score < setLimit)
        {   
            p1Score++;
            p1Display.text = p1Score.ToString();
        }
        else
        {
            //Green Wins Display!
            gameover = true;
        }
    }
    public void redScored()
    {
        if(p2Score < setLimit)
        {   
            p2Score++;
            p2Display.text = p2Score.ToString();
        }
        else
        {
            //Red Wins Display!
            gameover = true;
        }
    }

    public void gameOver()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("_mainmenu");
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