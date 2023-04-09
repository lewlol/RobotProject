using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Items")]
    public int rawMetal;
    public int refinedMetal;
    public int copper;

    [Header("Texts")]
    public GameObject Inventory;
    public Text rawMetalText;
    public Text refinedMetalText;
    public Text copperText;

    bool invActive;

    private void Update()
    {
        if(Input.GetButtonDown("Inventory"))
            OpenCloseInventory();
    }
    public void OpenCloseInventory()
    {
        invActive = !invActive;
        Inventory.SetActive(invActive);

        SetTexts();
    }

    public void SetTexts()
    {
        rawMetalText.text = rawMetal.ToString();
        refinedMetalText.text = refinedMetal.ToString();
        copperText.text = copper.ToString();
    }
}
