using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public float[] m_audioSpectrum;
    public static float spectrumValue {get; private set;}
    // Start is called before the first frame update
    private void Start()
    {
        m_audioSpectrum = new float[128];
    }

    // Update is called once per frame
    private void Update()
    {
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming);

        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0){
          spectrumValue = m_audioSpectrum[0] * 100;
        }
    }
}
