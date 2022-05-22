using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableScriptable : ItemScript
{
    public bool isEquipped = false;
    public bool equipped
    {
        get => isEquipped;
        set
        {
            isEquipped = value;
            OnEquipeStatusChange?.Invoke();
        }
    }


    public delegate void EquipeStatusChange();
    public event EquipeStatusChange OnEquipeStatusChange;

    public override void UseItem(PlayerController playerController)
    {
        isEquipped = !isEquipped;
    }

}
