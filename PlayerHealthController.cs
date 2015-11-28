using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthController : MonoBehaviour {
    
    public Text playerHP_Text;  
    public Slider playerMagic_Slider;

    public Slider playerHP_Slider;
    
    private GameController game_Controller;
    private ScoreLevelController scoreAndLevelController;
    private bool playerFound = false;
    private bool godMode = false;

    void Start()
    {
        game_Controller = FindObjectOfType<GameController>();
        scoreAndLevelController = FindObjectOfType<ScoreLevelController>();
    }

    void Update()
    {
        if(Player.instance != null)            
        {
            if (Player.instance.Health <= 0 && !godMode)
                game_Controller.GameOver();
            else if (Player.instance.Health < 0)
                Player.instance.Health = 0;
            // Update the HP UI
            playerHP_Slider.value = Player.instance.Health;
            playerHP_Text.text = "" + Player.instance.Health;
        }
    }
    
    public void GodMode(bool b)
    {
        godMode = b;
    }

    public bool isGodMode()
    {
        return godMode;
    }
    
}
