using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreLevelController : MonoBehaviour {

    public Slider playerEXP_Slider;
    public Slider playerMagic_Slider;
    public Text level_Text;
    public Image shotIcon_Image;
    public Sprite[] shotSpriteArray;

    public int[] levelUpPoint;

    private int exp;
    private int level;
    private int levelEXP_OffSet;
    private int magic;
    private int levelMagic_OffSet;
    private bool playerFound = false;
    private bool levelCap = false;

    PlayerController player_Controller;
    EnemyController enemy_Controller;

    void Start()
    {
        exp = 0;
        magic = 0;
        level = 1;

        shotIcon_Image.sprite = shotSpriteArray[0];

        enemy_Controller = FindObjectOfType<EnemyController>();
    }

    void Update()
    {
        level_Text.text = "" + level;

        int index = level-1;

        // If the lvl cap has not been reached
        if (!levelCap)
        {
            // Check if the exp is enough to level up 
            if (exp >= levelUpPoint[index])
            {
                level++;
                index++;
                levelEXP_OffSet += 10000;
            }

            if(magic == 100 && player_Controller.GetSpreadAmount() == 1)
            {
                levelMagic_OffSet += 100;
            }
        }

        // Once level 10 is reached spawn the Boss and stop minions.
        if(level == 10 && !levelCap)
        {
            enemy_Controller.StopSpawningMinions();
           // enemy_Controller.StartSpawnBoss();
            
            levelCap = true;
        }
        
        // Update the EXP UI
        playerEXP_Slider.value = exp - levelEXP_OffSet;

        playerMagic_Slider.value = magic - levelMagic_OffSet;
                
        if(player_Controller == null)
        {
            player_Controller = FindObjectOfType<PlayerController>();
            player_Controller.SetSpreadAmount(1);
            playerFound = true;
        }

        if (magic == 100 && player_Controller.GetSpreadAmount() == 1)
        { 
            Debug.Log("100 Magic reached");
            player_Controller.SetSpreadAmount(3);
            shotIcon_Image.sprite = shotSpriteArray[1];
        }

        if(magic == 200 && player_Controller.GetSpreadAmount() == 3)
        {
            Debug.Log("200 Magic reached");
            player_Controller.SetSpreadAmount(5);
            shotIcon_Image.sprite = shotSpriteArray[2];
        }
    }

    public void AddExp(int s)
    {
        exp += s;
    }

    public int GetEXP()
    {
        return exp;
    }
        
    public int GetLevel()
    {
        return level;
    }

    public void AddMagic(int m)
    {
        magic += m;
    }

    public int GetMagic()
    {
        return magic;
    }
}
