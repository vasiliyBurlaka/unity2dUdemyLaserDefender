using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    Text healthTextComponent;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthTextComponent = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthTextComponent.text = player.GetHealth().ToString();
    }
}
