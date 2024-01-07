using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Cinemachine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEnemy;
    public GameObject weaponThrow;

    private Transform weaponChild;
    private Transform parentChange;

    public float fireRate = 200;
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

    private bool gun_loaded = false;
    private bool gun_empty_notified = false;

    public GameEvent gunshot;
    public GameEvent emptyGun;
    public GameEvent gunLoad;

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
                if (!gun_loaded)
                {
                    // Raise gunload event
                    gunLoad.Raise();
                    gun_loaded = true;
                }

                if (Input.GetMouseButton(0))
                {
                    if (fireTimer <= 0f)
                    {
                        if (ammo > 0)
                        {
                            if (!alertIsTrue.alert)
                            {
                                alertIsTrue.alert = true;
                            }
                                
                            ammo--;
                            Instantiate(bullet, weaponChild.position, father.transform.rotation);
                            // Raise gunshot event
                            gunshot.Raise();
                        }
                        else if (!gun_empty_notified)
                        {
                            // Barulho da arma vazia
                            gun_empty_notified = true;
                            // Raise empty gun event
                            emptyGun.Raise();

                        }
                        fireTimer = fireRate;
                    } else
                    {
                        fireTimer -= Time.deltaTime;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    gun_loaded = false;
                    this.transform.parent = null;
                    Instantiate(weaponThrow, this.transform.position, father.transform.rotation);
                    counterFix = GameObject.Find("PlayerWeapon").GetComponent<WeaponManager>();
                    counterFix.counter++;
                    newName = "Weapon Thrower " + counterFix.counter.ToString();
                    parentChange = GameObject.Find("WeaponThrower(Clone)").GetComponent<Transform>();
                    parentChange.name = newName;
                    this.transform.parent = parentChange;
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    gun_loaded = false;
                    Destroy(gameObject);
                }
                else
                {
                    fireTimer -= Time.deltaTime;
                    gun_empty_notified = false;
                }
            }
            else if(father.transform.name == "EnemyWeapon"){
                vision = father.GetComponentInChildren<EnemySeesPlayer>();
                grandfather = father.transform.parent.gameObject;
                RaycastHit2D hit = Physics2D.Raycast(father.transform.position, this.transform.parent.TransformDirection(Vector2.up), visionRange, hitters);
                if (alertIsTrue.alert && hit.transform.tag == "Player" && fireTimer <= 0f && ammo > 0){
                    grandfather.GetComponent<AIPath>().canMove = false;
                    ammo--;
                    Instantiate(bulletEnemy, weaponChild.position, father.transform.rotation);
                    // Raise gunshot event
                    gunshot.Raise();
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
