using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUpgradingUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject greenIcon;
    public void OnPointerEnter(PointerEventData eventData)
    {
        greenIcon.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        greenIcon.SetActive(false);
    }
}
