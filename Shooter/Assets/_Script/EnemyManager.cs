using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    
    public static EnemyManager SharedInstance;

    private List<EnemyPoint> enemies;

    public int EnemyCount{

        get => enemies.Count;
    }

    public UnityEvent onEnemyChanged;

    private void Awake() {
        if(SharedInstance == null){

            SharedInstance = this;
            enemies = new List<EnemyPoint>();
            

        }else{

            Destroy(this);
        }
    }

public void AddEnemy(EnemyPoint enemy){

    enemies.Add(enemy);
    onEnemyChanged.Invoke();
}

public void RemoveEnemy(EnemyPoint enemy){

    enemies.Remove(enemy);
    onEnemyChanged.Invoke();
}

}
