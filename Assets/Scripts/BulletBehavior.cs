using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private Light lght;
    public float ttl { get; set; }

    private void Start()
    {
        lght = GetComponent<Light>();
        if (lght != null)
        {
            lght.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    private void OnBecameVisible()
    {
        Debug.Log("Bullet fired");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Timer.AddAsUniqueComponent(this.gameObject, ttl, () => Destroy(this.gameObject));
    }

}
