using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button exitButton;
    public Button settingButton;
    public Button returnButton;
    public Button returnToGame;
    public Button returnToMenu;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingMenu;

    [Header("Text")]
    public Text liveText;
    public Text scoreText;
    public Text sliderText;

    [Header("Slider")]
    public Slider volSlide;

    public void showMainMenu()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void showSetMenu()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void OnSliderValueChange(float value)
    {
        sliderText.text = value.ToString();
    }
    void OnLifeValueChange(int value)
    {
        liveText.text = value.ToString();
    }
    void OnScoreValueChange(int value)
    {
        scoreText.text = value.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(settingButton)
        {
            settingButton.onClick.AddListener(() => showSetMenu());
        }
        if(returnButton)
        {
            returnButton.onClick.AddListener(() => showMainMenu());
        }
        if(startButton)
        {
            startButton.onClick.AddListener(() => startGame());
        }
        if(volSlide && sliderText)
        {
            volSlide.onValueChanged.AddListener((value) => OnSliderValueChange(value));
            sliderText.text = volSlide.value.ToString();
        }
        if(liveText)
        {
            GameManager.instances.onLifeEvent.AddListener((value) => OnLifeValueChange(value));
        }
        if (scoreText)
        {
            GameManager.instances.onScoreEvent.AddListener((value) => OnScoreValueChange(value));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                if(pauseMenu.activeSelf)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }
}
