using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    TMP_Text ammoText;
    static short currentAmmo = 250;
    static byte ammo = 30;

    public static void Fire()
    {
        if (ammo > 1)
        {
            ammo--;
        }
        else
        {
            Reload();
        }
    }

    private static void Reload()
    {
        ammo = 30;
        currentAmmo -= ammo;
    }

    public static void IncreaseCurrentAmmo(byte amount)
    {
        currentAmmo += amount;
    }
    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo : " + ammo + "/" + currentAmmo;
    }
}
