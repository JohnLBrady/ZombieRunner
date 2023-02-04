using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int hitPoints = 100;


    public void AttackPlayer(int damage){
        hitPoints -= damage;
        if(hitPoints <= 0){
            KillPlayer();
        }
    }

    private void KillPlayer(){
        GetComponent<DeathHandler>().HandleDeath();
    }
}
