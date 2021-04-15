using Assets.Scripts.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Text>().text = $"Your score is:{Environment.NewLine}total enemy kill: {SceneMediator.EnemyKill}{Environment.NewLine}total time: {TimeSpan.FromSeconds(SceneMediator.TotalTime).ToString("hh':'mm':'ss")}{Environment.NewLine}max level: {SceneMediator.LastLevel}";
    }

}
