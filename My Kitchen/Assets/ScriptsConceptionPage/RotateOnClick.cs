using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 2500f;
    public string targetTag = "Destroyable";  // Le tag des objets qui doivent tourner
    public float holdThreshold = 0.5f;        // Temps nécessaire pour considérer un clic prolongé
    private float holdTime = 0f;
    private bool isDragging = false;
    private GameObject selectedObject;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Gestion des clics et rotation
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag(targetTag))
                {
                    selectedObject = clickedObject;
                    RotateObject(clickedObject);
                    holdTime = 0f;
                    isDragging = false;
                }
            }
        }

        // Gestion du clic prolongé pour déplacer l'objet
        if (Input.GetMouseButton(0) && selectedObject != null)
        {
            holdTime += Time.deltaTime;

            if (holdTime > holdThreshold)
            {
                isDragging = true;
            }

            if (isDragging)
            {
                MoveObject(selectedObject);
            }
        }

        // Réinitialisation à la relâche du bouton
        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            selectedObject = null;
            isDragging = false;
            holdTime = 0f;
        }
    }

    void RotateObject(GameObject obj)
    {
        obj.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void MoveObject(GameObject obj)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            obj.transform.position = new Vector3(hit.point.x, obj.transform.position.y, hit.point.z);
        }
    }
}
