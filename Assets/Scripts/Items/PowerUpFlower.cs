using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : Collectable
{
    // this is the item ID for the flower itself.
    public int itmeID = 1;
    // the parent class is empty so there's no need to call base.OnCollect here.
    override protected void OnCollect(GameObject target){
        
        var equipBehavior = target.GetComponent<Equip>();
        
        if (equipBehavior != null){
            equipBehavior.currentItem = itmeID;
        }
    }
}
