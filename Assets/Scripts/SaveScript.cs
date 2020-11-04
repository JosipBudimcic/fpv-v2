using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class SaveScript : MonoBehaviour
{

    public float upForce;
    void Save ()
    {
    JSONObject DroneExample = new JSONObject();
        DroneExample.Add("upForce",upForce);

        //SAVE JSON IN COMPUTER
        string path = Application.persistentDataPath + "/DroneExample.json";
    File.WriteAllText(path, DroneExample.ToString());
    }

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

