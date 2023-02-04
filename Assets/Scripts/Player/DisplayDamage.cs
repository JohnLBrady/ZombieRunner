using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float screenTime = 0.3f;

    private void Start() {
        damageCanvas.enabled = false;
    }
    public void TriggerDamage(){
        StartCoroutine(DamageEffect());
    }

    private IEnumerator DamageEffect(){
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(screenTime);
        damageCanvas.enabled = false;
    }
}
