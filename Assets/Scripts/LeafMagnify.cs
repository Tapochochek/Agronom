using UnityEngine;

public class LeafMagnify : MonoBehaviour
{
    public Transform leafMesh; // <<<<<<<<<<<<<< добавить сюда
    public Material diseaseMaterial;

    public float magnifyScale = 1.5f;
    public float speed = 6f;

    private Vector3 baseScale;
    private bool isMagnified = false;

    private MeshRenderer rend;

    void Start()
    {
        rend = leafMesh.GetComponent<MeshRenderer>();
        baseScale = leafMesh.localScale;
    }

    void Update()
    {
        Vector3 target = isMagnified ? baseScale * magnifyScale : baseScale;

        leafMesh.localScale = Vector3.Lerp(
            leafMesh.localScale,
            target,
            Time.deltaTime * speed
        );
    }

    public void StartMagnify()
    {
        AddDiseaseMaterial();
        isMagnified = true;
    }

    public void StopMagnify()
    {
        RemoveDiseaseMaterial();
        isMagnified = false;
    }

    private void AddDiseaseMaterial()
    {
        var mats = rend.materials;
        foreach (var m in mats) if (m == diseaseMaterial) return;

        var newMats = new Material[mats.Length + 1];
        mats.CopyTo(newMats, 0);
        newMats[mats.Length] = diseaseMaterial;

        rend.materials = newMats;
    }

    private void RemoveDiseaseMaterial()
    {
        var mats = rend.materials;
        if (mats.Length <= 1) return;

        var newMats = new Material[mats.Length - 1];
        for (int i = 0; i < newMats.Length; i++)
            newMats[i] = mats[i];

        rend.materials = newMats;
    }
}
