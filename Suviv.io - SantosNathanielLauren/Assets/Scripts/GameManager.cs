using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int EnemyAmount;
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
    }

    public void WinGame()
    {
        SceneManager.LoadScene(3);
    }
}
