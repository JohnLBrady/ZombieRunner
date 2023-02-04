using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;

    public void TakeDamage(int damage){
        BroadcastMessage("EnemyDamageTaken");
        hitPoints -= Mathf.Abs(damage);
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
