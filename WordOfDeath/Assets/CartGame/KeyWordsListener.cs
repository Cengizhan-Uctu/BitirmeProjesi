using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
namespace CardGame
{
    public class KeyWordsListener : MonoBehaviour
    {
        private KeywordRecognizer m_Recognizer;
        [SerializeField] private string[] m_Keywords;
        [SerializeField] CartActivite cartActivite;
        void Start()
        {
           
            m_Recognizer = new KeywordRecognizer(m_Keywords);
            m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
            m_Recognizer.Start();
        }

        private void OnPhraseRecognized(PhraseRecognizedEventArgs args)// yukarıda listede belirttigim kelimelerden biri varsa çalış
        {
            Debug.Log(args.text.ToString());
            cartActivite.FindingCard(args.text.ToString());
            
        }
    }
}

