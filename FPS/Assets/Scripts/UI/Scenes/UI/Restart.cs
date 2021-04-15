using Assets.Scripts.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    public void RestartLevel()
    {
        SceneMediator.ResetGame();
        SceneManager.LoadScene("MainScene");
    }
}
