
using Cinemachine;
using UnityEngine;

public class BoundConfider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundShape();
    }

    public void SwitchBoundShape()
    {
        PolygonCollider2D polygonCollider2D =
            GameObject.FindWithTag(Tags.BoundConfinder).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
        
        cinemachineConfiner.InvalidatePathCache();
    }
     
}
