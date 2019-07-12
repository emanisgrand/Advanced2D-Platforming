using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : AbstractBehavior {
    /* //an '_' is used because we we're gonna use a public getter and 
    setter called currentItem and we can't have the two with the same 
    name.*/
    
    private int _currentItem = 0; 
    private Animator animator;

    /* Here we use the get set to create an integer called current item.
    This is something that I've used maybe like 5 times in my entire coding
    career. I know it to be powerful and have a pretty good understanding
    of how it's supposed to work, but I am leaving this note here for myself
    !to pay special attention to its functionality in how it is being used here. */
    
    //!Unity will not make this public in the inspector because it is a getter/setter
    public int currentItem {
            get{ return _currentItem; } // current item is a count here. I assume we're going to increment every time we pick up a collectable
            set{
                _currentItem = value;   // whatever we set currentitem to will resolve to value automatically. I think this just means that it's storing the amount.
                animator.SetInteger("EquippedItem", _currentItem); /*I wasn't even aware that you could set animator values within the setter of an int. */
            }
        }
    override protected void Awake(){
        base.Awake();
        animator = GetComponent<Animator>(); // here we grab the animator reference because there isn't a reference to it in the original AbstractBehavior.cs
    }
}
