using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RestartGame : MonoBehaviour, IPointerClickHandler
{
    private bool placement = false;
    public TMP_Text infoText;

    public void OnPointerClick(PointerEventData eventData)
    {
        placement = true;
        Debug.Log("Restart activée");
    }

    void Update()
    {
        
        if (placement)
        {
            Restart();
        }
        placement = false;
    }

    void Restart()
    {
        // Liste des noms d'objets à supprimer
        string[] objectsToDelete = { "Cabinet(Clone)", "Sink_Double(Clone)", "Stove_Electric(Clone)", "Sink_Single(Clone)", "Stove_Electric_Black(Clone)", "Dishwasher_White(Clone)", "Refrigerator(Clone)" };

        // Parcourt tous les objets dans la scène
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            // Si le nom de l'objet est dans la liste, le détruire
            foreach (string name in objectsToDelete)
            {
                if (obj.name == name)
                {
                    Destroy(obj);
                }
            }
        }
        ObjectPlacement.prix = 0;
        AfficherInfo("La facture est de : " + ObjectPlacement.prix +"€");
    }

    public void AfficherInfo(string message)
    {
        infoText.text = message;
    }

}
