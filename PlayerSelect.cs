using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    public bool enableSelectCharacter;
    public enum Player {Penguin, Frog, PinkMan };
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriterenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;





    void Start()
    {
        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)//switch que cambia el render y el animator segun el personaje que tengamos
            {
                case Player.Penguin:
                    spriterenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case Player.Frog:
                    spriterenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                case Player.PinkMan:
                    spriterenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playersController[2];
                    break;
                default:
                    break;
            }
        }
    }
    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))//switch que cambia el render y el animator segun el personaje que tengamos
        {
            case "penguin":
                spriterenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];


                break;
            case "frog":
                spriterenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];


                break;
            case "pinkman":
                spriterenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];


                break;
            default:
                break;
        }


    }


}
