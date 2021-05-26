using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTransparent : MonoBehaviour
{
    private Shader m_OldShader = null;
    private Color m_OldColor = Color.black;
    private float m_Transparency = 0.3f;
    private const float m_TargetTransparancy = 0.3f;
    private const float m_FallOff = 0.1f; // returns to 100% in 0.1 sec

    private Renderer rendererTarget;

    void Start()
    {
        rendererTarget = GetComponent<Renderer>();
        if (rendererTarget == null || rendererTarget.material == null || !rendererTarget.material.HasProperty("_Color"))
        {
            Debug.LogError("Missing renderer or material");
            Destroy(this);
            return;
        }
        m_OldShader = rendererTarget.material.shader;
        m_OldColor = rendererTarget.material.color;
        rendererTarget.material.shader = Shader.Find("Transparent/Diffuse");
    }

    public void BeTransparent()
    {
        // reset the transparency;
        m_Transparency = m_TargetTransparancy;
    }

    void Update()
    {
        if (m_Transparency < 1.0f)
        {
            Color C = rendererTarget.material.color;
            C.a = m_Transparency;
            rendererTarget.material.color = C;
        }
        else
        {
            Destroy(this);
        }
        m_Transparency += ((1.0f - m_TargetTransparancy) * Time.deltaTime) / m_FallOff;
    }

    private void OnDestroy()
    {
        // Reset the shader
        rendererTarget.material.shader = m_OldShader;
        rendererTarget.material.color = m_OldColor;
    }
}
