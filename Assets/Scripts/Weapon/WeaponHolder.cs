using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponHolder : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    GameObject weaponToSpawn;

    public Sprite Crosshair;

    GameObject spawnedWeapon;
    [SerializeField]
    GameObject weaponSocketLocation;
    [SerializeField]
    Transform gripSocketLocation;

    public readonly int isReloadingHash = Animator.StringToHash("IsReloading");
    public readonly int isFiringHash = Animator.StringToHash("IsFiring");

    public PlayerController playerController;
    Animator playerAnimator;
    WeaponComponent equippedWeapon;
  public  WeaponInfoUI weaponInfoUI;
    bool firingPressed = false;

    public AudioSource reloadSound;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject spawnedWeapon = Instantiate(weaponToSpawn, weaponSocketLocation.transform.position, weaponSocketLocation.transform.rotation, weaponSocketLocation.transform);
        playerController = GetComponent<PlayerController>();
        playerAnimator = GetComponent<Animator>();
        //equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
        //equippedWeapon.Initalize(this);
        //PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);
        //gripSocketLocation = equippedWeapon.gripLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (!equippedWeapon) return;
        if (playerController.isAiming)
        {
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, gripSocketLocation.transform.position);
        }
    }
    public void OnReload(InputValue value)
    {
        if (!equippedWeapon) return;
        playerController.isReloading = value.isPressed;
        StartReloading();
     


    }
    public void StartReloading()
    {
        if (!equippedWeapon) return;
        if (playerController.isFiring)
        {
            StopReloading();
        }
        if (equippedWeapon.weaponStats.totalBullets <= 0)
        {
            return;
        }

        equippedWeapon.StartReloading();
        playerController.isReloading = true;
        playerAnimator.SetBool(isReloadingHash, true);
        reloadSound.Play();
        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }
    public void StopReloading()
    {
        if (playerAnimator.GetBool(isReloadingHash)) return;

        playerController.isReloading = false;
        playerAnimator.SetBool(isReloadingHash, false);
        equippedWeapon.StopReloading();


        CancelInvoke(nameof(StopReloading));
    }
    public void OnFire(InputValue value)
    {
        if (!equippedWeapon) return;
        firingPressed = value.isPressed;
        if (firingPressed)
        {
            StartFiring();
        }
        else
            StopFiring();
    }
    void StartFiring()
    {
        if (equippedWeapon.weaponStats.bulletsInClip > 0)
        {
            //playerAnimator.SetBool(isReloadingHash, true);
            playerController.isFiring = true;
            equippedWeapon.StartFiringWeapon();
        }
        else
            StartReloading();
    }
    void StopFiring()
    {
        playerController.isFiring = false;
        equippedWeapon.StopFiringWeapon();
    }

    public void EquipWeapon(WeaponScriptable weaponScriptable)
    {
        if (!weaponScriptable)
            return;

        spawnedWeapon = Instantiate(weaponScriptable.itemPrefab, weaponSocketLocation.transform.position, weaponSocketLocation.transform.rotation, weaponSocketLocation.transform);
        if (!spawnedWeapon)
            return;

        equippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();

        if (!equippedWeapon)
            return;

        equippedWeapon.Initalize(this, weaponScriptable);
        PlayerEvents.InvokeOnWeaponEquipped(equippedWeapon);
        gripSocketLocation = equippedWeapon.gripLocation;

        weaponInfoUI.OnWeaponEquippedEvent(equippedWeapon);
    }

    public void UnEquipWeapon()
    {
        if (!equippedWeapon) return;

        Destroy(equippedWeapon.gameObject);

        equippedWeapon = null;
    }
}
