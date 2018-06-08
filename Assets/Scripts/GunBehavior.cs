using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    [SerializeField] private GunParams gunParams;
    [Range(0.2f, 5)] [SerializeField] private float shotDelay;

    private Transform bulletSource;
    private float nextFire;

    void Start ()
    {
        bulletSource = GetComponentsInChildren<Transform>()[1];
	}
	
	void Update ()
    {
        // shoot with bullet prefab
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + shotDelay;
            GameObject bull = Instantiate(bullet, bulletSource.position, Quaternion.identity);
            //GameObject bull = Instantiate((Resources.Load("Bullet") as GameObject), bulletSource.position, Quaternion.identity, this.gameObject.transform);
            Rigidbody bulletRb = bull.GetComponent<Rigidbody>();
            bulletRb.velocity = new Vector3(0, 0, gunParams.speed);
            bulletRb.mass = gunParams.mass;
            // set bullet time to live
            bull.GetComponent<BulletBehavior>().ttl = gunParams.timeToLive;
        }

        // shoot with selected geometric primitive
        if (Input.GetKey(KeyCode.LeftAlt) && Time.time > nextFire)
        {
            nextFire = Time.time + shotDelay;
            GameObject prim = GameObject.CreatePrimitive(gunParams.bulletShape);
            // set position and scale
            prim.transform.position = bulletSource.position;
            prim.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            // set physics properties
            Rigidbody primRb = prim.AddComponent<Rigidbody>();
            primRb.velocity = new Vector3(0, 0, gunParams.speed);
            primRb.mass = gunParams.mass;
        }
    }
}
