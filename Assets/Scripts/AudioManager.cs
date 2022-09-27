using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton

    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    #endregion

    [SerializeField]
    private AudioSource rollBall;

    [SerializeField]
    private AudioSource collapsePins;

    [SerializeField]
    private AudioSource menuItemHover;


    public void PlayRollBall()
    {
        rollBall.Play();
    }

    public void PlayCollapsePins()
    {
        collapsePins.Play();
    }

    public void PlayMenuItemHover()
    {
        menuItemHover.Play();
    }
}