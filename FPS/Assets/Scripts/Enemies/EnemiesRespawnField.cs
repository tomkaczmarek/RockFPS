using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemiesRespawnField : MonoBehaviour
    {
        public GameObject enemyToRespawn;
        public float timeBeetwenSimpleRespawnFrom = 3;
        public float timeBeetwenSimpleRespawnTo = 3;

        private float _timeLeft;
        private bool _isCreate;

        public void Start()
        {
            _timeLeft = Random.Range(timeBeetwenSimpleRespawnFrom, timeBeetwenSimpleRespawnTo);
        }

        public void Update()
        {
            if (!_isCreate && GameManager.GameManager.Instance.GetEnemyUnitsCount() < GameManager.GameManager.Instance.maxEnemyUnits)
            {
                GameObject obj =  Instantiate(enemyToRespawn, transform.position, Quaternion.identity);
                obj.SetActive(true);
                _timeLeft = Random.Range(timeBeetwenSimpleRespawnFrom, timeBeetwenSimpleRespawnTo);
                _isCreate = !_isCreate;
                GameManager.GameManager.Instance.IncreaseEnemyUnits();
                Invoke(nameof(ResetTimer), _timeLeft);
            }
        }

        private void ResetTimer()
        {
            _isCreate = false;
        }
    }
}