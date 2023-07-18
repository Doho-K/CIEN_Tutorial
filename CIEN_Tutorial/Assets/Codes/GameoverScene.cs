using System.Collections;
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
        if (gm.health != 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
    // Start is called before the first frame update

}
