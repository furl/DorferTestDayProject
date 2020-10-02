using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

    int levelNumber = 1;
    int likesNumber = 0;
    int percentFilled = 0;

    public TMP_Text levelNumberText;
    public TMP_Text likesNumberText;


    public GameObject likesPanel;
    public GameObject tapToPlayPanel;
    public GameObject percentagePanel;
    public GameObject levelNumberPanel;
    public GameObject restartPanel;
    public GameObject nextPanel;
    

    public GameObject paintController;

    enum GameState {
        levelStart, playing, endScreen
    }

    GameState gameState = GameState.levelStart;

    private void Awake() {
        likesPanel.SetActive(false);
        tapToPlayPanel.SetActive(true);
        percentagePanel.SetActive(false);
        levelNumberPanel.SetActive(false);
        restartPanel.SetActive(false);
        nextPanel.SetActive(false);
        
        paintController.SetActive(false);

    }

    void Start() {
        
    }

    void Update() {
        levelNumberText.text = "Level " + levelNumber.ToString();
        likesNumberText.text = likesNumber.ToString();

    }

    public void StartGame() {
        tapToPlayPanel.SetActive(false);
        percentagePanel.SetActive(true);
        levelNumberPanel.SetActive(true);
        restartPanel.SetActive(true);
        likesPanel.SetActive(true);

        paintController.SetActive(true);

        gameState = GameState.playing;
    }

}
