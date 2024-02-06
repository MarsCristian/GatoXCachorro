using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int ammoMan = 0;
    public int maxAmmoMan = 0;
    public int counter = 0;
    private Transform weaponTransform;
    public LayerMask guns;

    void Update(){
        if (transform.childCount > 1){
            ammoMan = this.GetComponentInChildren<PlayerShoot>().ammo;
            maxAmmoMan = this.GetComponentInChildren<PlayerShoot>().maxAmmo;
            if (transform.childCount > 2)
                for (int k = 2; k < transform.childCount; k++)
                   this.gameObject.transform.GetChild(k).parent = null;
        }
        else {
            ammoMan = 0;
            maxAmmoMan = 0;
            Collider2D[] col = Physics2D.OverlapCircleAll(this.gameObject.transform.position, this.GetComponent<CircleCollider2D>().radius, guns);
            if(col.Length > 0){
                weaponTransform = col[0].gameObject.transform;
                weaponTransform.parent = this.transform;
                weaponTransform.localPosition = Vector3.zero;
                weaponTransform.localRotation = Quaternion.Euler(0, 0, 180);
                weaponTransform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    /*
    void OnTriggerStay2D(Collider2D weaponCollision){
        if (maxAmmoMan == 0 && weaponCollision.gameObject.tag == "Weapons"){
            weaponTransform = weaponCollision.GetComponent<Transform>();
            weaponTransform.parent = this.transform;
            weaponTransform.localPosition = Vector3.zero;
            weaponTransform.localRotation = Quaternion.Euler(0, 0, 90);
            weaponTransform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    */
}
