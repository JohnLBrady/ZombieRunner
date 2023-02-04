using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetWeaponActive(0);
    }

    private void SetWeaponActive(int weaponSwitch)
    {
        currentWeapon = weaponSwitch;
        int weaponIndex = 0;

        foreach(Transform weapon in transform){
            if(weaponIndex == currentWeapon){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    public void OnSelectWeapon0(){
        SetWeaponActive(0);
    }

    public void OnSelectWeapon1(){
        SetWeaponActive(1);
    }

    public void OnSelectWeapon2(){
        SetWeaponActive(2);
    }

    public void OnScrollWeapon(InputValue value){
        //float scroll = Mouse.current.scroll.ReadValue().y;
        float scroll = value.Get<float>();
        if(scroll < 0){
            if(currentWeapon + 1 > transform.childCount - 1){
                SetWeaponActive(0);
            }else{
                SetWeaponActive(currentWeapon + 1);
            }
        }else if(scroll > 0){
            if(currentWeapon - 1 < 0){
                SetWeaponActive(transform.childCount-1);
            }else{
                SetWeaponActive(currentWeapon - 1);
            }
        }
    }
}
