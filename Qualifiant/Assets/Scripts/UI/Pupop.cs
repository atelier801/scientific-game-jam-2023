using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class Pupop : MonoBehaviour
    {
        private static Pupop s_instance;

        public static Pupop Singleton
        {
            get
            {
                if (!s_instance) s_instance = FindObjectOfType<Pupop>();
                if (!s_instance) throw new NullReferenceException("Need one instance of Pupop in the sceen");
                return s_instance;
            }
        }

        [SerializeField] private RectTransform _rectTransform;
        public float speed = 25;
        public AnimationCurve curve;
        [Space] 
        public float timeBeforeCollapse = 6;
        private RectTransform pupop;

        private IEnumerator _animationRoutine;
        
        public void SpawnPupop(RectTransform _pupop)
        {
            ClearPupop();
            _rectTransform.position = new Vector3
            {
                x = transform.position.x,
                y = -_pupop.rect.height,
                z = transform.position.z
            };

            if (Instantiate(_pupop.gameObject, _rectTransform).TryGetComponent(out pupop))
            {
                StartDisplayAnimation();
            }
        }

        private void ClearPupop()
        {
            if (pupop)
                Destroy(pupop.gameObject);
        }

        private void StartDisplayAnimation()
        {
            if(_animationRoutine != null)
                StopCoroutine(_animationRoutine);

            _animationRoutine = AnimationRoutine();
            StartCoroutine(_animationRoutine);
        }

        private IEnumerator AnimationRoutine()
        {
            float time = 0;
            float currentY = _rectTransform.position.y;
            float originalY = currentY;
            float targetY = 0;
            float distance = Mathf.Abs(targetY - currentY);
            float step = 0;
            
            while (step < 1)
            {

                time += Time.unscaledDeltaTime * speed;
                step = curve.Evaluate(time / (distance / speed));
                currentY = Mathf.Lerp(originalY, targetY, step);
                
                transform.position = new Vector3
                {
                    x = transform.position.x,
                    y = currentY,
                    z = transform.position.y
                };

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(timeBeforeCollapse);

            step = 0;
            time = 0;
            targetY = originalY;
            originalY = 0;
            
            while (step < 1)
            {
                time += Time.unscaledDeltaTime * speed;
                step = curve.Evaluate(time / (distance / speed));
                currentY = Mathf.Lerp(originalY, targetY, curve.Evaluate( time / (distance / speed)));
                
                transform.position = new Vector3
                {
                    x = transform.position.x,
                    y = currentY,
                    z = transform.position.y
                };

                yield return new WaitForEndOfFrame();
            }
            
            ClearPupop();
        }
    }
}