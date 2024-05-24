using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ProjectManager : MonoBehaviour
{
    public TMP_InputField projectNameInputField;
    public TMP_InputField dimensionsInputField;
    public Button createButton;
    public GameObject projectItemPrefab;  // Assure-toi d'avoir un prefab pour les �l�ments de projet
    public Transform contentPanel;        // R�f�rence au Content Panel

    private List<ProjectItem> projectItems = new List<ProjectItem>();

    void Start()
    {
        // Ajouter un listener au bouton
        createButton.onClick.AddListener(OnCreateButtonClicked);
        Debug.Log("ProjectManager Start");
    }

    private void OnCreateButtonClicked()
    {
        string projectName = projectNameInputField.text;
        string dimensions = dimensionsInputField.text;

        // V�rifier que les champs ne sont pas vides
        if (!string.IsNullOrEmpty(projectName) && !string.IsNullOrEmpty(dimensions))
        {
            Debug.Log("Creating new project item");
            // Cr�er un nouvel �l�ment de projet
            GameObject newItem = Instantiate(projectItemPrefab, contentPanel);

            // Assigner les valeurs aux champs de texte du nouvel �l�ment
            ProjectItem projectItem = newItem.GetComponent<ProjectItem>();

            if (projectItem != null)
            {
                projectItem.Initialize(this);  // Passer la r�f�rence de ProjectManager
                projectItem.SetName(projectName);
                projectItem.SetDimensions(dimensions);
                projectItem.SetDate(DateTime.Now.ToString("dd/MM/yyyy"));
                projectItem.SetPrice("0.00");

                projectItems.Add(projectItem);  // Ajouter � la liste des �l�ments de projet
                Debug.Log("Project item created and added to list");
            }

            // R�initialiser les champs d'entr�e
            projectNameInputField.text = "";
            dimensionsInputField.text = "";
        }
        else
        {
            Debug.LogWarning("Les champs du projet et des dimensions doivent �tre renseign�s.");
        }
    }

    public void RemoveProjectItem(ProjectItem item)
    {
        Debug.Log("Hiding project item");
        item.Hide();  // Appeler la m�thode Hide pour d�placer l'objet hors de l'�cran
    }
}
