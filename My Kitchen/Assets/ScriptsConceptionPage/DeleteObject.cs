using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteObject : MonoBehaviour, IPointerClickHandler
{
    private bool placement = false;
    public TMP_Text infoText;

    public void OnPointerClick(PointerEventData eventData)
    {
        placement = true;
        Debug.Log("Suppression activée");
    }

    void Update()
    {
        // Vérifier si le bouton gauche de la souris est cliqué
        if (Input.GetMouseButtonDown(0) && placement)
        {
            // Créer un rayon à partir de la position de la souris
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Vérifier si le rayon touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifier si l'objet a le tag "Destroyable"
                if (hit.transform.CompareTag("Destroyable"))
                {
                    GetNom(hit.transform.gameObject.name);
                    // Log pour le débogage
                    Debug.Log("Objet cliqué: " + hit.transform.gameObject.name);
                    // Détruire l'objet
                    Destroy(hit.transform.gameObject);
                    placement = false;
                    AfficherInfo("La facture est de : " + ObjectPlacement.prix +"€");
                }
                else
                {
                    Debug.Log("Objet cliqué n'a pas le tag 'Destroyable': " + hit.transform.gameObject.name);
                }
            }
        }
    }

    private void GetNom(String nom)
    {

        if (nom == "Cabinet(Clone)"){
            ObjectPlacement.prix-=250;
        } else if (nom == "Sink_Double(Clone)"){
            ObjectPlacement.prix-=150;
        } else if (nom == "Stove_Electric(Clone)"){
            ObjectPlacement.prix-=399;
        } else if (nom == "Sink_Single(Clone)"){
            ObjectPlacement.prix-=100;
        } else if (nom == "Stove_Electric_Black(Clone)"){
            ObjectPlacement.prix-=425;
        } else if (nom == "Dishwasher_White(Clone)"){
            ObjectPlacement.prix-=180;
        } else {
            ObjectPlacement.prix-=349;
        }
        
    }

    public void AfficherInfo(string message)
    {
        infoText.text = message;
    }

}
