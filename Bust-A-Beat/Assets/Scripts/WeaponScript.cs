using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }

    }

    public void Shoot() 
    { 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
