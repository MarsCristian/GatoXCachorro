using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEnemy;
    public GameObject weaponThrow;

    private Transform weaponChild;
    private Transform parentChange;

    public float fireRate = 5;
    private float fireTimer = 0f;
    public int ammo = 0;
    public int maxAmmo = 30;

    public PlayerMovement alertIsTrue;
    public AIPath aiPath;
    private GameObject father;
    private GameObject grandfather;
    private WeaponManager counterFix;
    private string newName;

    public LayerMask hitters;
    public EnemySeesPlayer vision;
    public float visionRange = 15f;

    void Start(){
        ammo = maxAmmo;
        weaponChild = this.gameObject.transform.GetChild(0);
        alertIsTrue = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (this.transform.parent != null){
            father = this.transform.parent.gameObject;
            GetComponent<CircleCollider2D>().enabled = false;
            if (father.transform.name == "PlayerWeapon"){
                if (Input.GetMouseButton(0) && fireTimer <= 0f && ammo > 0)
                {
                    if (!alertIsTrue.alert)
                        alertIsTrue.alert = true;
                    ammo--;
                    Instantiate(bullet, weaponChild.position, father.transform.rotation);
                    fireTimer = fireRate;
                }
                else if (Input.GetKeyDown(KeyCode.Q)){
                    this.transform.parent = null;
                    Instantiate(weaponThrow, this.transform.position, father.transform.rotation);
                    counterFix = GameObject.Find("PlayerWeapon").GetComponent<WeaponManager>();
                    counterFix.counter++;
                    newName = "Weapon Thrower " + counterFix.counter.ToString();
                    parentChange = GameObject.Find("WeaponThrower(Clone)").GetComponent<Transform>();
                    parentChange.name = newName;
                    this.transform.parent = parentChange;
                }
                else if (Input.GetKeyDown(KeyCode.E)){
                    Destroy(gameObject);
                }
                else
                    fireTimer -= Time.deltaTime;
            }
            else if(father.transform.name == "EnemyWeapon"){
                vision = father.GetComponentInChildren<EnemySeesPlayer>();
                grandfather = father.transform.parent.gameObject;
                RaycastHit2D hit = Physics2D.Raycast(father.transform.position, this.transform.parent.TransformDirection(Vector2.up), visionRange, hitters);
                if (alertIsTrue.alert && hit.transform.tag == "Player" && fireTimer <= 0f && ammo > 0){
                    grandfather.GetComponent<AIPath>().canMove = false;
                    ammo--;
                    Instantiate(bulletEnemy, weaponChild.position, father.transform.rotation);
                    fireTimer = fireRate;
                }
                else if(alertIsTrue.alert && !(hit.transform.tag == "Player") && fireTimer <= 0f && ammo > 0){
                    grandfather.GetComponent<AIPath>().canMove = true;
                    fireTimer -= Time.deltaTime;
                }
                else {
                    fireTimer -= Time.deltaTime;
                }
            }
        }
        else {
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
