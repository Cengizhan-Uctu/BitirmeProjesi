using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace CardGame
{

    public class CartActivite : MonoBehaviour
    {
        [SerializeField] private string[] category;
        [SerializeField] private Text[] GameEndPanelButtons;
        [SerializeField] private Text[] levelKeyTexts;
        [SerializeField] private GameObject categoryPanel;
        [SerializeField] private Text categoryText;
        [SerializeField] private Transform backGround;
        [SerializeField] private GameObject GameEndPanel;
    
        private List<int> categoryCount;
        private int indexword;
        private int indexCategory;
        private string currentCategory;
        private string nextLevelKey;
       
       
        void Start()
        {
            indexCategory = 0;
            categoryCount = new List<int>();
            WordsBlend(4);// rakamı disaridan al
            ChangeCategory();
            WriteKey();
           
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
            backGround.GetComponent<GridLayoutGroup>().enabled = false;//random kart atamada sorun yaratiyor eger start da calisirsa hep ayni siralamayi yapiyor
            categoryPanel.SetActive(false);
            GameObject card = GameObject.Find(cardName);//karti bulabilmemiz icin
            if (card != null)
            {
                if (card.gameObject.tag == currentCategory)
                {
                   

                    card.transform.GetChild(0).gameObject.SetActive(false);
                    card.transform.GetChild(1).gameObject.SetActive(true);
                    card.transform.GetChild(1).gameObject.transform.SetParent(backGround);
                    Destroy(card);
                  
                }
                else
                {
                    // yanlış kart animasyonu - puan
                }
            }
        }
        public void buttonChecking(Text objtext)
        {
            if (objtext.text == nextLevelKey)
            {
                SceneManager.LoadScene("CartGame");
            }
        }
        public void WordsBlend(int countword)
        {
            // bir listeye belirli aralıkdaki rakamları karıştırarak atıyor
            // sonra biz o listeden rakamları sırayla çekecegiz 
            while (categoryCount.Count <= countword)
            {
                indexword = Random.Range(0, countword + 1);
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
                GameEnd();
                return;
            }
            categoryPanel.SetActive(true);
            currentCategory = category[categoryCount[indexCategory]];
            categoryText.text = currentCategory;
            indexCategory++;
            //Debug.Log(currentCategory);
        }
        void WriteKey()
        {
            int i = 0;
            nextLevelKey = category[categoryCount[1]];
            foreach (char levelKey in nextLevelKey)
            {
                levelKeyTexts[i].text = levelKey.ToString();
                i++;
            }
        }
        void GameEnd()
        {
            if (!GameEndPanel.activeSelf)
            {
                GameEndPanel.SetActive(true);
                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    GameEndPanelButtons[0].text = nextLevelKey;
                    GameEndPanelButtons[1].text = category[categoryCount[2]];

                    //Debug.Log(nextLevelKey + "random0 buton0");
                    //Debug.Log(category[categoryCount[2]] + "random0 buton1");
                    
                }
                else if(random==1)
                {
                    GameEndPanelButtons[1].text = nextLevelKey;
                    GameEndPanelButtons[0].text = category[categoryCount[2]];
                    
                    //Debug.Log(category[categoryCount[2]]+ "random1 buton0");
                    //Debug.Log(nextLevelKey + "random1 buton1");

                }
            }
        }
      
    }
}

