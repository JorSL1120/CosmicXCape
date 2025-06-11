using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar2D : MonoBehaviour
{
    public Transform Detector, Muestras, Enemigos, O2, Escudo, Bebida, RadarPoints;
    public GameObject RadarPointMuestrasPrefab;
    public GameObject RadarPointEnemigosPrefab;
    public GameObject RadarPointO2Prefab;
    public GameObject RadarPointEscudoPrefab;
    public GameObject RadarPointBebidaPrefab;
    public float MaxDistance, RadarScale;

    private List<Transform> muestrasList = new List<Transform>();
    private List<Transform> enemigosList = new List<Transform>();
    private List<Transform> o2List = new List<Transform>();
    private List<Transform> escudoList = new List<Transform>();
    private List<Transform> bebidaList = new List<Transform>();
    private List<GameObject> radarPointsList = new List<GameObject>();

    Vector3 startVectorRight;
    Vector3 startVectorForward;

    void Start()
    {
        startVectorRight = Detector.right;
        startVectorForward = Detector.forward;

        // Obtener referencias a los hijos de Muestras y Enemigos
        GetChildTransforms(Muestras, muestrasList);
        GetChildTransforms(Enemigos, enemigosList);
        GetChildTransforms(O2, o2List);
        GetChildTransforms(Escudo, escudoList);
        GetChildTransforms(Bebida, bebidaList);

        // Crear puntos de radar para Muestras
        CreateRadarPoints(muestrasList, RadarPointMuestrasPrefab);

        // Crear puntos de radar para Enemigos
        CreateRadarPoints(enemigosList, RadarPointEnemigosPrefab);

        // Crear puntos de radar para O2
        CreateRadarPoints(o2List, RadarPointO2Prefab);

        // Crear puntos de radar para Escudo
        CreateRadarPoints(escudoList, RadarPointEscudoPrefab);

        // Crear puntos de radar para Bebida
        CreateRadarPoints(bebidaList, RadarPointBebidaPrefab);
    }

    void Update()
    {
        UpdateRadarPoints(muestrasList, 0);
        UpdateRadarPoints(enemigosList, muestrasList.Count);
        UpdateRadarPoints(o2List, muestrasList.Count + enemigosList.Count);
        UpdateRadarPoints(escudoList, muestrasList.Count + enemigosList.Count + o2List.Count);
        UpdateRadarPoints(bebidaList, muestrasList.Count + enemigosList.Count + o2List.Count + escudoList.Count);
    }

    void GetChildTransforms(Transform parent, List<Transform> list)
    {
        list.Clear();
        for (int i = 0; i < parent.childCount; i++)
        {
            list.Add(parent.GetChild(i));
        }
    }

    void CreateRadarPoints(List<Transform> objectsList, GameObject radarPointPrefab)
    {
        foreach (Transform obj in objectsList)
        {
            GameObject radarPoint = Instantiate(radarPointPrefab, RadarPoints);
            radarPointsList.Add(radarPoint);
        }
    }

    void UpdateRadarPoints(List<Transform> objectsList, int startIndex)
    {
        for (int i = 0; i < objectsList.Count; i++)
        {
            // Verificar si el objeto está activo
            bool isObjectActive = objectsList[i].gameObject.activeSelf;

            Vector3 objPosition = objectsList[i].position;
            Vector2 radarPosition = RadarPosition(objPosition);
            int index = startIndex + i; // Índice para los puntos de radar en la lista

            // Actualizar la posición del punto de radar
            radarPointsList[index].transform.localPosition = radarPosition;

            // Verificar si el punto de radar debe estar activo o no
            if (isObjectActive && radarPosition.magnitude <= RadarScale)
            {
                // El objeto está activo y dentro del rango del radar, mostrar el punto de radar
                radarPointsList[index].GetComponent<Image>().enabled = true;
            }
            else
            {
                // El objeto está fuera del rango del radar o ha sido recogido, ocultar el punto de radar
                radarPointsList[index].GetComponent<Image>().enabled = false;
            }
        }
    }

    Vector2 RadarPosition(Vector3 position)
    {
        float scaleFactor = RadarScale / MaxDistance;
        Vector3 scaleRelativePosition = scaleFactor * (position - Detector.position);
        float xCoordinate = Vector3.Dot(scaleRelativePosition, startVectorRight);
        float zCoordinate = Vector3.Dot(scaleRelativePosition, startVectorForward);
        return new Vector2(xCoordinate, zCoordinate);
    }
}
