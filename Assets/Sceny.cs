using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceny : MonoBehaviour
{
    [SerializeField] private AudioSource manuSoundEffect;

    private void Awake()
    {
        Cursor.visible = true;
        manuSoundEffect.Play();
    }
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
