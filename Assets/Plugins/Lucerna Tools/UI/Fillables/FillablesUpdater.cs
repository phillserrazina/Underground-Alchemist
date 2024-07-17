using Lucerna.Managers;
using System.Collections;
using UnityEngine;

namespace Lucerna.UI
{
	public class FillablesUpdater
	{
        // VARIABLES
        private readonly float[] fillLevels;

        private static FillablesUpdater instance;
        public static FillablesUpdater Instance => instance ??= CreateUpdaterWithLinearLevels(5);

        // CONSTRUCTORS
        private FillablesUpdater(float[] fillLevels)
        {
            this.fillLevels = fillLevels;
        }

        private static FillablesUpdater CreateUpdaterWithLinearLevels(int numberOfLevels)
        {
            float[] levelsArray = new float[numberOfLevels];

            for (int i = 0; i < numberOfLevels; i++)
            {
                levelsArray[i] = i + 1;
            }
        
            return new FillablesUpdater(levelsArray);
        }

        // METHODS
        public void SetTargetFillablesToValue(FillableUI[] targetFillables, float initialValue, float targetValue, bool instant)
        {
            if (initialValue == targetValue)
            {
                return;
            }

            CoroutineManager.Instance.StartCoroutine(FillAnimationCoroutine(targetFillables, initialValue, targetValue, instant));
        }

        private IEnumerator FillAnimationCoroutine(FillableUI[] targetFillables, float initialValue, float targetValue, bool instant)
        {
            int targetFillableIndex = -1;
            bool increase = targetValue > initialValue;

            if (increase)
            {
                for (int i = 0; i < fillLevels.Length; i++)
                {
                    if (targetValue <= fillLevels[i])
                    {
                        if (targetFillableIndex == -1)
                        {
                            targetFillableIndex = i;
                        }
                        else
                        {
                            yield return CoroutineManager.Instance.StartCoroutine(UpdateTargetFillable(targetFillables[i], 0f, instant));
                        }
                    }
                    else
                    {
                        yield return CoroutineManager.Instance.StartCoroutine(UpdateTargetFillable(targetFillables[i], 1f, instant));
                    }
                }

                UpdateLastElement(targetFillables, targetFillableIndex, fillLevels, targetValue, instant);
                yield break;
            }


            for (int i = fillLevels.Length - 1; i >= 0; i--)
            {
                if (targetValue > fillLevels[i] - 1)
                {
                    if (targetFillableIndex == -1)
                    {
                        targetFillableIndex = i;
                    }
                    else
                    {
                        yield return CoroutineManager.Instance.StartCoroutine(UpdateTargetFillable(targetFillables[i], 1f, instant));
                    }
                }
                else
                {
                    yield return CoroutineManager.Instance.StartCoroutine(UpdateTargetFillable(targetFillables[i], 0f, instant));
                }
            }

            UpdateLastElement(targetFillables, targetFillableIndex, fillLevels, targetValue, instant);
        }

        private IEnumerator UpdateTargetFillable(FillableUI targetFillable, float value, bool instant)
        {
            if (instant)
            {
                targetFillable.UpdateFillInstant(value);
            }
            else
            {
                targetFillable.UpdateFill(value);
                yield return new WaitUntil(() => targetFillable.IsDoneAnimating);
            }
        }

        private void UpdateLastElement(FillableUI[] targetFillables, int targetFillableIndex, float[] fillLevels, float targetValue, bool instant)
        {
            float relevantValue;
            float relevantMax;

            if (targetFillableIndex == 0)
            {
                relevantMax = fillLevels[targetFillableIndex];
                relevantValue = targetValue;
            }
            else if (targetFillableIndex > 0)
            {
                relevantMax = fillLevels[targetFillableIndex] - fillLevels[Mathf.Clamp(targetFillableIndex - 1, 0, 10)];
                relevantValue = targetValue - fillLevels[Mathf.Clamp(targetFillableIndex - 1, 0, 10)];
            }
            else
            {
                targetFillableIndex = 0;
                relevantValue = 0;
                relevantMax = 1;
            }

            float relevantPercentage = relevantValue / relevantMax;

            if (instant)
            {
                targetFillables[targetFillableIndex].UpdateFillInstant(relevantPercentage);
            }
            else
            {
                targetFillables[targetFillableIndex].UpdateFill(relevantPercentage);
            }
        }
    }
}