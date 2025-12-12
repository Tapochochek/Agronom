using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPlayerPoint : MonoBehaviour
{
    public Scenary scenary;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _tryBox;
    [SerializeField] GameObject _try;

    ActionBasedContinuousMoveProvider _continuousMoveProvider;
    ActionBasedContinuousTurnProvider _snapTurnProvider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XROrigin>())
        {
            GameObject player = other.gameObject;
            player.transform.position = _spawnPoint.position;
            _continuousMoveProvider = player.GetComponent<ActionBasedContinuousMoveProvider>();
            _snapTurnProvider = player.GetComponent<ActionBasedContinuousTurnProvider>();

            //_continuousMoveProvider.enabled = false;
            //_snapTurnProvider.enabled = false;

            for(int i = 0;i < _tryBox.transform.childCount;i++)
            {
                _tryBox.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = true;
            }
            _try.SetActive(true);

            scenary.SwitchGlobalScenary(Scenary.step);
            

        }          
    }
}
