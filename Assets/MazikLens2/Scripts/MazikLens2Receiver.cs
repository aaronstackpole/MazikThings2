using UnityEngine;
using System.Collections.Generic;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;

public class MazikLens2Receiver : InteractionReceiver
{
    #region Private Member Variables
    private bool bMazikThingsSlidesActive = false;
    private GameObject goMazikThingsSlides = null;
    private int nMazikThingsSlideIdx = 0;
    private List<GameObject> pMazikThingsSlides = new List<GameObject>();
    private GameObject goMazikThingsPointer = null;
    private GameObject goMazikThingsParticles = null;

    private bool bMazikCareSlidesActive = false;
    private GameObject goMazikCareSlides = null;
    private int nMazikCareSlideIdx = 0;
    private List<GameObject> pMazikCareSlides = new List<GameObject>();
    private GameObject goMazikCarePointer = null;
    private GameObject goMazikCareParticles = null;

    private bool bTimelineActive = false;
    private GameObject goTimeline = null;
    private GameObject goTimelinePointer = null;
    #endregion

    #region Private Member Functions
    void FindMazikThingsObjects()
    {
        // Find the root container
        goMazikThingsSlides = GameObject.Find("MazikThingsPresentation");

        // Add all the slides
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_1"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_2"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_3"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_4"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_5"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_6"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_7"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_8"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_9"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_10"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_11"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_12"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_13"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_14"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_15"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_16"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_17"));
        pMazikThingsSlides.Add(GameObject.Find("MazikThings_18"));

        // Find the MazikThingsPresentation effects
        goMazikThingsPointer = GameObject.Find("MazikThingsPointer");
        goMazikThingsParticles = GameObject.Find("Particles_MazikThings");
    }

    void ResetMazikThingsState()
    {
        // Reset the slide index
        nMazikThingsSlideIdx = 0;
        bMazikThingsSlidesActive = false;

        // Turn all the slides off
        foreach (var slide in pMazikThingsSlides)
        {
            slide.SetActive(false);
        }

        // Turn the first slide on
        pMazikThingsSlides[nMazikThingsSlideIdx].SetActive(true);

        // Turn the presentation off
        goMazikThingsSlides.SetActive(bMazikThingsSlidesActive);

        // Turn the effects off
        goMazikThingsPointer.SetActive(bMazikThingsSlidesActive);
        goMazikThingsParticles.SetActive(bMazikThingsSlidesActive);
    }

