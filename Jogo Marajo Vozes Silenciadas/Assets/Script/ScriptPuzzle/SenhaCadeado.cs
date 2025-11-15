using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SenhaCadeado : MonoBehaviour
{
   
    [Header("Referências UI")]
    public TMP_InputField inputField;
    public Text feedbackText;

    [Header("Configuração da Senha")]
    public string senhaCorreta = "XIV"; // senha secreta em números romanos

    void Start()
    {
        feedbackText.text = "Digite a senha em números romanos:";
    }

    public void VerificarSenha()
    {
        string tentativa = inputField.text.ToUpper().Trim();

        if (tentativa == senhaCorreta)
        {
            feedbackText.text = "Correto! A porta se abriu!";
          
        }
        else
        {
            feedbackText.text = "Errado! Tente novamente.";
        }
    }
}