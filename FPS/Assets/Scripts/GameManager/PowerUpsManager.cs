using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.PowerUp;
using System.Linq;
using Assets.Scripts.Events;

namespace Assets.Scripts.GameManager
{
    public class PowerUpsManager : MonoBehaviour
    {
        public static PowerUpsManager Instance;  
        
        private List<AbstractPowerUp> playerPowers;


        public void Awake()
        {
            if (Instance != null)
                Destroy(this);
            else
                Instance = this;

           playerPowers = new List<AbstractPowerUp>();
        }

        public void RegisterPower(GameObject obj)
        {
            if(obj != null)
            {
                AbstractPowerUp power = obj.GetComponent<AbstractPowerUp>();
                if (!playerPowers.Where(x => x.PowerName() == power.PowerName()).Any())
                {
                    power.IsActiveOnPlayer = true;
                    power.OnActiveEnd += Power_OnActiveEnd;
                    playerPowers.Add(power);
                    if (power.IsReuseable())
                        obj.GetComponent<MeshRenderer>().enabled = false;
                    SoundEvents sound = obj.GetComponent<SoundEvents>();
                    if (sound != null)
                        sound.CallPowerUpGet();
                }
            }
        }

        private void Power_OnActiveEnd(GameObject obj)
        {
            if (obj != null)
            {
                UnRegisterPower(obj);
            }            
        }

        public void UnRegisterPower(GameObject obj)
        {          
            if (playerPowers.Count >0)
            {
                AbstractPowerUp power = obj.GetComponent<AbstractPowerUp>();
                if (playerPowers.Where(x => x.PowerName() == power.PowerName()).Any())
                {
                    playerPowers.Remove(power);
                    power.NotificationVisibility(false);
                    if (power.IsReuseable())
                        obj.GetComponent<MeshRenderer>().enabled = true;
                    SoundEvents sound = obj.GetComponent<SoundEvents>();
                    if (sound != null)
                        sound.CallPowerUpGet();
                }
               
            }           
        }

        public T GetActivePowerByType<T>() where T : AbstractPowerUp
        {
            if (playerPowers.Count > 0)
            {
               foreach(AbstractPowerUp power in playerPowers)
                {
                    if (power is T && power.IsActiveOnPlayer && power.IsReuseable())
                        return power as T;
                }
            }
            return null;
        }

        public void Update()
        {
           foreach(var p in playerPowers.Where(x=>x.IsActiveOnPlayer))
            {
                p.NotificationVisibility(true);
                p.UpdateNotyfication();
            }
        }
    }
}