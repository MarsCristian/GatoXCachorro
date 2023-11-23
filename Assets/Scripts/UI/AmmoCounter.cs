using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoText;
    private int thisAmmo;
    private int thisMaxAmmo;

    void Update(){
        thisAmmo = GameObject.Find("PlayerWeapon").GetComponent<WeaponManager>().ammoMan;
        thisMaxAmmo = GameObject.Find("PlayerWeapon").GetComponent<WeaponManager>().maxAmmoMan;
        if (thisMaxAmmo > 0)
            ammoText.text = "Ammo: " + thisAmmo.ToString() + "/" + thisMaxAmmo.ToString();
        else
            ammoText.text = "Punch!";
    }
}
