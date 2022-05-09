using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Mentorama.Module5
{
    public class SeletorDeEnigma : MonoBehaviour
    {
        [SerializeField] ListaDeEnigmas lista;
        [SerializeField] Text perguntaTexto;
        [SerializeField] Text botao1Texto;
        [SerializeField] Text botao2Texto;
        [SerializeField] Text botao3Texto;
        [SerializeField] Text botao4Texto;
        [SerializeField] Text scoreTexto;
        [SerializeField] Text recordTexto;
        int index;
        int score = 0;
        int record = 0;

        List<string> listaRespostasPossiveis = new List<string>();

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            scoreTexto.text = "Score: " + score.ToString();
            record = PlayerPrefs.GetInt("record", 0);
            recordTexto.text = "Record: " + record.ToString();
            index = Random.Range(0, lista.listaDeEnigmas.Count);

            listaRespostasPossiveis.Add(lista.listaDeEnigmas[index].respostaCorreta);
            listaRespostasPossiveis.Add(lista.listaDeEnigmas[index].respostaErrada1);
            listaRespostasPossiveis.Add(lista.listaDeEnigmas[index].respostaErrada2);
            listaRespostasPossiveis.Add(lista.listaDeEnigmas[index].respostaErrada3);

            int indexRespostas = Random.Range(0, listaRespostasPossiveis.Count);

            perguntaTexto.text = lista.listaDeEnigmas[index].pergunta;

            botao1Texto.text = listaRespostasPossiveis[indexRespostas];
            listaRespostasPossiveis.Remove(listaRespostasPossiveis[indexRespostas]);
            indexRespostas = Random.Range(0, listaRespostasPossiveis.Count);

            botao2Texto.text = listaRespostasPossiveis[indexRespostas];
            listaRespostasPossiveis.Remove(listaRespostasPossiveis[indexRespostas]);
            indexRespostas = Random.Range(0, listaRespostasPossiveis.Count);

            botao3Texto.text = listaRespostasPossiveis[indexRespostas];
            listaRespostasPossiveis.Remove(listaRespostasPossiveis[indexRespostas]);
            indexRespostas = Random.Range(0, listaRespostasPossiveis.Count);

            botao4Texto.text = listaRespostasPossiveis[indexRespostas];
            listaRespostasPossiveis.Remove(listaRespostasPossiveis[indexRespostas]);
            indexRespostas = Random.Range(0, listaRespostasPossiveis.Count);
        }

        public void OnClick(Text TextoBotao)
        {
            if (TextoBotao.text == lista.listaDeEnigmas[index].respostaCorreta)
            {
                Debug.Log("Resposta Correta");
                lista.listaDeEnigmas.Remove(lista.listaDeEnigmas[index]);
                score = score + 5;
                scoreTexto.text = "Score: "+score.ToString();

                if(score > record)
                {
                    record = score;
                    recordTexto.text = "Record: " + record.ToString();
                    PlayerPrefs.SetInt("record", record);
                }   

                Initialize();
            }
            else
            {
                Debug.Log("Resposta Errada");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
