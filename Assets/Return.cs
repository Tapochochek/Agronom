using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Return : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    private XRGrabInteractable grab;

    private bool returning = false;
    public float returnSpeed = 4f;

    void Start()
    {
        // Запоминаем исходное положение листа
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;

        grab = GetComponent<XRGrabInteractable>();

        // Подписываемся на события XR Toolkit
        grab.selectExited.AddListener(OnRelease);
        grab.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs arg)
    {
        // Перестаём возвращать лист, если его снова взяли
        returning = false;
    }

    private void OnRelease(SelectExitEventArgs arg)
    {
        // Включаем возврат
        returning = true;
    }

    void Update()
    {
        if (returning)
        {
            // Плавный возврат
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, Time.deltaTime * returnSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, startRotation, Time.deltaTime * returnSpeed);

            // Если вернулся достаточно близко — фиксируем
            if (Vector3.Distance(transform.localPosition, startPosition) < 0.01f)
            {
                transform.localPosition = startPosition;
                transform.localRotation = startRotation;
                returning = false;
            }
        }
    }
}
