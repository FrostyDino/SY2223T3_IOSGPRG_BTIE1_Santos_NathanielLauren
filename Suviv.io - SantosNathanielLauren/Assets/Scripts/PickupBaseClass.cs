using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBaseClass : MonoBehaviour
{
    [SerializeField] private Weapon weaponType;
    [SerializeField] private Vector2 ammoMinMax;
    public Inventory inventory;
    public void OnPickUp() 
    {
        inventory.AddAmmo(weaponType, (int)Random.Range(ammoMinMax.x, ammoMinMax.y));
        UIManager.Instance.UpdateUI();
        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory = collision.gameObject.GetComponent<Inventory>())
        {
            OnPickUp();
        }
    }

}
