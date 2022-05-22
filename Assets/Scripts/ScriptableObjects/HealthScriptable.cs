using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Items/Health", order = 1)]
public class HealthScriptable : ConsumableScriptable
{

    public override void UseItem(PlayerController playerController)
    {

        if (playerController.healthComponent.CurrentHealth >= playerController.healthComponent.MaxHealth) return;

        playerController.healthComponent.HealPlayer(effect);

        base.UseItem(playerController);
    }
}