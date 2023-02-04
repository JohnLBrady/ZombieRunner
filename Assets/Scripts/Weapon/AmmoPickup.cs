using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmmount = 5;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmmount);
            Destroy(gameObject);
        }
    }
}
