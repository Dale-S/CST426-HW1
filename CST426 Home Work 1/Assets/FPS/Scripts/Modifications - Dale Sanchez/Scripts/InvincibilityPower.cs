using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using Unity.Play.Publisher.Editor;
using UnityEngine;

//namespace Unity.FPS.Gameplay;


public class InvincibilityPower : Pickup
{
    [Header("Parameters")] [Tooltip("Amount of time invincibility lasts in seconds")]
    public float sec;
    private PlayerCharacterController player;
    public GameObject invText;
    public MeshRenderer itemMesh;
    
    protected override void OnPicked(PlayerCharacterController player)
    {
        this.player = player;
        Debug.Log("Collision detected");
        itemMesh.enabled = false;
        StartCoroutine(invincible());
    }
    
    private IEnumerator invincible()
    {
        Debug.Log("Invicible triggered");
        Health health = player.GetComponent<Health>();
        health.Invincible = true;
        invText.SetActive(true);
        yield return new WaitForSeconds(sec);
        health.Invincible = false;
        invText.SetActive(false);
        Destroy(gameObject);
    }
}
