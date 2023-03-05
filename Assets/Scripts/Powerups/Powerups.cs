using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public static Powerups instance;
    public static bool shouldPowerupSpawn; //this shows if there should be spawned a powerup
    public static bool areEnoughPoints; //this shows if inital amount of points is met
    public static int alteration; //watches alteration of left and right laser

    public GameObject guardian; //holds reference to the guardian prefab
    public GameObject laser; //holds reference to the laser prefab
    public GameObject gate; //holds reference to the doors prefab

    public Sprite normalPlatform; // holds platform states
    public Sprite warPlatform;

    public bool isBallPowerful;

    private Platform platform; //holds reference to the main platform
    private GameObject guard; //holds the right guardian shield
    
    // Start is called before the first frame update
    void Start()
    {                   //this sets up all needed objects and variables at the start of the level
        alteration = -1;
        instance = this;
        isBallPowerful = false;
        shouldPowerupSpawn = true;
        guard = Instantiate(guardian);
        guard.SetActive(false);
        platform = FindObjectOfType<Platform>();
        //guard.transform.position = new Vector2();
    }

    public void enableGuard()
    {
        guard.SetActive(true);
        Invoke("disableGuard", 10f);
    }

    public void disableGuard()
    {
        guard.SetActive(false);        
    }

    public void interruptGuard()
    {
        CancelInvoke("disableGuard");
        guard.SetActive(false);
    }

    public void longPlatform()
    {
        platform.transform.localScale = new Vector3(0.5f, 1, 1);
        platform.GetComponentInChildren<Transform>().localScale = new Vector3(2, 1, 1);
    }

    public void shortPlatform()
    {
        platform.GetComponentInChildren<Transform>().localScale = Vector3.one;
        platform.transform.localScale = Vector3.one;
    }

    private void makeLaser()
    {
        var temp = Instantiate(laser);
        temp.transform.position = new Vector2(platform.transform.position.x + (alteration * 0.25f), platform.transform.position.y+0.05f);
        alteration *= -1;
    }

    public void laserEnabled()
    {
        platform.GetComponent<SpriteRenderer>().sprite = warPlatform;
        InvokeRepeating("makeLaser", 0f, 1.5f);
    }

    public void laserDisabled()
    {
        platform.GetComponent<SpriteRenderer>().sprite = normalPlatform;
        CancelInvoke("makeLaser");
    }

    public void createExits()
    {
        var brama1 = Instantiate(gate);
        brama1.transform.position = new Vector2(-8.78f, -4.1f);
        var brama2 = Instantiate(gate);
        brama2.transform.position = new Vector2(8.728f, -4.1f);
    }

    public void resetPowerups()
    {
        interruptGuard();
        shortPlatform();
        laserDisabled();
        isBallPowerful = false;
        if(FindObjectOfType<PowerupCapsule>() != null)
        {
            Destroy(FindObjectOfType<PowerupCapsule>().gameObject);
        }
    }

    void hardRefresh()
    {
        shouldPowerupSpawn = true;
        Debug.Log("pawn");
    }

    public void refreshCapsule()
    {
        Debug.Log("res");
        Invoke("hardRefresh", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<PowerupCapsule>().Length > 1) //ensures that only one capsule is at one time
        {
            Destroy(FindObjectOfType<PowerupCapsule>().gameObject);
        }
    }
}
