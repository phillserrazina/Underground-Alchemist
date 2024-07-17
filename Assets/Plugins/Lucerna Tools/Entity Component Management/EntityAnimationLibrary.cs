using UnityEngine;

namespace Lucerna.Entities
{
    public class EntityAnimationLibrary : EntityComponent
    {
        // VARIABLES
        [field: SerializeField] public Animator Animator { get; private set; } = null;

        public string CurrentAnimationName { get; private set; } = "";

        // METHODS
        public void UpdateAnimator(string key) { if (Animator != null) Animator.SetTrigger(key); }
        public void UpdateAnimator(string key, int val) { if (Animator != null) Animator.SetInteger(key, val); }
        public void UpdateAnimator(string key, bool val) { if (Animator != null) Animator.SetBool(key, val); }
        public void UpdateAnimator(string key, float val) { if (Animator != null) Animator.SetFloat(key, val); }
        public void UpdateAnimator(string key, float val, float time) { if (Animator != null) Animator.SetFloat(key, val, time, Time.deltaTime); }
        public void UpdateLayerWeight(int layerIndex, float value) => Animator.SetLayerWeight(layerIndex, value);

        public void Play(string animationName, float transitionDuration = 0f)
        {
            if (!Animator.gameObject.activeSelf)
            {
                return;
            }

            if (IsPlaying(animationName))
            {
                return;
            }

            CurrentAnimationName = animationName;

            if (transitionDuration <= 0f)
            {
                Animator.Play(animationName, 0, 0);
            }
            else
            {
                Animator.CrossFadeInFixedTime(animationName, transitionDuration);
            }
        }

        public bool IsPlaying(string animationName) => Animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }
}
