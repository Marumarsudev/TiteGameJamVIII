using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class DayNightController : MonoBehaviour
{

    public TextMeshProUGUI daymessage;
    public int daycount = 1;

    public PlayerController player;

    public TextMeshProUGUI health;
    public TextMeshProUGUI food;
    public TextMeshProUGUI energy;
    public TextMeshProUGUI water;

    public Light sunLight;

    public Transform boat;

    public int surviveForDays = 2;

    private AudioSource audioSource;

    public AudioClip speech;

    private bool boatLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DayNightCycle();
    }

    private void DayNightCycle()
    {
        if (daycount == surviveForDays && !player.isDead && !boatLeft)
        {
            boatLeft = true;
            boat.transform.DOMove(new Vector2(-3.1f, -19f), 15f).OnComplete(() => {audioSource.PlayOneShot(speech);});
        }
        daymessage.text = "Day : " + daycount.ToString();
        DOTween.To(() => sunLight.color, x => sunLight.color = x, new Color(0.6f, 0.4f, 0.3f), 15f).OnStart(() => {daymessage.text = "Dusk : " + daycount.ToString();}).SetDelay(30f)
        .OnComplete(() => {DOTween.To(() => sunLight.color, x => sunLight.color = x, new Color(0.2f, 0.2f, 0.25f), 15f).OnStart(() => {daymessage.text = "Night : " + daycount.ToString();})
        .OnComplete(() => {DOTween.To(() => sunLight.color, x => sunLight.color = x, new Color(1f, 1f, 1f), 15f).OnStart(() => {daymessage.text = "Dawn : " + daycount.ToString();}).SetDelay(30f)
        .OnComplete(() => {daycount++; DayNightCycle();});
        });});
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStatusUpdate();
    }

    private void PlayerStatusUpdate()
    {
        UpdateHealthGUI();
        UpdateEnergyGUI();
        UpdateFoodGUI();
        UpdateWaterGUI();
    }

    private void UpdateHealthGUI()
    {
        string newtext = "";
        int newvalue = player.health;

        for (int i = 0; i < newvalue / 2; i++)
        {
            newtext += "<sprite=0>";
        }

        if(newvalue % 2 != 0)
        {
            newtext += "<sprite=1>";
        }

        health.text = newtext;
    }
    private void UpdateFoodGUI()
    {
        string newtext = "";
        int newvalue = player.hunger;
        for (int i = 0; i < newvalue / 2; i++)
        {
            newtext += "<sprite=2>";
        }

        if(newvalue % 2 != 0)
        {
            newtext += "<sprite=3>";
        }

        food.text = newtext;
    }
    private void UpdateEnergyGUI()
    {
        string newtext = "";
        int newvalue = player.energy;
        for (int i = 0; i < newvalue / 2; i++)
        {
            newtext += "<sprite=4>";
        }

        if(newvalue % 2 != 0)
        {
            newtext += "<sprite=5>";
        }

        energy.text = newtext;
    }
    private void UpdateWaterGUI()
    {
        string newtext = "";
        int newvalue = player.water;
        for (int i = 0; i < newvalue / 2; i++)
        {
            newtext += "<sprite=6>";
        }

        if(newvalue % 2 != 0)
        {
            newtext += "<sprite=7>";
        }

        water.text = newtext;
    }
}