    void FindMazikCareObjects()
    {
        // Find the root container
        goMazikCareSlides = GameObject.Find("MazikCarePresentation");

        // Add all the slides
        pMazikCareSlides.Add(GameObject.Find("MazikCare_1"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_2"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_3"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_4"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_5"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_6"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_7"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_8"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_9"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_10"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_11"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_12"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_13"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_14"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_15"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_16"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_17"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_18"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_19"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_20"));
        pMazikCareSlides.Add(GameObject.Find("MazikCare_21"));

        // Find the MazikCarePresentation effects
        goMazikCarePointer = GameObject.Find("MazikCarePointer");
        goMazikCareParticles = GameObject.Find("Particles_MazikCare");
    }

    void ResetMazikCareState()
    {
        // Reset the slide index
        nMazikCareSlideIdx = 0;
        bMazikCareSlidesActive = false;

        // Turn all the slides off
        foreach (var slide in pMazikCareSlides)
        {
            slide.SetActive(false);
        }

        // Turn the first slide on
        pMazikCareSlides[nMazikCareSlideIdx].SetActive(true);

        // Turn the presentation off
        goMazikCareSlides.SetActive(bMazikCareSlidesActive);

        // Turn the presentation effects off
        goMazikCarePointer.SetActive(bMazikCareSlidesActive);
        goMazikCareParticles.SetActive(bMazikCareSlidesActive);
    }

    void FindTimelineObjects()
    {
        // Find the root container
        goTimeline = GameObject.Find("TimelineMeshPresentation");

        // Find the Timeline pointer
        goTimelinePointer = GameObject.Find("TimelinePointer");
    }

    void ResetTimelineState()
    {
        // Turn the objects off
        bTimelineActive = false;
        goTimeline.SetActive(bTimelineActive);
        goTimelinePointer.SetActive(bTimelineActive);
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        FindMazikThingsObjects(); // Set up the game objects for the MazikThings presentation
        ResetMazikThingsState(); // Reset the object state variables

        FindMazikCareObjects(); // Set up the game objects for the MazikCare presentation
        ResetMazikCareState(); // Reset the object state variables

        FindTimelineObjects(); // Set up the game objects for the Timeline model
        ResetTimelineState(); // Reset the object state variables
    }

    protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
    {
        base.FocusEnter(obj, eventData);

        Debug.Log("FocusEnter: " + obj.name);

        switch (obj.name)
        {
            case "Model_Timeline":
                goTimelinePointer.SetActive(false); // Turn the Timeline pointer off
                break;
            case "ButtonMeshMazikThings":
                goMazikThingsParticles.SetActive(true);
                break;
            case "ButtonMeshMazikCare":
                goMazikCareParticles.SetActive(true);
                break;
            default:
                break;
        }
    }

    protected override void FocusExit(GameObject obj, PointerSpecificEventData eventData)
    {
        base.FocusExit(obj, eventData);

        switch (obj.name)
        {
            case "Model_Timeline":
                goTimelinePointer.SetActive(true); // Turn the Timeline pointer on
                break;
            case "ButtonMeshMazikThings":
                goMazikThingsParticles.SetActive(false);
                break;
            case "ButtonMeshMazikCare":
                goMazikCareParticles.SetActive(true);
                break;
            default:
                break;
        }
    }

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        base.InputDown(obj, eventData);

        switch (obj.name)
        {
            case "ButtonMeshMazikThings":
                bMazikThingsSlidesActive = !bMazikThingsSlidesActive; // Flip active state
                goMazikThingsSlides.SetActive(bMazikThingsSlidesActive); // Turn the slides on/off
                goMazikThingsPointer.SetActive(bMazikThingsSlidesActive); // Turn the pointer on/off
                if (bMazikThingsSlidesActive) // If we're turning MazikThings on, reset the other objects
                {
                    ResetMazikCareState(); // Reset the MazikCare objects
                    ResetTimelineState(); // Reset the Timeline objects
                }
                break;
            case "ButtonMeshMazikCare":
                bMazikCareSlidesActive = !bMazikCareSlidesActive; // Flip active state
                goMazikCareSlides.SetActive(bMazikCareSlidesActive); // Turn the slides on/off
                goMazikCarePointer.SetActive(bMazikCareSlidesActive); // Turn the pointer on/off
                if (bMazikCareSlidesActive) // If we're turning MazikCare on, reset the other objects
                {
                    ResetMazikThingsState(); // Reset the MazikThings objects
                    ResetTimelineState(); // Reset the Timeline objects
                }
                break;
            case "ButtonMeshHistory":
                bTimelineActive = !bTimelineActive; // Flip active state
                goTimeline.SetActive(bTimelineActive); // Turn the mesh on/off
                goTimelinePointer.SetActive(bTimelineActive); // Turn the pointer on/off
                if (bTimelineActive) // If we're turning Timeline on, reset the other objects
                {
                    ResetMazikThingsState(); // Reset the MazikThings objects
                    ResetMazikCareState(); // Reset the MazikCare objects
                }
                break;
            case "MazikThingsPrev":
                pMazikThingsSlides[nMazikThingsSlideIdx].SetActive(false); // Turn the current slide off
                nMazikThingsSlideIdx--; // Decrement the index
                if (nMazikThingsSlideIdx < 0) nMazikThingsSlideIdx = pMazikThingsSlides.Count - 1; // If we're at the start, set the index to the end
                pMazikThingsSlides[nMazikThingsSlideIdx].SetActive(true); // Turn the new slide on
                break;
            case "MazikThingsNext":
                pMazikThingsSlides[nMazikThingsSlideIdx].SetActive(false); // Turn the current slide off
                nMazikThingsSlideIdx++; // Increment the index
                if (nMazikThingsSlideIdx >= pMazikThingsSlides.Count) nMazikThingsSlideIdx = 0; // If we're at the end, set the index to the start
                pMazikThingsSlides[nMazikThingsSlideIdx].SetActive(true); // Turn the new slide on
                break;
            case "MazikCarePrev":
                pMazikCareSlides[nMazikCareSlideIdx].SetActive(false); // Turn the current slide off
                nMazikCareSlideIdx--; // Decrement the index
                if (nMazikCareSlideIdx < 0) nMazikCareSlideIdx = pMazikCareSlides.Count - 1; // If we're at the start, set the index to the end
                pMazikCareSlides[nMazikCareSlideIdx].SetActive(true); // Turn the new slide on
                break;
            case "MazikCareNext":
                pMazikCareSlides[nMazikCareSlideIdx].SetActive(false); // Turn the current slide off
                nMazikCareSlideIdx++; // Increment the index
                if (nMazikCareSlideIdx >= pMazikCareSlides.Count) nMazikCareSlideIdx = 0; // If we're at the end, set the index to the start
                pMazikCareSlides[nMazikCareSlideIdx].SetActive(true); // Turn the new slide on
                break;
            default:
                break;

        }
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
        base.InputUp(obj, eventData);
    }

    protected override void InputClicked(GameObject obj, InputClickedEventData eventData)
    {
        base.InputClicked(obj, eventData);
    }
}
