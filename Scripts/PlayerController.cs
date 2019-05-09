using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameScene, winScene, gameOverScene;
    public static float sideVelocity = 0.1f, upThrust = 0.1f, forceOfGravity;

    public int wickHitCount = 0;
    public static int wicksNeededToWin = 7;
    private DataController dataController;
    private GameData gameData;
    private GameSceneData gameSceneData;
    public GameObject coverLayer;

    public GameObject deathParticle;
    public GameObject responseParticle;
    public float delaytime;
    //public GameObject blood;
    Rigidbody2D rb2d;

    void OnEnable()
    //void Start()
    {
        Debug.Log("player controller called here");
        gameScene.SetActive(true);
      
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        gameSceneData = gameData.gameSceneData;

        wickHitCount = 0;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = gameSceneData.forceOfGravity;
        gameObject.transform.localPosition = new Vector3(-1000, 200, 0);
        coverLayer.GetComponent<Renderer>().material.color = new Color((float)9/256, (float)9/256f, (float)14/256f, 0.95f);
    }

    void Update()
    {
        if (Input.touchCount>0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upThrust));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("see this check Player Controller");
        if (other.gameObject.tag == "Goal")
        {
            wickHitCount++;
            other.gameObject.GetComponent<Renderer>().material.color = Color.clear;

            //Debug.Log("Got here " + (float)wickHitCount/7);
            coverLayer.GetComponent<Renderer>().material.color = new Color((float)9 / 256, (float)9 / 256f, (float)14 / 256f, (1 - (float)wickHitCount / wicksNeededToWin));

            if (wickHitCount == wicksNeededToWin)
            {
                gameScene.SetActive(false);
                winScene.SetActive(true);
            }
        }

        if (other.gameObject.tag == "touch")
        {
            other.gameObject.GetComponent<Renderer>().enabled = true;
        }

        else if (other.gameObject.tag == "Obstacle")
        {
            Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
            
            StartCoroutine("KilledCo");
            //gameObject.SetActive(false);
           
            gameObject.GetComponent<Renderer>().material.color = Color.clear;
            Debug.Log("Ayyyyy 1");

        }
    }

    public static int GetWicksNeededToWin()
    {
        return wicksNeededToWin;
    }
    public static void SetWicksNeededToWin(int set)
    {
        wicksNeededToWin = set;
    }

    public static float getForceOfGravity()
    {
        return forceOfGravity;
    }

    public static void setForceofGravity(float gravity)
    {
        forceOfGravity = gravity;
    }

    public static float getSidevelocity()
    {
        return sideVelocity;
    }
    public static void setSideVelocity(float sideVel)
    {
        sideVelocity = sideVel;
    }
    public static float getUpThrust()
    {
        return upThrust;
    }
    public static void setUpThrust(float upThr)
    {
        upThrust = upThr;
    }

    /*private void Killed()
    {
             StartCoroutine("KilledCo");
             Debug.Log("Ayyyyy 2");
            Debug.Log("Ayyyyy 3");
            gameScene.SetActive(false);
            gameOverScene.SetActive(true);

    }*/
    public IEnumerator KilledCo()
        {
        //Instantiate(blood, transform.position, Quaternion.identity);
        //Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
        //gameObject.SetActive(false);
            Debug.Log("got here");
           // gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            gameScene.SetActive(false);
            gameOverScene.SetActive(true);
        // killed();
    }
    }

