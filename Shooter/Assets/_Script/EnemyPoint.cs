using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    [Tooltip("Cantidad de puntos que se obtienen al derrotar al enemigo")]
    public int pointsAmount = 10;


    private void Awake() {
        
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);

    }

    private void Start() {
        
        EnemyManager.SharedInstance.AddEnemy(this);
    }

    private void DestroyEnemy() 
    {

        //AudioSource aud = ...;
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");

        Invoke("PlayDestruction", 0.2f);

        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);      //remplazo de OnDestroy    

        Destroy(gameObject, 2);
            

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }


    /*private void OnDestroy() {
           
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);   
    }*/

    void PlayDestruction(){

        ParticleSystem explosion = gameObject.GetComponentInChildren<ParticleSystem>();

        explosion.Play();
    }

}
