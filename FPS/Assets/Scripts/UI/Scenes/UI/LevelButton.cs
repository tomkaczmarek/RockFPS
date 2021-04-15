using Assets.Scripts.GameManager;
using Assets.Scripts.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        SetLevel();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SetLevel()
    {
        Text levelText = transform.Find("LevelText").GetComponent<Text>();
        levelText.text = $"Level {SceneMediator.CurrentLevel}";
    }
}
