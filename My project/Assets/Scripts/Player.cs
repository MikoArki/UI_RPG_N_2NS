using UnityEngine;

public class Player : Character
{
    [SerializeField] private Weapon selectedWapon;
    public override void Attack(Character toHit)
    {
       // float damage = selectedWapon.GetDamage();
       // toHit.GetHit(damage);
        toHit.GetHit(selectedWapon);
        Debug.Log("Player; - Attack enemy");
    }
    public void Heal(Character toHeal)
    {
        if (Health <= MaxHealth-10)
        {
            Health += 12;
        }
        else
        {
            Health = MaxHealth;
        }
    }
}
