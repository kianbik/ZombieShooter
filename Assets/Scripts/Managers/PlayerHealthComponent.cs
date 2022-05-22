using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{
    public PauseMenuScript pauseMenu;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        PlayerEvents.Invoke_OnHealthInitialized(this);
    }
    public override void Destroy()
    {
        pauseMenu.GameOver();
    }
}
