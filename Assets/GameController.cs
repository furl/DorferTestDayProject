using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PaintIn3D;
using PaintIn3D.Examples;


public class GameController : MonoBehaviour {

    int levelNumber = 1;
    int likesNumber = 0;

    public TMP_Text levelNumberText;
    public TMP_Text likesNumberText;


    public GameObject likesPanel;
    public GameObject tapToPlayPanel;
    public GameObject percentagePanel;
    public GameObject levelNumberPanel;
    public GameObject restartPanel;
    public GameObject nextPanel;
    

    public GameObject paintController;

    float percentFilled = 0;

    public List<P3dChangeCounter> Counters { get { if (counters == null) counters = new List<P3dChangeCounter>(); return counters; } }
    [SerializeField] private List<P3dChangeCounter> counters;


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
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text);
        //Debug.Log(GameObject.FindWithTag("Player").GetComponent<Text>().text);
    }

    void Update() {
        levelNumberText.text = "Level " + levelNumber.ToString();
        likesNumberText.text = likesNumber.ToString();


        var finalCounters = counters.Count > 0 ? counters : null;
        var total = P3dChangeCounter.GetTotal(finalCounters);
        var count = P3dChangeCounter.GetCount(finalCounters);

        count = total - count;
        var percent = P3dHelper.RatioToPercentage(P3dHelper.Divide(count, total), 0);

        //Debug.Log(percent.ToString());

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
