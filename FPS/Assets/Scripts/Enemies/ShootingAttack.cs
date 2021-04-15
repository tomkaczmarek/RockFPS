using Assets.Scripts.Events;
using Assets.Scripts.GameManager;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class ShootingAttack : EnemyBaseAttack
    {
        public GameObject bullet;
        public float timeBeetwenAttack = 3;
        public int playerMinDamage = 5;
        public int playerMaxDamage = 10;

        private Player.AbstractHealth _player;
        private bool _isAttack;

        public void Start()
        {
            playerMaxDamage += (int)GameManager.GameManager.Instance.GetLevelModification(playerMaxDamage);
            _player = FindObjectOfType<Player.PlayerHealth>();
        }

        public override void AttackBehavior(Transform enemyUnit, Transform target)
        {
            enemyUnit.LookAt(target);
            if (!_isAttack)
            {
                Rigidbody enemyRig = enemyUnit.GetComponent<Rigidbody>();
                enemyRig.MovePosition(enemyUnit.position);
                enemyUnit.LookAt(target);
                GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
               
                EventsManager bulletObject = obj.GetComponent<EventsManager>();              
                if (bulletObject != null)
                    bulletObject.OnDamage += BulletObject_OnDamage;

                Rigidbody rig = obj.GetComponent<Rigidbody>();
                rig.AddForce(transform.forward * 20f, ForceMode.Impulse);
                rig.AddForce(transform.up * 4f, ForceMode.Impulse);

                _isAttack = !_isAttack;
                Invoke(nameof(ResetAttack), timeBeetwenAttack);
            }
        }

        private void BulletObject_OnDamage()
        {
            _player.TakeDamage(Random.Range(playerMinDamage, playerMaxDamage));
        }
        private void ResetAttack()
        {
            _isAttack = false;
        }

    }
}