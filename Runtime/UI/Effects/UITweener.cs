using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace Lab5Games.UI
{
    public enum UIAnimationTypes
    {
        Move,
        Scale,
        Fade,
        Color
    }

    // references
    // https://youtu.be/Ll3yujn9GVQ?t=217
    // https://www.cnblogs.com/movin2333/p/15201480.html

    [AddComponentMenu(
        UIConstants.MenuNameEffects + "/UI Tweener")]
    public class UITweener : MonoBehaviour
    {

        public GameObject target;

        public UIAnimationTypes animType = UIAnimationTypes.Scale;
        public Ease easeType = Ease.OutQuad;
        public AnimationCurve animCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

        public float duration = 0f;
        public float delay = 0;

        public int loops = 0;
        public LoopType loopType = LoopType.Restart;

        public float endValueFloat = 0f;
        public Vector3 endValueV3 = new Vector3(0, 0, 0);
        public Color endValueColor = new Color(1, 1, 1, 1);

        public bool isRelative = false;
        public bool playOnEnable = false;

        private Tween m_tween = null;
        public Tween tween => m_tween;

        public void Play()
        {
            CreateTween();
            SetupTween();
        }

        public void Stop()
        {
            if(m_tween != null && m_tween.IsActive())
            {
                m_tween.Kill();
            }

            m_tween = null;
        }

        public void Rewind()
        {
            if(m_tween != null)
            {
                m_tween.Rewind();
            }
        }

        private void CreateTween()
        {
            if (target == null)
                target = gameObject;

            switch (animType)
            {
                case UIAnimationTypes.Move:
                    m_tween = CreateMoveTween();
                    break;

                case UIAnimationTypes.Scale:
                    m_tween = CreateScaleTween();
                    break;

                case UIAnimationTypes.Fade:
                    m_tween = CreateFadeTween();
                    break;

                case UIAnimationTypes.Color:
                    m_tween = CreateColorTween();
                    break;
            }
        }

        private Tween CreateMoveTween()
        {
            if(target.TryGetComponent(out RectTransform rect))
            {
                return DOTween.To(() => { return rect.anchoredPosition; }, v => { rect.anchoredPosition = v; }, (Vector2)endValueV3, duration);
            }

            return null;
        }

        private Tween CreateScaleTween()
        {
            if (target.TryGetComponent(out RectTransform rect))
            {
                return rect.DOScale(endValueV3, duration);
            }

            return null;
        }

        private Tween CreateFadeTween()
        {
            if (target.TryGetComponent(out CanvasGroup canvasGroup))
            {
                return DOTween.To(() => { return canvasGroup.alpha; }, a => { canvasGroup.alpha = a; }, endValueFloat, duration);
            }

            if (target.TryGetComponent(out Image image))
            {
                return DOTween.To(() => { return image.alpha(); }, a => { image.setAlpha(a); }, endValueFloat, duration);
            }

            if (target.TryGetComponent(out TextMeshProUGUI text))
            {
                return DOTween.To(() => { return text.alpha(); }, a => { text.setAlpha(a); }, endValueFloat, duration);
            }

            Debug.LogError("[UITweener] Could not find a valid component on the target", target);
            return null;
        }

        private Tween CreateColorTween()
        {
            if(target.TryGetComponent(out Image image))
            {
                return DOTween.To(()=> { return image.color; }, c => { image.color = c; }, endValueColor, duration);
            }

            if(target.TryGetComponent(out TextMeshProUGUI text))
            {
                return DOTween.To(() => { return text.faceColor; }, c => { text.faceColor = c; }, endValueColor, duration);
            }

            Debug.LogError("[UITweener] Could not find a valid component on the target", target);
            return null;
        }

        private void SetupTween()
        {
            if (m_tween != null)
            {
                m_tween.SetDelay(delay);
                m_tween.SetLoops(loops, loopType);
                m_tween.SetRelative(isRelative);

                if (easeType == Ease.Unset)
                    m_tween.SetEase(animCurve);
                else
                    m_tween.SetEase(easeType);
            }
        }

        private void OnEnable()
        {
            if(playOnEnable)
            {
                Play();
            }
        }

        private void OnDestroy()
        {
            Stop();
        }
    }

    public static class UITweenerUtils
    {
        public static float alpha(this Image image)
        {
            return image.color.a;
        }

        public static void setAlpha(this Image image, float a)
        {
            Color c = image.color;
            c.a = a;
            image.color = c;
        }

        public static float alpha(this TextMeshProUGUI text)
        {
            return text.alpha;
        }

        public static void setAlpha(this TextMeshProUGUI text, float a)
        {
            text.alpha = a;
        }
    }
}
