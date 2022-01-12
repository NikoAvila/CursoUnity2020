using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
   
    public float distance;
    public float angle;

    public LayerMask targetLayers;
    public LayerMask obstacsLayers;

    public Collider detectedTarget;


    private void Update() {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance,targetLayers);
        detectedTarget = null;

        //filtro de distancia
        foreach (Collider collider in colliders)
        {
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            directionToCollider = Vector3.Normalize(directionToCollider);

            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);


        //si el angulo es menor que el de vision
            if(angleToCollider < angle){
                
                //Comprobamos que en la linea de vision de enemigo -> objetivo no haya obstaculos
                if(!Physics.Linecast(transform.position, collider.bounds.center,out RaycastHit hit , obstacsLayers)){
                    
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);

                    detectedTarget = collider;
                    break;
                }
                else{
                
                Debug.DrawLine(transform.position, hit.point, Color.red);
                
                }
            }

        }

        /*for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
           
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.magenta;
        Vector3 rightDir = Quaternion.Euler(0, angle, 0)* transform.forward;
        Gizmos.DrawRay(transform.position, rightDir*distance);

        Vector3 leftDir = Quaternion.Euler(0, -angle, 0)* transform.forward;
        Gizmos.DrawRay(transform.position, leftDir*distance);
    }

}
