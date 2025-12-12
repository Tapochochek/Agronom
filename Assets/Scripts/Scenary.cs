using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum StepScenary
{
    None,
    InstrumentAdd,
    PlantsDiagnostick,
    GruntAnalyze,
    MakeChoise,
    End
}
public enum GruntAnalize
{
    None,
    BurInGrunt,
    RemoveInGround,
    End
}
public class Scenary : MonoBehaviour
{
    public static int instrumentCount;

    private int _globalStepCount;
    private int _miniStepCount;

    public static StepScenary step = StepScenary.None;

    [Header("Поинты прикрепления")]
    [SerializeField] GameObject _attachPointFirst;
    [SerializeField] GameObject _attachPointSecond;
    [SerializeField] GameObject _attachPointThird;

    [Header("Первый этап сценария")]
    [SerializeField] GameObject _colosLeafInteract;
    [SerializeField] GameObject _colosRootsInteract;

    private void Start()
    {
        instrumentCount = 0;
        step = StepScenary.None;
        
        _attachPointSecond.SetActive(false);
        _attachPointThird.SetActive(false);
        _attachPointFirst.SetActive(false);

        step = SwitchGlobalScenary(step);
    }
    void Update()
    {
        if(instrumentCount >= 3 && step==StepScenary.InstrumentAdd)
        {
            Debug.Log("Switch");
            
            step = SwitchGlobalScenary(step);

            
        }
    }
    public StepScenary SwitchGlobalScenary(StepScenary scenaryStep)
    {       
        switch (scenaryStep)
        {
            //Первый пустой этап сценария
            case StepScenary.None:
                scenaryStep = StepScenary.InstrumentAdd;
                return(scenaryStep);

            //Этап для открытия первой точки прикрепления, открывается после выполнения условия в update
            case StepScenary.InstrumentAdd:
                Debug.Log("ahahahahhah");
                scenaryStep = StepScenary.PlantsDiagnostick;
                _attachPointFirst.SetActive(true);
                return (scenaryStep);

            case StepScenary.PlantsDiagnostick:
                scenaryStep = StepScenary.GruntAnalyze;

                _attachPointFirst.SetActive(false);

                _colosLeafInteract.GetComponent<XRSimpleInteractable>().enabled = true;
                _colosRootsInteract.GetComponent<XRGrabInteractable>().enabled = true;

                return (scenaryStep);

            case StepScenary.GruntAnalyze:
                scenaryStep = StepScenary.MakeChoise;
                return (scenaryStep);

            case StepScenary.MakeChoise:
                scenaryStep = StepScenary.End;
                return (scenaryStep);

            default:
                return (scenaryStep);
        }
    }
    public GruntAnalize SwitchMiniScenary(GruntAnalize gruntAnalize)
    {
        switch (gruntAnalize)
        {
            case GruntAnalize.None:
                return (gruntAnalize);
            case GruntAnalize.BurInGrunt:
                return (gruntAnalize);
            case GruntAnalize.RemoveInGround:
                return (gruntAnalize);
            default:
                return (gruntAnalize);
        }
    }
}
