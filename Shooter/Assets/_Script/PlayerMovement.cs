using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Velocidad de Movimiento del personaje en m/s")]
    [Range(0, 1000)]
    public float speed;

    [Tooltip("Velocidad de Movimiento del personaje en grados/s")]

    [Range(0, 360)]
    public float rotationSpeed;

    private Rigidbody _rb;

    private Animator _animator;


  void Start() {
    
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        float space = speed * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal"); // -1 a 1
        float vertical = Input.GetAxis("Vertical"); //  -1 a 1

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(dir.normalized*space);
        //Fuerza de traslacion
        _rb.AddRelativeForce(dir.normalized*space);

        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0, mouseX*angle, 0);
        //Fuerza de rotacion <-> Torque
        _rb.AddRelativeTorque(0, mouseX*angle, 0);


        
        _animator.SetFloat("MoveX", horizontal);
        _animator.SetFloat("MoveY", vertical);

        if(Input.GetKey(KeyCode.LeftShift)){
              _animator.SetFloat("Velocity", _rb.velocity.magnitude);
        }else{
            if(Mathf.Abs(horizontal)<0.01f && Mathf.Abs(vertical)<0.01f){

                _animator.SetFloat("Velocity", 0);
            }else{
                _animator.SetFloat("Velocity", 0.15f);

            }
            

        }

        /*
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) {
            this.transform.Translate(0,0,space);    
        }
          if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) {
            this.transform.Translate(0,0,-space);    
        }
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.Translate(-space,0,0);    
        }
        if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) {
            this.transform.Translate(space,0,0);    
        }
        */

    }



}
