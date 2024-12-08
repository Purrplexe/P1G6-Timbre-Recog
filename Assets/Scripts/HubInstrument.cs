using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HubInstrument : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    private List<Material> defaultMaterials = new List<Material>();
    private MeshRenderer[] meshes;
    public Material highlightMaterial;
    public void Start()
    {
        meshes = GetComponents<MeshRenderer>().ToList().Union(GetComponentsInChildren<MeshRenderer>()).ToArray();
        foreach (MeshRenderer mesh in GetComponents<MeshRenderer>().Union(GetComponentsInChildren<MeshRenderer>()))
        {
            defaultMaterials.Add(mesh.material);
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        meshes.ToList().ForEach(x => x.material = highlightMaterial);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].material = defaultMaterials[i];
        }
    }
}
