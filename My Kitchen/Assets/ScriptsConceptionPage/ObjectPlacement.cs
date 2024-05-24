using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using System;

public class ObjectPlacement : MonoBehaviour, IPointerClickHandler
{
    // Liste des objets à placer
    public List<GameObject> objectsToPlace = new List<GameObject>();

    public TMP_Text infoText;

    public TMP_Text infoElement;

    public static int prix = 0;
    private string element = "";

    // Indice de l'objet actuellement sélectionné
    private int currentObjectIndex = 0;

    private bool placement = false;

    private float longClickDuration = 1.0f;  // La durée d'un clic long (en secondes)
    private float clickTime = 0f;            // Le temps où le bouton de la souris a été enfoncé
    private bool isLongClick = false;        // Indicateur de clic long
    private float lastChangeTime = 0f;       // Le dernier moment où l'objet à placer a été changé
    private float changeInterval = 0.5f;     // Intervalle de temps pour changer l'objet (en secondes)

    public void OnPointerClick(PointerEventData eventData)
    {
        placement = true;
    }

    void Update()
    {
        // Vérifie si l'utilisateur commence à cliquer
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time;
            lastChangeTime = Time.time;
            isLongClick = false;

            if (Input.GetMouseButtonDown(0) && placement)
        {
            // Convertit la position du clic de la souris en coordonnées de la scène
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            prix+=GetPrix(currentObjectIndex);

            // Lance un rayon depuis la position de la souris
            if (Physics.Raycast(ray, out hit))
            {
                // Place l'objet à l'endroit où le rayon a touché un objet de la scène
                Instantiate(objectsToPlace[currentObjectIndex], hit.point, Quaternion.identity);
                placement = false;
                AfficherInfo("La facture est de : " + prix +"€");
            }
        }

        }

        // Vérifie si l'utilisateur maintient le clic
        if (Input.GetMouseButton(0))
        {
            float elapsedTime = Time.time - clickTime;

            if (elapsedTime > longClickDuration)
            {
                isLongClick = true;

                // Change l'objet à placer toutes les secondes
                if (Time.time - lastChangeTime >= changeInterval)
                {
                    currentObjectIndex = (currentObjectIndex + 1) % objectsToPlace.Count;
                    element = GetInfoElement(currentObjectIndex);
                    lastChangeTime = Time.time;
                }
            }
        }

    }

    private int GetPrix(int index)
    {
        switch (index)
        {
            case 0:
                return 250;
            case 1:
                return 150;
            case 2:
                return 399;
            case 3:
                return 100;
            case 4:
                return 425;
            case 5:
                return 180;
            default:
                return 349;
        }
    }

    private String GetInfoElement(int index)
    {
        switch (index)
        {
            case 0:
            infoElement.text = "Cabinet";
                return "Cabinet";
            case 1:
            infoElement.text = "Evier Double";
                return "Evier Double";
            case 2:
            infoElement.text = "Four Rouge";
                return "Four Rouge";
            case 3:
            infoElement.text = "Evier";
                return "Evier";
            case 4:
            infoElement.text = "Four Noir";
                return "Four Noir";
            case 5:
            infoElement.text = "Lave Vaisselle";
                return "Lave Vaisselle";
            default:
            infoElement.text = "Frigo";
                return "Frigo";
        }
    }

    public void AfficherInfo(string message)
    {
        infoText.text = message;
    }

}
