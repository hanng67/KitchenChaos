using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;

    private void Update()
    {
        if (!IsServer) return;

        if (!GameManager.Instance.IsGamePlaying()) return;

        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0;
            if (platesSpawnAmount < platesSpawnAmountMax)
            {
                SpawnPlateClientRpc();
            }
        }
    }

    [ClientRpc]
    private void SpawnPlateClientRpc()
    {
        platesSpawnAmount++;

        OnPlateSpawned?.Invoke(this, EventArgs.Empty);
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (platesSpawnAmount > 0)
            {
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                InteractLogicServerRpc();
            }
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }

    [ClientRpc]
    private void InteractLogicClientRpc()
    {
        platesSpawnAmount--;

        OnPlateRemoved?.Invoke(this, EventArgs.Empty);
    }
}
