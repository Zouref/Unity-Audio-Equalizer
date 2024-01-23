using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias, timeStep, timeToBeat, restSmoothTime;
    private float m_previosAudioValue, m_AudioValue, m_timer;
    protected bool m_isBeat;

    private void Update(){
        OnUpdate();
    }

    public virtual void OnUpdate(){
      m_previosAudioValue = m_AudioValue;
      m_AudioValue = AudioSpectrum.spectrumValue;

      if (m_previosAudioValue > bias && m_AudioValue <= bias){
        if (m_timer > timeStep){
          OnBeat();
        }
      }

      if (m_previosAudioValue <= bias && m_AudioValue > bias){
        if (m_timer > timeStep){
          OnBeat();
        }
      }

      m_timer += Time.deltaTime;
    }

    public virtual void OnBeat(){
      m_timer = 0;
      m_isBeat = true;
    }
}
