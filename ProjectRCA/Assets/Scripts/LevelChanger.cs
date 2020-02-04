using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    public int Level = 1;

    void Update()
    {
        if (1 == 3)//Input.GetMouseButtonDown(0))
        {
            if(Level == 1)
            {
                FadeToLevel(2);
                Debug.Log("Lvl1");
            }
            if(Level == 2)
            {
                FadeToLevel(0);
                Debug.Log("Lvl2");
            }
            else
            {
                FadeToLevel(0);
                Debug.Log("Menu");
            }
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
