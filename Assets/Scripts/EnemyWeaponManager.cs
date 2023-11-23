using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    private int ammoEnMan = 0;
    private int maxEnAmmoMan = 0;
    private Transform weaponTransform;

    void Update(){
        if (transform.childCount > 1){
            ammoEnMan = this.GetComponentInChildren<PlayerShoot>().ammo;
            maxEnAmmoMan = this.GetComponentInChildren<PlayerShoot>().maxAmmo;
        }
        else {
            ammoEnMan = 0;
            maxEnAmmoMan = 0;
        }
    }

    void OnTriggerStay2D(Collider2D weaponCollision){
        if (maxEnAmmoMan == 0 && weaponCollision.gameObject.tag == "Weapons"){
            weaponTransform = weaponCollision.GetComponent<Transform>();
            weaponTransform.parent = this.transform;
            weaponTransform.localPosition = Vector3.zero;
            weaponTransform.localRotation = Quaternion.Euler(0, 0, -90);
            weaponTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
