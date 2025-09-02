using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float points;
    [SerializeField] private TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0f;
        UpdatePointsText();
    }

    public void AddPoints(float amount)
    {
        points += amount;
        UpdatePointsText();
    }
    private void UpdatePointsText()
    {
        pointsText.text = points.ToString();
    }


}