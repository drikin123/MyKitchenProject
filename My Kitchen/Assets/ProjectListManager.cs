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
    public GameObject projectItemPrefab;  // Assure-toi d'avoir un prefab pour les éléments de projet
    public Transform contentPanel;        // Référence au Content Panel

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

        // Vérifier que les champs ne sont pas vides
        if (!string.IsNullOrEmpty(projectName) && !string.IsNullOrEmpty(dimensions))
        {
            Debug.Log("Creating new project item");
            // Créer un nouvel élément de projet
            GameObject newItem = Instantiate(projectItemPrefab, contentPanel);

            // Assigner les valeurs aux champs de texte du nouvel élément
            ProjectItem projectItem = newItem.GetComponent<ProjectItem>();

            if (projectItem != null)
            {
                projectItem.Initialize(this);  // Passer la référence de ProjectManager
                projectItem.SetName(projectName);
                projectItem.SetDimensions(dimensions);
                projectItem.SetDate(DateTime.Now.ToString("dd/MM/yyyy"));
                projectItem.SetPrice("0.00");

                projectItems.Add(projectItem);  // Ajouter à la liste des éléments de projet
                Debug.Log("Project item created and added to list");
            }

            // Réinitialiser les champs d'entrée
            projectNameInputField.text = "";
            dimensionsInputField.text = "";
        }
        else
        {
            Debug.LogWarning("Les champs du projet et des dimensions doivent être renseignés.");
        }
    }

    public void RemoveProjectItem(ProjectItem item)
    {
        Debug.Log("Hiding project item");
        item.Hide();  // Appeler la méthode Hide pour déplacer l'objet hors de l'écran
    }
}
