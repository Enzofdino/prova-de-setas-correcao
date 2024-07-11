using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] imagens;
    [SerializeField] TextMeshProUGUI textoDePontuacao, textodorelogio;
    private void Awake()
    {
        Instance = this;
    }

    void AtualizarSetas(KeyCode[] setas)
    {
        for (int i = 0; i < setas.Length; i++)
        {
            if (i >= setas.Length)
            {
                imagens[i].sprite = sprites[0];
            }
            else if (setas[i] == KeyCode.DownArrow)
            {
                imagens[i].sprite = sprites[1];
            }
            else if (setas[i] == KeyCode.UpArrow)
            {
                imagens[i].sprite = sprites[2];
            }
            else if (setas[i] == KeyCode.LeftArrow)
            {
                imagens[i].sprite = sprites[3];
            }
            else if (setas[i] == KeyCode.RightArrow)
            {
                imagens[i].sprite = sprites[4];
            }

            imagens[i].color = Color.white;
        }
    }

    void AtualizarSetas(int setaSelecionada, bool acertou)
    {
        if (acertou)
        {
            imagens[setaSelecionada].color = Color.green;
        }
        else
        {
            imagens[setaSelecionada].color = Color.red;
        }
    }
    void AtualizarTextos(int pontuacao, float relogio)
    {
        textoDePontuacao.text = pontuacao.ToString();
        textodorelogio.text = pontuacao.ToString();
    }
}
