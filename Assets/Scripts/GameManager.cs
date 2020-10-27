﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Game Buttons
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;

    private int standClicks = 0;

    // Access to player and dealer's script
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // Public text to access and update - hud
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    // public Text mainText
    public Text standBtnText;

    // Card hiding dealer's 2nd card
    public GameObject hideCard;
    // How much is bet
    private int pot = 0;

    void Start()
    {
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    }

    private void DealClicked()
    {
        // Hide deal hand score at start of deal
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // Update the score displayed
        scoreText.text = "Hand: " + playerScript.handValue;
        dealerScoreText.text = "Hand: " + dealerScript.handValue;
        // Adjust buttons visibility
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "STAND";
        // Set standard pot size
        pot = 40;
        betsText.text = pot.ToString();
        // playerScript.AdjustMoney(-20);
        // cashText.text = playerScript.GetMoney().ToString();
    }

    private void HitClicked()
    {
        // Check that there is still room on the table
        if (playerScript.GetCard() <= 10)
        {
            playerScript.GetCard();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1)  Debug.Log("End function");
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            //dealerScore

        }
    }






}
