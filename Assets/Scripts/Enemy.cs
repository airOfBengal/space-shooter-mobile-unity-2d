using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;
    
    public void Damage(float damage){
        health -= damage;
        HurtSequence();
        if(health <= 0){
            DeathSequence();
        }
    }

    public virtual void HurtSequence(){

    }

    public virtual void DeathSequence(){

    }
}
