using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public AudioClip match;
    //public AudioSource audioSource;

    public GameObject endTxt;
    public Text timeTxt;
    float time = 0;

    public int cardCount = 0;

    // public GameObject card;

    public static GameManager I;

    //public GameObject firstCard;
    //public GameObject secondCard;

    public Card firstCard;
    public Card secondCard;


    //public GameObject endTxt;

    void Awake()
    {
        if (I == null)
        {
            I = this;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        //for (int i = 0; i < 16; i++)
        //{
        //    rtans = rtans.OrderBy(item => Random.Range(-1f, 1f)).ToArray();

        //    GameObject newCard = Instantiate(card);
        //    newCard.transform.parent = GameObject.Find("cards").transform;
        //    float x = (i / 4) * 1.4f - 2.1f;
        //    float y = (i % 4) * 1.4f - 3f;
        //    newCard.transform.position = new Vector3(x, y, 0);

        //    string rtanName = "rtan" + rtans[i].ToString();
        //    newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);

        //}
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        //  30초가 지나면 게임 끝내기

        if (time > 30f)
        {
            Time.timeScale = 0f;
            endTxt.SetActive(true);

        }
    }


    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            //     audioSource.PlayOneShot(match);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }


            //   int cardsLeft = GameObject.Find("cards").transform.childCount;

            //if (cardsLeft == 2)
            //{

            //    Time.timeScale = 0f;
            //    //      endTxt.SetActive(true);
            //    //  Invoke("GameEnd", 1f);
            //}


        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();

        }

        firstCard = null;
        secondCard = null;
    }



    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
       //     audioSource.PlayOneShot(match);
            //firstCard.GetComponent<card>().destroyCard();
            //secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;

            if (cardsLeft == 2)
            {

                Time.timeScale = 0f;
          //      endTxt.SetActive(true);
                //  Invoke("GameEnd", 1f);
            }


        }
        else
        {
            //firstCard.GetComponent<card>().closeCard();
            //secondCard.GetComponent<card>().closeCard();

        }

        firstCard = null;
        secondCard = null;

    }

    void GameEnd()
    {
        Time.timeScale = 0f;
   //   endTxt.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    //public void checkMatched()
    //{
    //    string firstCardImage = firstCard. transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
    //    string secondCardImage = secondCard . transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

    //    if (firstCardImage == secondCardImage)
    //    {
    //        firstCard.GetComponent<card>().destroyCard();
    //        secondCard.GetComponent<card>().destroyCard();


    //    }
    //    else
    //    {
    //        firstCard.GetComponent<card>().closeCard();
    //        secondCard.GetComponent<card>().closeCard();

    //    }

    //    firstCard = null;
    //    secondCard = null;


    //}

}
