using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    public List<Transform> garbageTransforms;
    public List<GameObject> garbages;

    // Timer pour l'intervalle de 10 secondes
    private float timer = 0f;
    private bool isUpdateInProgress = false;
    public float updateInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Démarre la première mise à jour immédiate si nécessaire
        StartCoroutine(UpdateGarbagePositions());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Si 10 secondes se sont écoulées et qu'aucune mise à jour n'est en cours
        if (timer >= updateInterval && !isUpdateInProgress)
        {
            timer = 0f;
            StartCoroutine(UpdateGarbagePositions());
        }
    }

    // Coroutine qui assigne un transform unique à chaque garbage
    private IEnumerator UpdateGarbagePositions()
    {
        Debug.Log("Moving garbage");
        isUpdateInProgress = true;

        // Créer une copie de la liste garbageTransforms pour éviter de modifier la liste pendant l'itération
        List<Transform> availableTransforms = new List<Transform>(garbageTransforms);

        // Assigner un transform unique à chaque garbage
        for (int i = 0; i < garbages.Count; i++)
        {
            // Choisir un transform aléatoire parmi les disponibles
            int randomIndex = Random.Range(0, availableTransforms.Count);
            Transform selectedTransform = availableTransforms[randomIndex];

            // Déplacer le garbage vers le transform sélectionné
            garbages[i].transform.position = selectedTransform.position;

            // Retirer le transform choisi pour éviter les doublons
            availableTransforms.RemoveAt(randomIndex);

            // Attendre une frame pour éviter d'avoir trop de logique d'un coup
            yield return null;
        }

        isUpdateInProgress = false;
    }
}
