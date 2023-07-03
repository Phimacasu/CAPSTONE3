using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


public class BlessingData : MonoBehaviour
{
    public string sceneName;
    public Sprite blessingIcon;
    public string blessingName;
    [TextArea(3, 5)]
    public string blessingDescription;

    public GameObject blessingSlotPrefab;
    public Transform blessingSlotParent;

    public BlessingData[] blessingData; // Array of blessing data

    private void Start()
    {
        CreateBlessingSlots();
    }

    private void CreateBlessingSlots()
    {
        for (int i = 0; i < blessingData.Length; i++)
        {
            GameObject blessingSlot = Instantiate(blessingSlotPrefab, blessingSlotParent);
            BlessingSlotUI blessingSlotUI = blessingSlot.GetComponent<BlessingSlotUI>();

            // Set the blessing name, icon, and description
            blessingSlotUI.blessingNameText.text = blessingData[i].blessingName;
            blessingSlotUI.blessingIconImage.sprite = blessingData[i].blessingIcon;
            blessingSlotUI.blessingDescriptionText.text = blessingData[i].blessingDescription;

            // Disable the blessing slot initially
            blessingSlot.SetActive(false);
        }
    }

    public void EnableBlessingSlot(string sceneName)
    {
        int blessingSlotIndex = GetBlessingSlotIndex(sceneName);

        if (blessingSlotIndex != -1)
        {
            GameObject blessingSlot = blessingSlotParent.GetChild(blessingSlotIndex).gameObject;
            blessingSlot.SetActive(true);
        }
    }

    private int GetBlessingSlotIndex(string sceneName)
    {
        for (int i = 0; i < blessingData.Length; i++)
        {
            if (blessingData[i].sceneName == sceneName)
            {
                return i;
            }
        }

        return -1;
    }
}
