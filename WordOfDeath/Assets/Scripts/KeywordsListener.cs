using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordsListener : MonoBehaviour
{
    [SerializeField] SpawnManager spawnmanager;
    [SerializeField] ShootGun shotEnemy;
    [SerializeField] private string[] m_Keywords;// kelimeleri inseptor den veriyoruz eger aynı kelime birden çok zombide olursa hata alıyoruz


    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        for (int i = 0; i < m_Keywords.Length; i++)
        {
            spawnmanager.SpawnEnemy(m_Keywords[i]);
        }
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)// yukarıda listede belirttigim kelimelerden biri varsa çalış
    {
       // Debug.Log(args.text.ToString());
        shotEnemy.MarkingEnemy(args.text.ToString());
    }
}
