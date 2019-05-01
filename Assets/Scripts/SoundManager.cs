﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager me;
    public int maxAudioSources;
    AudioSource[] sources;
    public AudioSource sourcePrefab;
    public AudioClip[] playerStep;
    public AudioClip[] background;

    int lastWalk;

    private void Awake()
    {
        if (me != null)//check me
        {
            Destroy(gameObject);
            return;
        }
        me = this;

        sources = new AudioSource[maxAudioSources];
        for (int i = 0; i < maxAudioSources; i++)
        {
            sources[i] = Instantiate(sourcePrefab, transform);
        }
    }

    public void PlayerWalkSound(Vector3 playerPosition)
    {
        int clipNum = GetRandom(playerStep.Length, lastWalk);
        lastWalk = PlaySound(playerStep, clipNum,playerPosition);
    }

    int PlaySound(AudioClip[] clips, int clipNum, Vector3 pos)
    {
        AudioSource source = GetSource();
        source.clip = clips[clipNum];
        source.transform.position = pos;
        source.pitch = Random.Range(.925f, 1.075f);
        source.Play();
        return clipNum;
    }

    AudioSource GetSource()
    {
        for (int i = 0; i < maxAudioSources; i++)
        {
            if (!sources[i].isPlaying)
            {
                return sources[i];
            }
        }
        Debug.LogError("NOT ENOUGH SOURCES");
        return sources[0];
    }

    int GetRandom(int clipNum, int lastPlayed)
    {
        int num = Random.Range(0, clipNum);
        while (num == lastPlayed)
        {
            num = Random.Range(0, clipNum);
        }
        return num;
    }

}
