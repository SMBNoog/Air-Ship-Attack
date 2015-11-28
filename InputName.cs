using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputName : MonoBehaviour {

    public InputField inputField;
    StaticVariables vars;

    void Start()
    {
        vars = FindObjectOfType<StaticVariables>();
    }

    public void SetName()
    {
        Text[] textArray = inputField.GetComponentsInChildren<Text>();
        foreach(Text t in textArray)
        {
            if (t.gameObject.name == "Text_UserName")
                vars.SetPlayerName(t.text);
        }

        Debug.Log(vars.GetPlayerName());

        // Activate Button
    }
}
