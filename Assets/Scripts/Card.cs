using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        

    frontImage.sprite = Resources.Load<Sprite>($"img{idx}");
    }
    

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if(GameManager.I.firstCard == null )
        {
            GameManager.I.firstCard = this;
        }
        else
        {
            GameManager.I.secondCard = this;
            GameManager.I.Matched();
        }

    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke",0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", .5f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }



}
