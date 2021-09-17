using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/SoundEvent")]
public class SoundEvent : ScriptableObject
{
    public AudioClip[] clips;
    [Space(7.5f)]
    //HorizontalGroup attributes spreads the slider correctly inside inline editors
    [VectorSlider(0, 2), HorizontalGroup("volume")] public Vector2 volume = new Vector2(.75f, 1.25f);
    [VectorSlider(0, 2), HorizontalGroup("pitch")] public Vector2 pitch = new Vector2(.75f, 1.25f);
    [HorizontalGroup("Loop")] public bool loop = false;
    [ShowIf("@loop"), HorizontalGroup("Loop"), HideLabel] public AudioMixerGroup mixerGroup;

    private AudioSource _previewer;

#if UNITY_EDITOR
    private void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave,
            typeof(AudioSource)).GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(_previewer);
    }

    [Button(ButtonSizes.Medium), PropertySpace(15)]
    public void Preview()
    {
        if (clips.Length == 0 || !_previewer) return;

        _previewer.clip = clips[Random.Range(0, clips.Length)];
        _previewer.volume = Random.Range(volume.x, volume.y);
        _previewer.pitch = Random.Range(pitch.x, pitch.y);
        _previewer.Play();
    } 
#endif

    public void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.Stop();
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume.x, volume.y);
        source.pitch = Random.Range(pitch.x, pitch.y);
        source.loop = loop;
        if (loop) source.outputAudioMixerGroup = mixerGroup;
        source.Play();
    }
}
