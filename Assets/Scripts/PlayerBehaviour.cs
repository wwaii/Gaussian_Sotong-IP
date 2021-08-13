using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public bool miphaFollow;
    public bool withSeed;
    public Camera playerCamera;
    public GameController gameController;


    public int interactionDistance;
    void Update()
    {
        InteractionRaycast();
        if (gameController.seedCount != 1)
        {
            withSeed = true;
        }
        else
        {
            withSeed = false;
        }
    }

    private void InteractionRaycast()
    {
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);
        int layerMask = 1 << LayerMask.NameToLayer("IntObject");

        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, layerMask))
        {
            Debug.Log(hitInfo.transform.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hitInfo.transform.name);
                if (hitInfo.transform.tag == "Fish")
                {
                    hitInfo.transform.GetComponent<Fish>().GotCaught();
                }

                else if (hitInfo.transform.tag == "Mushrooms")
                {
                    hitInfo.transform.GetComponent<Mushrooms>().Collected();
                }

                else if (hitInfo.transform.tag == "Wood")
                {
                    hitInfo.transform.GetComponent<Wood>().Collected();
                }

                else if (hitInfo.transform.tag == "Potion")
                {
                    hitInfo.transform.GetComponent<Potion>().Collected();
                }

                else if (hitInfo.transform.tag == "Seed")
                {
                    hitInfo.transform.GetComponent<Seed>().Collected();
                }

                else if (hitInfo.transform.tag == "Panel")
                {

                    hitInfo.transform.GetComponent<PipeGameTrigger>().OpenGame();
                }

                else if (hitInfo.transform.tag == "Daruk")
                {
                    if (!gameController.darukMissionStart)
                    {
                        hitInfo.transform.GetComponent<Daruk>().talk();
                        gameController.darukMissionStart = true;
                    }

                    else
                    {
                        if (gameController.woodCount >= 5)
                        {
                            ;
                            hitInfo.transform.GetComponent<Daruk>().talkTwo();
                            gameController.missionDone += 1;
                        }

                        else
                        {
                            hitInfo.transform.GetComponent<Daruk>().talkThree();
                        }

                    }
                }

                else if (hitInfo.transform.tag == "Micheal")
                {

                    if (!gameController.michealMissionStart)
                    {

                        hitInfo.transform.GetComponent<Micheal>().talk();
                        gameController.michealMissionStart = true;
                    }
                    else
                    {
                        if (gameController.fishCount >= 5)
                        {
                            ;
                            hitInfo.transform.GetComponent<Micheal>().talkTwo();
                            gameController.missionDone += 1;
                        }

                        else
                        {
                            hitInfo.transform.GetComponent<Micheal>().talkThree();
                        }

                    }
                }

                else if (hitInfo.transform.tag == "Martin")
                {

                    if (!gameController.martinMissionStart)
                    {

                        hitInfo.transform.GetComponent<Martin>().talk();
                        gameController.martinMissionStart = true;
                    }
                    else
                    {
                        if (gameController.mushroomsCount >= 3)
                        {

                            hitInfo.transform.GetComponent<Martin>().talkTwo();
                            gameController.missionDone += 1;
                        }

                        else
                        {
                            hitInfo.transform.GetComponent<Martin>().talkThree();
                        }

                    }
                }

                else if (hitInfo.transform.tag == "Fairy")
                {
                    hitInfo.transform.GetComponent<Fairy>().talk();
                }

                else if (hitInfo.transform.tag == "Mipha")
                {
                    if (gameController.potionCount > 0)
                    {
                        hitInfo.transform.GetComponent<Mipha>().talk();
                    }
                }
            }
        }
    }



}
