using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;
using UnityEditor;


public class MainMenu : MonoBehaviour
{
    // define and create our GUI delegate
    private delegate void GUIMethod();
    private GUIMethod currentGUIMethod;
    
    void Start()
    {
        // start with the main menu GUI
        this.currentGUIMethod = MainMenu1;
    }

    public void MainMenu1()
    {
        if (GUI.Button(new Rect(10, 25, Screen.width - 220, 40), "Quick play"))
        {
            // options button clicked, switch to new menu
            this.currentGUIMethod = QuickPlay;
        }
       
        if (GUI.Button(new Rect(10, 150, Screen.width - 220, 40), "Controller"))
        {
            
                // Load scene
                SceneManager.LoadScene("ControllerMenu1");
            
        }
        if (GUI.Button(new Rect(10, 200, Screen.width - 220, 40), "Exit"))
        {
            // options button clicked, switch to new menu
            this.currentGUIMethod = ExitMenu;
        }


    }

   
    private void QuickPlay()
    {
        GUI.TextArea(new Rect(10, 25, Screen.width - 220, 40), "Are you shure");

        if (GUI.Button(new Rect(10, 60, Screen.width - 220, 40), "yes"))
        {
            // Load scene
            SceneManager.LoadScene("DroneSim");
        }
        if (GUI.Button(new Rect(10, 150, Screen.width - 220, 40), "no"))
        {
            // go back to the main menu
            this.currentGUIMethod = MainMenu1;
        }

    }

      private void ExitMenu()
    {
        if (GUI.Button(new Rect(10, 60, Screen.width - 220, 40), "yes"))
        {
            // exit
            Application.Quit();
        }
        if (GUI.Button(new Rect(10, 150, Screen.width - 220, 40), "no"))
        {
            // go back to the main menu
            this.currentGUIMethod = MainMenu1;
        }
    }

    // Update is called once per frame 
    public void OnGUI()
    {
        this.currentGUIMethod();
    }
}