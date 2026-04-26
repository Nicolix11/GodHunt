using System.Collections.Generic;
using UnityEngine;

public class ActiveTab : MonoBehaviour
{
    [SerializeField] private List<GameObject> tabList;
    [SerializeField] private GameObject activeTab;


    public void SelectActiveTab()
    {
        foreach (GameObject Tab in tabList)
        {
            Tab.gameObject.SetActive(false);
        }
        
        activeTab.gameObject.SetActive(true);
    }
}
