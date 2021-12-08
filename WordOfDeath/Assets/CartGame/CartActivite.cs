using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CardGame
{
   
    public class CartActivite : MonoBehaviour
    {
        [SerializeField] private string[] category;
        [SerializeField] private GameObject categoryPanel;
        [SerializeField] private Text categoryText;
        private List<int> categoryCount;
        private string currentCategory;
        private int indexword;
        private int indexCategory;

        void Start()
        {
            categoryCount = new List<int>();
            WordsBlend(4);// rakamı disaridan al
            ChangeCategory();
        }
        private void Update()
        {
            if (GameObject.FindGameObjectWithTag(currentCategory) == null)// update disinda calistir mesela cortine de 
            {
                ChangeCategory();
            }
        }
        public void FindingCard(string cardName)
        {
            categoryPanel.SetActive(false);
            GameObject card = GameObject.Find(cardName);//karti bulabilmemiz icin
            if (card != null)
            {
                if (card.gameObject.tag == currentCategory)
                {
                    Destroy(card);

                    // card.transform.GetChild(0).gameObject.SetActive(false);
                    // puan
                }
                else
                {
                    // yanlış kart animasyonu - puan
                }
            }
        }
        public void WordsBlend(int countword)
        {
            // bir listeye belirli aralıkdaki rakamları karıştırarak atıyor
            // sonra biz o listeden rakamları sırayla çekecegiz 
            while (categoryCount.Count != countword)
            {
                indexword = Random.Range(0, countword+1);
                if (!categoryCount.Contains(indexword))
                {
                    categoryCount.Add(indexword);
                }
            }
        }

        void ChangeCategory()
        {
            if (indexCategory >= categoryCount.Count)
            {
                return;
            }
            categoryPanel.SetActive(true);
            currentCategory = category[categoryCount[indexCategory]];
            categoryText.text = currentCategory;
            indexCategory++;
        }
       
      
    }
}

