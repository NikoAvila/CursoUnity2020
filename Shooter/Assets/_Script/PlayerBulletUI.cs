using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBulletUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public PlayerShooting targetShooting;

    private void Awake() {
        
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        
        _text.text = "BULLETS: "+ targetShooting.bulletsAmmount;
    }


}
