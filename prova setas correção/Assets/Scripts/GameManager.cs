using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int pontos, teclaAtual; //variaveis inteiras chamadas pontos e teclaatual
    float relogio; //variavel float chamada relogio
    KeyCode[] teclas; //array keycode[] chamada teclas

    private void Start() //metodo privado start 
    {
        GerarSetas();//chama o metodo gerarsetas
    }
    private void Update() //metodo privado update 
    {
        if (Input.GetKeyUp(KeyCode.DownArrow)) //se o input.getkeyup(Teclapressinada) for o down arrow de keycode
        {
            ChecarTecla(KeyCode.DownArrow); //chama o metodo checartecla para parametro sendo array keycode downarrow
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))//se o input.getkeyup(Teclapressinada) for o left arrow de keycode
        {
            ChecarTecla(KeyCode.LeftArrow);//chama o metodo checartecla para parametro sendo array keycode leftarrow

        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))//se o input.getkeyup(Teclapressinada) for o up arrow de keycode
        {
            ChecarTecla(KeyCode.UpArrow);//chama o metodo checartecla para parametro sendo array keycode uparrow

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))//se o input.getkeyup(Teclapressinada) for o right arrow de keycode
        {
            ChecarTecla(KeyCode.RightArrow);//chama o metodo checartecla para parametro sendo array keycoderightarrow

        }
        ContagemRegressiva(); //chama o metodo contagemregressiva dentro ainda do metodo update
    }

    void ContagemRegressiva() //metodo contagemregressiva
    {
        relogio -= Time.deltaTime; // diminui o igual do relogio por time.deltatime

        //UIManagaer.instance.AtualizarTextos(pontos,relogio); //atualizando os textos pontos e relogio de UIManager

        if (relogio <= 0) //se relogio menor ou igual a 0
        {
            pontos -= teclas.Length - teclaAtual; //diminui a diferença do comprimento das teclas para teclaatual de pontos
            GerarSetas(); // chama o metodo gerarsetas
        }
    }
    void GerarSetas() //metodo gerarsetas
    {
        teclaAtual = 0; //teclaatual = 0
        teclas = new KeyCode[Random.Range(5, 15)]; //teclas inicia teclas com valores random.range aleatorios entre 5 e 15
        for (int i = 0; i < teclas.Length; i++) //loop para preencher o array de teclas 
        {
            teclas[i] = (KeyCode)Random.Range(273, 276); // preenche o array de teclas com valores com random.range aleatorios entre 273 e 276
            //codigo para as setas direcionadas
        }
        relogio = teclas.Length / 2; //define o relogio com a metade do valor do comprimento de teclas dividido por 2 
        //UIManager.instance.AtualizarSetas(teclas); //atualiza as teclas do metodo atualizarsetas da instancia de uimanager
    }

    void ChecarTecla(KeyCode teclaPressionada) //metodo chamado checartecla com parametro array de keycode chamado teclapressionada
    {
        if (teclaPressionada == teclas[teclaAtual]) //se a teclapressionada for igual a array de teclas para parametro teclaatual
        {
            pontos++; //aumenta (incrementa) pontos
            //UIManager.instance.AtualizarSeta(teclaAtual,true); //atualiza a teclaatual como true do metodo atualizarseta
            //da instancia do UIManager
        }
        else //senao
        {
            pontos--; //diminui ou decrementa os pontos
            relogio--;//diminui ou decrementa o relogio
            //UIManager.instance.AtualizarSeta(teclaAtual,false); //atualiza a teclaatual como false do metodo atualizarseta
            //da instancia do UIManager
        }
        //UIManager.instance.AtualizarSeta(pontos,relogio); //atualiza o parametro pontos e relogio do metodo atualizarseta
        //da instancia de uimanager
        teclaAtual++;//aumenta a teclaatual
        if (teclaAtual == 0) //se a teclaatual for igual ao comprimento do array de teclas
        {
            GerarSetas (); //chama o metodo gerarsetas
        }
    }
}
