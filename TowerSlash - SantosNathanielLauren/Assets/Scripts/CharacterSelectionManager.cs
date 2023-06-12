using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public string[] CharacterNames;
    public int[] CharacterHPs;
    public int[] CharacterDashMeter;
    public Sprite[] CharacterSprites;
    public int CharacterSelector;
    public TextMeshProUGUI StatText;
    public Image CharacterImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StatText.text = "Name: " + CharacterNames[CharacterSelector] + "\n Lives: " + CharacterHPs[CharacterSelector] + "\n Dash Guage Mod: " + CharacterDashMeter[CharacterSelector];
    }

    public void NextCharacter() 
    {
        
        if (CharacterSelector==2) 
        {
            CharacterSelector = -1;
        }
        CharacterSelector++;
        CharacterImage.sprite = CharacterSprites[CharacterSelector];
    }
    public void PrevCharacter()
    {

        if (CharacterSelector == 0)
        {
            CharacterSelector = 3;
        }
        CharacterSelector--;
        CharacterImage.sprite = CharacterSprites[CharacterSelector];
    }

    public void SelectCharacter() 
    {
        PlayerData.Instance.Health = CharacterHPs[CharacterSelector];
        PlayerData.Instance.DashMeterMod = CharacterDashMeter[CharacterSelector];
        PlayerData.Instance.PlayerSprite = CharacterSprites[CharacterSelector];
        PlayerData.Instance.ResetGame();
        SceneManager.LoadScene(1);
    }
}
