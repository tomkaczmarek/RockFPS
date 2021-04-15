using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using Assets.Scripts.UI;
using Assets.Scripts.Player;
using Assets.Scripts.Scenes;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManager
{
    public class GameManager : MonoBehaviour 
    {
        public int maxEnemyUnits;
        public float timeToEndLevel;
        public static GameManager Instance;
        public int startCounter = 3;
        public float gameLevelModification = 0.2f;
        public int enemyToKillToWin = 5;
        
        private AbstractHealth _player;
        private int _currentEnemyCount;
        private int _currentLevel;
        private int _currentEnemyKill = 0;
        private Events.UIEvents _uiEvents;
        public void Awake()
        {
            Time.timeScale = 1;
            _currentLevel = SceneMediator.CurrentLevel;
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void Start()
        {
            _uiEvents = GetComponent<Events.UIEvents>();
            _player = FindObjectOfType<PlayerHealth>();
            _currentLevel = SceneMediator.CurrentLevel;
            timeToEndLevel += GetLevelModification(timeToEndLevel);
            maxEnemyUnits += _currentLevel + 4;
            enemyToKillToWin = _currentLevel ==1 ? _currentLevel * maxEnemyUnits : maxEnemyUnits + _currentLevel + 5;
            _currentEnemyCount = 0;
        }

        public void Update()
        {  
            timeToEndLevel -= Time.deltaTime;
            SceneMediator.TotalTime += Time.deltaTime;

            if(_player.GetCurrentHealth() <= 0)
            {
                GameOver();
            }

            if(timeToEndLevel <= 0)
            {
                if (_currentEnemyKill >= enemyToKillToWin)
                    Win();
                else
                    GameOver();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _uiEvents.CallPauseMenu();
            }
        }

        public int GetCurrentEnemyKill()
        {
            return _currentEnemyKill;
        }

        public void RaiseEnemyKill()
        {
            _currentEnemyKill += 1;
            SceneMediator.EnemyKill += 1;
        }

        public float GetLevelModification(float valueToModification)
        {
            if (_currentLevel == 1)
                return 0;

            float value = valueToModification * (_currentLevel * gameLevelModification);
            return value;
        }

        private void Win()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            SceneMediator.IsWin = true;
            SceneMediator.CurrentLevel += 1;
            SceneManager.LoadScene("WinScene");
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            SceneMediator.CurrentLevel = 1;
            SceneMediator.LastLevel = _currentLevel;
            SceneManager.LoadScene("LoseScene");
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            AudioListener.volume = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public int GetEnemyUnitsCount()
        {
            return _currentEnemyCount;
        }

        public float GetLevelTime()
        {
            return timeToEndLevel;
        }

        public void IncreaseEnemyUnits()
        {
            _currentEnemyCount += 1;
        }

        public void DecreaseEnemyUnits()
        {
            _currentEnemyCount -= 1;
        }

    }
}