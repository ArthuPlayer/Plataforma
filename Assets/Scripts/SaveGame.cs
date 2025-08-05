using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private float pontos;

    // Método para salvar o estado do jogo
    public void SalvarJogo(string fase, float pontos)
    {
        PlayerPrefs.SetInt(fase, 1);
        PlayerPrefs.SetFloat("Pontos", pontos);
        PlayerPrefs.Save();
    }

    // Método para carregar o estado do jogo
    public void CarregarJogo()
    {
        pontos = PlayerPrefs.GetFloat("Pontos");
    }

    //Verifica se tem save
    public bool VerificarSaveGame(string nomeFase)
    {
        bool temSave = PlayerPrefs.HasKey(nomeFase) &&
                            PlayerPrefs.HasKey("Pontos");
        return temSave;
    }

    // Métodos para obter os valores carregados

    public float GetPontos()
    {
        return pontos;
    }

    public void ResetarSave()
    {
        PlayerPrefs.DeleteAll();
        pontos = 0f;
        Debug.Log("Todos os saves foram resetados");
    }
}

