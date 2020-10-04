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

public class pGreen : MonoBehaviour
{
    //================================
    #region Variables:
    //[Header("Variables:")]
    //int i1;
    //string s1;
    //float f1;
    //bool b1;
    public float moveSpeed = 5.0f;
    public float topBounds = 4.0f;
    public float bottomBounds = -4.0f;
    public Vector2 startingPosition = new Vector2 (-7.0f, 0.0f);

    
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
    }

    // Update is called once per frame
    private void Update()
    {
        checkInput();
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

    public void checkInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(transform.localPosition.y > topBounds)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, topBounds, transform.localPosition.z);
            }
            else
            {
                transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            if(transform.localPosition.y < bottomBounds)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, bottomBounds, transform.localPosition.z);
            }
            else
            {
                transform.localPosition += Vector3.down * moveSpeed * Time.deltaTime;
            }
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