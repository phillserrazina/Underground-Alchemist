using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Lucerna.Audio
{
	public class AudioSourceExtension : MonoBehaviour 
	{
		// VARIABLES
		[SerializeField] private AudioSource audioSource;

		[Header("Options")]
		[SerializeField] private bool randomizeClip = true;
		[ShowIf("randomizeClip"), SerializeField] private List<AudioClip> clips = new List<AudioClip>();

        [SerializeField] private bool randomizeVolume = false;
        [ShowIf("randomizeVolume"), MinMaxSlider(0f, 1f, true), SerializeField] private Vector2 volumeRange = new Vector2(0, 1);

        [SerializeField] private bool randomizePitch = false;
        [ShowIf("randomizePitch"), MinMaxSlider(-3f, 3f, true), SerializeField] private Vector2 pitchRange = new Vector2(0, 1);

        private Tween fadeTween;

        public bool IsPlaying => audioSource.isPlaying;
        public float Length => audioSource.clip.length;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            if (audioSource.playOnAwake)
            {
                ApplyExtraOptions();
            }
        }

        // METHODS
        public void Play()
		{
            if (randomizeClip || randomizeVolume || randomizePitch)
            {
			    ApplyExtraOptions();
            }

            audioSource.Play();
		}

        public void Stop()
        {
            audioSource.Stop();
        }

        public void FadeIn(float duration)
        {
            Play();
            SetVolume(0f);
            FadeTo(1f, duration);
        }

        public void FadeOut(float duration)
        {
            SetVolume(1f);
            FadeTo(0f, duration);
            
            DOVirtual.DelayedCall(duration, () =>
            {
                Stop();
            });
        }

        public void FadeTo(float value, float duration)
        {
            if (fadeTween != null)
            {
                fadeTween.Kill();
                fadeTween = null;
            }

            float initialValue = audioSource.volume;

            fadeTween = DOVirtual.Float(initialValue, value, duration, result =>
            {
                audioSource.volume = result;
            });
        }

        public void SetVolume(float value) => audioSource.volume = value;
        public void SetClip(AudioClip clip) => audioSource.clip = clip;
        public void SetRandomClips(AudioClip[] clips) => this.clips = new List<AudioClip>(clips);

        private void ApplyExtraOptions()
        {
            if (randomizeClip)
            {
                audioSource.clip = clips[Random.Range(0, clips.Count)];

                if (audioSource.loop)
                {
                    DOVirtual.DelayedCall(audioSource.clip.length, () =>
                    {
                        Play();
                    });
                }
            }

            if (randomizeVolume)
            {
                audioSource.volume = Random.Range(volumeRange.x, volumeRange.y);
            }

            if (randomizePitch)
            {
                audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
            }
        }
	}
}