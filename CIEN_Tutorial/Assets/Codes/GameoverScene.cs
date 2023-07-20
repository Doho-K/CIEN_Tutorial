﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScene : MonoBehaviour
{
    [SerializeField]private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void GameSceneCtrl()
    {
        if (gm.health != 0&&gm.stage == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(gm.health!=0&&gm.stage == 2)
        {
            SceneManager.LoadScene("NightScene");
        }
        
    }
    // Start is called before the first frame update

}
