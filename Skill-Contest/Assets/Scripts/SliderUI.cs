using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] bool isHpUi;
    [SerializeField] bool isPainUi;
    Slider slider;

    Victim player;
    Victim Player
    {
        get
        {
            if (player == null)
            {
                foreach (Controll c in FindObjectsOfType<Controll>())
                {
                    if (c.IsPlayer)
                    {
                        player = c.GetComponent<Victim>();
                    }
                }
            }
            return player;
        }
    }
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHpUi)
        {
            slider.value = (float)Player.Hp / 100;
            if (text != null)
                text.text = Player.Hp + "/100";
        }
        else if (isPainUi)
        {
            slider.value = (float)gameManager.Pain / 100;
            if (text != null)
                text.text = gameManager.Pain + "/100";
        }
    }
}
