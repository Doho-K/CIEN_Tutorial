﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int stage = 1;
    [SerializeField] private GameObject text;
    public int health = 20;
    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                
            }
            return instance;
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    

    private void Update()
    {
        if(text == null)
        {
            text = GameObject.Find("HealthText");
        }
        text.GetComponent<TextMeshProUGUI>().text = health.ToString();
    }
    // Start is called before the first frame update

}
