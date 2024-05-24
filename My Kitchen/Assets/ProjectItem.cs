using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Assure-toi que cette ligne est pr�sente

public class ProjectItem : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text priceText;
    public TMP_Text dateText;
    public Button modifyButton;
    public Button deleteButton;
    public TMP_Text dimensionsText;

    private ProjectManager projectManager;

    public void Initialize(ProjectManager manager)
    {
        projectManager = manager;
    }

    public void SetName(string name) { nameText.text = name; }
    public void SetPrice(string price) { priceText.text = price; }
    public void SetDate(string date) { dateText.text = date; }
    public void SetDimensions(string dimensions) { dimensionsText.text = dimensions; }

    void Start()
    {
        if (deleteButton != null)
        {
            Debug.Log("Delete Button is assigned correctly");
            deleteButton.onClick.AddListener(OnDeleteClicked);
        }
        else
        {
            Debug.LogError("Delete Button is not assigned");
        }
    }

    public void OnDeleteClicked()
    {
        Debug.Log("Delete: " + nameText.text);
        if (projectManager != null)
        {
            projectManager.RemoveProjectItem(this);
        }
    }

    public void Hide()
    {
        Debug.Log("Hiding item");
        // D�place l'objet hors de l'�cran
        transform.position = new Vector3(-10000, -10000, 0);
    }
}
