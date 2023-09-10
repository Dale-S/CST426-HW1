using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class UnlockJetpack : Pickup
{
    [Header("Parameters")] [Tooltip("Amount of time invincibility lasts in seconds")]
    private PlayerCharacterController player;

    
    protected override void OnPicked(PlayerCharacterController player)
    {
        this.player = player;
        Debug.Log("Collision detected");
        Jetpack jetpack = player.GetComponent<Jetpack>();
        jetpack.TryUnlock();
        Destroy(gameObject);
    }
}
