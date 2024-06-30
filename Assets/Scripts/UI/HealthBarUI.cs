using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] HpHandler hpHandler;
    [SerializeField] TextMeshProUGUI text;

    private void Update()
    {
        text.text = $"{hpHandler.HP} HP";
    }
}
