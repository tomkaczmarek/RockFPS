using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingBehevior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thisGameObject;
    public Camera camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            foreach (Transform weapons in transform)
            {
                if (weapons.gameObject.activeSelf)
                {
                    AbstractWeapons weapon = WeaponFactory.GetWeapon(weapons.gameObject.name, thisGameObject);
                    weapon.ShootBehavior(camera, weapon.GetDamage());
                }
            }          
    }
}
