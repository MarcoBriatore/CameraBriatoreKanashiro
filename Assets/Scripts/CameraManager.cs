using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!cameras[0].activeSelf && Input.GetKeyDown(KeyCode.F1))
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            audioManager.Play("Ready");
        }
        else if (!cameras[1].activeSelf && Input.GetKeyDown(KeyCode.F2))
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
            cameras[2].SetActive(false);
            audioManager.Play("Go");
        }
        else if (!cameras[2].activeSelf && Input.GetKeyDown(KeyCode.F3))
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            cameras[2].SetActive(true);
            audioManager.Play("Complete");
        }
    }
}
