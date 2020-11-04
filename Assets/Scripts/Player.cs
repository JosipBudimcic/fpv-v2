using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class Player : MonoBehaviour {

    public float upForceDefault = 98.1f;
    public float inputAxis = -20;
    public float sideMovementAmount = 300;

    public void Save()
    {
        JSONObject DroneExample = new JSONObject();
        DroneExample.Add("upForceDefault", upForceDefault);
        DroneExample.Add("inputAxis", inputAxis);
        DroneExample.Add("sideMovementAmount", sideMovementAmount);

        //SAVE JSON IN COMPUTER
        string path = Application.persistentDataPath + "/DroneExample.json";
        File.WriteAllText(path, DroneExample.ToString());

    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/DroneExample.json";
        string jsonString = File.ReadAllText(path);
        JSONObject DroneExample = (JSONObject)JSON.Parse(jsonString);
        Debug.Log("load value");
        //SET VALUES
        upForceDefault = DroneExample["upForceDefault"];
        inputAxis = DroneExample["inputAxis"];
       sideMovementAmount= DroneExample["sideMovementAmount"];
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
       
    }

   }
