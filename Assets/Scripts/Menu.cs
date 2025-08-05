using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private SaveGame saveGame;
    [SerializeField] private GameObject continuaButton;


    private void Awake()
    {
        if (saveGame.VerificarSaveGame("Fase1"))
        {
            continuaButton.GetComponent<Button>().interactable = true;
        }
    }

    public void MudarFase(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    public void SalvarFase()
    {
        if (saveGame != null)
        {
            saveGame.SalvarJogo(SceneManager.GetActiveScene().name, 0f);
            Debug.Log("Fase salva com sucesso.");
        }
        else
        {
            Debug.LogError("SaveGame não está atribuído.");
        }
    }

    public void SalvarCheckpoint()
    {
        if (saveGame != null)
        {
            saveGame.SalvarJogo(SceneManager.GetActiveScene().name, 54.1f);
            Debug.Log("Fase salva com sucesso, no checkpoint.");
        }
        else
        {
            Debug.LogError("SaveGame não está atribuído.");
        }
    }

    public void NovoJogo()
    {
        if (saveGame != null)
        {
            saveGame.ResetarSave();
        }
    }

}
