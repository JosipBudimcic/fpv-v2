using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;

public class SaveScript : MonoBehaviour
{
    public string Text;
    public float upForceDefault = 98.1f;
    public float inputAxis = -20;
    public float sideMovementAmount = 300;

    public void Save()
    {
        JSONObject DroneExample = new JSONObject();
        DroneExample.Add("upForceDefault", upForceDefault);
        DroneExample.Add("inputAxis", inputAxis);
        DroneExample.Add("sideMovementAmount", sideMovementAmount);
        Debug.Log("Save");
        //SAVE JSON IN COMPUTER
        string path = Application.persistentDataPath + "/DroneExample.json";
        File.WriteAllText(path, DroneExample.ToString());
    }
    public void Start()
    {
        Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

