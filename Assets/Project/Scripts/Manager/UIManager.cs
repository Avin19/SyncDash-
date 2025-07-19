
using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scorePanel;
    [Header("Buttons ")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button pauseBtn;


    void Start()
    {
        DisableAllPanel();
        mainMenuPanel.SetActive(true);
    }
    void OnEnable()
    {
        startBtn.onClick.AddListener(OnStartBtnClicked);
        exitBtn.onClick.AddListener(() => { Application.Quit(); });
        restartBtn.onClick.AddListener(OnRestartBtnClicked);
        mainMenuBtn.onClick.AddListener(OnMainMenuBtnClicked);
        pauseBtn.onClick.AddListener(OnPausebtnClick);
    }

    private void OnPausebtnClick()
    {
        DisableAllPanel();
        GameManager.Instance.SetIsGameRuning(false);
        gameOverPanel.SetActive(true);

    }

    private void OnMainMenuBtnClicked()
    {
        DisableAllPanel();
        mainMenuPanel.SetActive(true);
        GameManager.Instance.SetIsGameRuning(false);
    }

    private void OnRestartBtnClicked()
    {
        DisableAllPanel();
        SceneManager.LoadScene(0);
    }

    private void OnStartBtnClicked()
    {
        DisableAllPanel();
        GameManager.Instance.SetIsGameRuning(true);
        scorePanel.SetActive(true);

    }

    void OnDisable()
    {

    }

    private void DisableAllPanel()
    {
        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(false);

    }
}
