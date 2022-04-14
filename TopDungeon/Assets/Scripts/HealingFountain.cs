using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : Collidable
{
   public int healingAmount = 1;

   private float healCooldown = 1.0f;
   private float lastHeal;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name != "Player")
            return;
        // If (Right now - the lastHeal time is greater than the healCooldown)
        if(Time.time - lastHeal > healCooldown)
        {
            // Sets the last heal to now
            lastHeal = Time.time;
            // HealingFountain function called on the player through the game manger
            GameManager.instance.player.Heal(healingAmount);
        }
    }
}
