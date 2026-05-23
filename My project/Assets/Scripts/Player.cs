using UnityEngine;

public class Player : Character
{
    [SerializeField] private Wapon selectedWapon;
    public override void Attack(Character toHit)
    {
       // float damage = selectedWapon.GetDamage();
       // toHit.GetHit(damage);
        toHit.GetHit(selectedWapon);
        Debug.Log("Player; - Attack enemy");
    }
    public void Heal()
    {
        Health += 2;
    }
}
