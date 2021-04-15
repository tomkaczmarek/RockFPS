using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Scenes
{
    public enum GameMode
    {
        Play = 1,
        Pause = 2
    }
    public static class SceneMediator
    {
        public static int CurrentLevel = 1;

        public static int LastLevel;

        public static GameMode CurrentGameMode;

        public static bool IsWin;

        public static void ResetGame()
        {
            IsWin = false;
            CurrentLevel = 1;
            CurrentGameMode = GameMode.Play;
        }

        public static int EnemyKill;
        public static float TotalTime;
    }
}