using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMenu1 : MonoBehaviour
{
    public GameObject InputField;
    public InputField inputField;
    public SaveScript saveScript;

    
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var Text = new InputField.SubmitEvent();
        Text.AddListener(SubmitName);
        input.onEndEdit = Text;
    }
    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        
    }



}
