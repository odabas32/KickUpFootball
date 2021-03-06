﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public static UIControl instance;

    public int boardPadLeft = 2;
    public float UIAnimationSpeed = 1f;

    [Header ("Text ler")]
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textHighscore;

    [Header ("Panel ler")]
    public RectTransform panelScoreBoard;
    public RectTransform panelHome;

    void Awake () {
        instance = this;

    }

    void Start () {
        panelScoreBoard.DOAnchorPos (new Vector2 (0, -75), UIAnimationSpeed);
    }

    void Update () {

    }

    void FixedUpdate () {
        textTime.text = timeControl.instance.time.ToString ();
        textScore.text = scoreManeger.instance.score.ToString ().PadLeft (boardPadLeft, '0');
        textHighscore.text = scoreManeger.instance.highscore.ToString ().PadLeft (boardPadLeft, '0');
    }


    //Butonlar 
    public void btnClickToStart () {
        panelHome.gameObject.SetActive (false);
        gameManager.instance.gameState = gameManager.GameState.Start;
        gameManager.instance.spawnSkill();
        timeControl.instance.startTimeCounter ();
        ballControl.instance.rb2d.simulated = true;
    }
    

}