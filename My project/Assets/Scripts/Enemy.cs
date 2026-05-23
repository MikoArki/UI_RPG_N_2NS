using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float minDamage, maxDamage;
    public Sprite enemyImage;
    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage);
        toHit.GetHit(damage);
        Debug.Log("Enemy; - Attack player");
    }

    public void Reset()
    {
        Health = MaxHealth;
    }
}
