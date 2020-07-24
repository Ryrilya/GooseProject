using System;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoSingleton<LightingManager>
{
    // References
    [SerializeField] private Light directionalLight;
    // [SerializeField] private LightingPreset preset;
    [SerializeField] private Material[] skyboxes;

    // Variables
    [SerializeField, Range(0, 24)] private float timeOfDay;

    private void Update()
    {
        // if (preset == null) return;
        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime * 0.1f;
            timeOfDay %= 24;
            if (timeOfDay >= 0 && timeOfDay < 5)
                RenderSettings.skybox = skyboxes[0];
            if (timeOfDay >= 5 && timeOfDay < 10)
                RenderSettings.skybox = skyboxes[1];
            if (timeOfDay >= 10 && timeOfDay < 17)
                RenderSettings.skybox = skyboxes[2];
            if (timeOfDay >= 17 && timeOfDay < 19) 
                RenderSettings.skybox = skyboxes[3];
            if (timeOfDay >= 19 && timeOfDay <= 24)
                RenderSettings.skybox = skyboxes[4];
            UpdateLighting(timeOfDay / 24f);
        }else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        //RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        //RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
           // directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }else {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
