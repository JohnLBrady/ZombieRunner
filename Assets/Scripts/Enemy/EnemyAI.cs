using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    EnemyHealth enemyHealth;
    Transform target;
    
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start(){
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnDisable() {
        navMeshAgent.enabled = false;
    }

    void Update(){
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked){
            EngageTarget();
        }else if(distanceToTarget <= chaseRange){
            isProvoked = true;
        }
    }

    private void EngageTarget(){
        FaceTarget();
        if(navMeshAgent.stoppingDistance < distanceToTarget){
            ChaseTarget();
        }
        if(navMeshAgent.stoppingDistance >= distanceToTarget){
            AttackTarget();
        }
    }

    public void EnemyDamageTaken(){
        isProvoked = true;
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
