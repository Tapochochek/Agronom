using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoilAuger : MonoBehaviour
{
    [SerializeField] GameObject[] partsEarth;

    public float digDepth = 0.1f;      // 20 см
    public float digSpeed = 0.5f;      // скорость опускания
    public float rotationSpeed = 360f; // градусов в секунду
  
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isDigging = false;

    void Start()
    {
        startPos = transform.localPosition;
        targetPos = startPos - new Vector3(0, digDepth, 0);
    }

    void Update()
    {
        if (isDigging)
        {
            // вращение вокруг оси
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // плавное опускание
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                targetPos,
                digSpeed * Time.deltaTime
            );

            // Проверка: если достиг глубины, остановить движение
            if (Vector3.Distance(transform.localPosition, targetPos) < 0.001f)
            {
                gameObject.AddComponent<XRGrabInteractable>();
                gameObject.AddComponent<XRSimpleInteractable>();
                foreach (GameObject partEarth in partsEarth)
                {
                    partEarth.SetActive(true);
                    partEarth.GetComponent<MeshCollider>().isTrigger = false;
                }
                isDigging = false; // останавливаем движение
                transform.localPosition = targetPos; // фиксируем точное положение
            }
        }
    }

    // Вызов по событию grab или кнопке
    public void StartDigging()
    {
        isDigging = true;
    }
}
