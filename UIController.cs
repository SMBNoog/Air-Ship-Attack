using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public Text playerName_Text;
    public Text playerUIName_Text;
    public Text enterToContinue_Text;
    public GameObject inputField;

    StaticVariables var;

    void Start()
    {
        var = FindObjectOfType<StaticVariables>();
    }

	public void SetName()
    {
        string n = playerName_Text.text;
        var.SetPlayerName(n);
    }

    void Update()
    {
        playerUIName_Text.text = playerName_Text.text;
    }

    public void ShowEnterToContinueText()
    {
        enterToContinue_Text.gameObject.SetActive(true);
    }

    public void HideEnterToContinueText()
    {
        enterToContinue_Text.gameObject.SetActive(false);
    }

    public void HideInputFieldObjs()
    {
        inputField.SetActive(false);
    }
}
