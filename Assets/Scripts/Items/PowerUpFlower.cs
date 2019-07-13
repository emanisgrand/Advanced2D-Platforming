using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : Collectable
{
    
    // this is the item ID for the flower itself.
    public int itemID = 1;
    public GameObject projectilePrefab;

    // the parent class is empty so there's no need to call base.OnCollect here.
    override protected void OnCollect(GameObject target){
        
        var equipBehavior = target.GetComponent<Equip>();
        
        if (equipBehavior != null){
            equipBehavior.currentItem = itemID;
        }

        /* this behavior will allow me to set the flower up as the gameobject
        that sets the projectile prefab onto the FireProjectile script.  */
        var shootBehavior = target.GetComponent<FireProjectile>();
        if (shootBehavior != null){
            shootBehavior.projectilePrefab = projectilePrefab;
        }
    }
}
