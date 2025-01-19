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
        // D�marre la premi�re mise � jour imm�diate si n�cessaire
        StartCoroutine(UpdateGarbagePositions());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Si 10 secondes se sont �coul�es et qu'aucune mise � jour n'est en cours
        if (timer >= updateInterval && !isUpdateInProgress)
        {
            timer = 0f;
            StartCoroutine(UpdateGarbagePositions());
        }
    }

    // Coroutine qui assigne un transform unique � chaque garbage
    private IEnumerator UpdateGarbagePositions()
    {
        Debug.Log("Moving garbage");
        isUpdateInProgress = true;

        // Cr�er une copie de la liste garbageTransforms pour �viter de modifier la liste pendant l'it�ration
        List<Transform> availableTransforms = new List<Transform>(garbageTransforms);

        // Assigner un transform unique � chaque garbage
        for (int i = 0; i < garbages.Count; i++)
        {
            // Choisir un transform al�atoire parmi les disponibles
            int randomIndex = Random.Range(0, availableTransforms.Count);
            Transform selectedTransform = availableTransforms[randomIndex];

            // D�placer le garbage vers le transform s�lectionn�
            garbages[i].transform.position = selectedTransform.position;

            // Retirer le transform choisi pour �viter les doublons
            availableTransforms.RemoveAt(randomIndex);

            // Attendre une frame pour �viter d'avoir trop de logique d'un coup
            yield return null;
        }

        isUpdateInProgress = false;
    }
}
