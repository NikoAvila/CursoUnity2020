using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerShooting : MonoBehaviour
{


    public GameObject shootingPoint;

    public ParticleSystem fireEffect;

    public AudioSource shootSound;
    private Animator _animator;
    public int bulletsAmmount;

    private void Awake() {
        
        _animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)&& Time.timeScale > 0){

            
            _animator.SetTrigger("Shoot Bullet");
            if(bulletsAmmount > 0){

                Invoke("FireBullet", 0.4f);
            }
           
            
        }
    }


    void FireBullet(){

        GameObject bullet = ObjectPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("Player Bullet");
        bullet.transform.position = shootingPoint.transform.position;
        bullet.transform.rotation = shootingPoint.transform.rotation;
        bullet.SetActive(true);

        fireEffect.Play();
        Instantiate(shootSound, transform.position, transform.rotation);
        GetComponent<AudioSource>().Play();
        //shootSound.Play();

        bulletsAmmount--;
        if (bulletsAmmount < 0){

            bulletsAmmount = 0;
        }

    }
}
