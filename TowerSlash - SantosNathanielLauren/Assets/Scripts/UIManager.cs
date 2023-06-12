using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI ScoringText;
    // Update is called once per frame
    void Update()
    {
        LifeText.text = "Lives - " + PlayerData.Instance.CurrentHP;
        ScoringText.text = "Score: " + PlayerData.Instance.Points;
    }
}
