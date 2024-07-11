using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int pontos, teclaAtual;
    float relogio;
    KeyCode[] teclas;

    private void Start()
    {
        GerarSetas();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ChecarTecla(KeyCode.DownArrow);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ChecarTecla(KeyCode.LeftArrow);

        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ChecarTecla(KeyCode.UpArrow);

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ChecarTecla(KeyCode.RightArrow);

        }
        ContagemRegressiva();
    }

    void ContagemRegressiva()
    {
        relogio -= Time.deltaTime;

        //UIManagaer.instance.AtualizarTextos(pontos,relogio);

        if (relogio <= 0)
        {
            pontos -= teclas.Length - teclaAtual;
            GerarSetas();
        }
    }
    void GerarSetas()
    {
        teclaAtual = 0;
        teclas = new KeyCode[Random.Range(5, 15)];
        for (int i = 0; i < teclas.Length; i++)
        {
            teclas[i] = (KeyCode)Random.Range(273, 276);
        }
        relogio = teclas.Length / 2;
        //UIManager.instance.AtualizarSetas(teclas);
    }

    void ChecarTecla(KeyCode teclaPressionada)
    {
        if (teclaPressionada == teclas[teclaAtual])
        {
            pontos++;
            //UIManager.instance.AtualizarSeta(teclaAtual,true);
        }
        else
        {
            pontos--;
            relogio--;
            //UIManager.instance.AtualizarSeta(teclaAtual,false);
        }
        //UIManager.instance.AtualizarSeta(pontos,relogio);
        teclaAtual++;
        if (teclaAtual == 0)
        {

        }
    }
}
