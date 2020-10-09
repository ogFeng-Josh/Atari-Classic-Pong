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

public class ballsystem : MonoBehaviour
{
    //================================
    #region Variables:
    //[Header("Variables:")]
    //int i1;
    //string s1;
    //float f1;
    //bool b1;
    //Player Last Touched
    //bool player1 = false;
    //bool player2 = false;

    //public GameObject ballPrefab; 
    private ballmanager ballGM;
    private GameMaster GM;
    public GameObject goalExplosion;

    //public Vector2 startingPosition = new Vector2 (7.0f, 0.0f);

    //[Space]
    #endregion

    //================================

    #region Unity Methods:

    // Start is called before the first frame update
    private void Awake()
    {
        ballGM = GameObject.FindObjectOfType<ballmanager>();
        GM = GameObject.FindObjectOfType<GameMaster>();
    }
    
    private void Start()
    {
        //DeclaredVariable = GameObject.Find("gameObjectName").GetComponent<ComponentName>();
    }

    // Update is called once per frame
    private void Update()
    {

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
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Collision Detection for Sound Effects
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "PlayerAI")
        {
            FindObjectOfType<audioManager>().Play("Ball Impact");
            
            //===========================================================================================
            //Diverts direction of ball to help simulate PONG game physics
            float dist = this.transform.position.y - GameObject.Find("playerGREEN").transform.position.y;
            float dist2 = this.transform.position.y - GameObject.Find("playerRED").transform.position.y;

            //Set boost ability in here. If ability active == true and player == that player who picked it up
            //Add * 2f to 5f of X to move faster
            if(collision.gameObject.name == "playerGREEN")
            {
                ballGM.playerGreen();
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(ballGM.ballspeed, dist * 2f);
            }
            else if(collision.gameObject.name == "playerRED")
            {
                ballGM.playerRed();
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-ballGM.ballspeed, dist2 * 2f);
            }
            //===========================================================================================
        }
        else if(collision.gameObject.tag == "boundary")
        {
            FindObjectOfType<audioManager>().Play("Boundary Impact");
        }
        else if(collision.gameObject.tag == "redGOAL" || collision.gameObject.tag == "greenGOAL")
        { 
            //Spawn explosion
            GameObject explosion = (GameObject)Instantiate(goalExplosion, transform.position, transform.rotation); 
            
            if(collision.gameObject.tag == "redGOAL")
            {
                //Debug.Log("Green Scored");
                ballGM.greenPoint();
                GM.greenScored();
            }
            else if(collision.gameObject.tag == "greenGOAL")
            {
                //Debug.Log("Red Scored");
                ballGM.redPoint();
                GM.redScored();
            }

            FindObjectOfType<audioManager>().Play("Score");

            ballGM.deductCount();
            //Destroys assets
            Destroy(gameObject);

            //Instantiate explosion
            Destroy(explosion, 1.0f);
            //transform.localPosition = (Vector3)startingPosition;

            //Change ball in play to opposite -
            //Write level manager script to take this data in
            //Then incorporate a timer countdown to spawn ball back in and
            //Change this data back 
        }
    }

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