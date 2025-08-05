using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapa : MonoBehaviour
{
    [SerializeField] private SaveGame saveGame;
    [SerializeField] private List<GameObject> fases = new List<GameObject>();

    private void Awake()
    {
        if (saveGame != null)
        {
            saveGame = FindFirstObjectByType<SaveGame>();
        }
    }

    private void Start()
    {
        VerificarFases();
    }

    public void VerificarFases()
    {
        int ultimoSave = 0;

        foreach (GameObject fase in fases)
        {
            if (saveGame.VerificarSaveGame(fase.name))
            {
                AtivarFase(fase);
                ultimoSave++;
            }
        }

        ProximaFase("Fase" + (ultimoSave + 1));
    }

    private void AtivarFase(GameObject faseObj)
    {
        faseObj.GetComponent<Button>().interactable = true;
        faseObj.GetComponent<Image>().color = Color.green;
    }

    private void ProximaFase(string faseNome)
    {
        foreach (GameObject fase in fases)
        {
            if (fase.name == faseNome)
            {
                fase.GetComponent<Button>().interactable = true;
                fase.GetComponent<Image>().color = Color.magenta;
            }
        }
    }
}

