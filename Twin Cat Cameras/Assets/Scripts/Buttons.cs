using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour 
{
    private int _levels;
    [SerializeField] private bool _mainMenu = false;

    GameObject _controls;
    GameObject _menu;

    private void Start()
    {
        _levels = SceneManager.sceneCountInBuildSettings-1;
        if (_mainMenu)
        {
            _controls = GameObject.FindGameObjectWithTag("controls");
            _controls.SetActive(false);
            _menu = GameObject.FindGameObjectWithTag("Menu");
        }
    }


    public void MainMenu(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void PlayRandomScene()
    {
        int sceneID = Random.Range(1, _levels);
        SceneManager.LoadScene(sceneID);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        _controls.SetActive(true);
        _menu.SetActive(false);
    }

    public void Back()
    {
        _controls.SetActive(false);
        _menu.SetActive(true);
    }




}
