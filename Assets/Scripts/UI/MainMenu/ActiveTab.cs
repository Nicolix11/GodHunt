using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveTab : MonoBehaviour
{
    [SerializeField] private List<GameObject> tabList;
    [SerializeField] private GameObject activeTab;
    

    public void SelectActiveTab()
    {
        ChangeWindow();
    }

    private void ChangeWindow()
    {
        foreach (GameObject Tab in tabList)
        {
            Tab.gameObject.SetActive(false);
        }

        activeTab.gameObject.SetActive(true);
    }
}
