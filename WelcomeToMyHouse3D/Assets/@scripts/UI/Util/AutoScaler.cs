using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Util
{
    public class AutoScaler : MonoBehaviour
    {
        private static bool _isFirst = true;
        public static float AutoLocalScaleFloat;

        private void Start()
        {
            var canvasScaler = ObjectFinder.FindParent<CanvasScaler>(transform);
            if (canvasScaler == null) return;
            var canvasRect = canvasScaler.GetComponent<RectTransform>();
            if (canvasRect == null) return;


            var keepScale = transform.localScale;
            // 720 x 1280 원본 / 리사이즈 580 x 1280 --> 580 / 720 사이즈로 조정
            float sizeMultiple = 1f;
            if (canvasRect.sizeDelta.x > canvasRect.sizeDelta.y)
            {
                // 가로 길이가 더 길면, 캔버스의 세로 크기를 참조 해상도의 세로 크기로 나누어 sizeMultiple을 계산.
                if (canvasRect.sizeDelta.x < canvasRect.sizeDelta.y * 1.5)
                {
                    //가로 세로 길이 별차이 없으면 그냥 1로 함
                    sizeMultiple = 1;
                }
                else
                {
                    sizeMultiple = canvasRect.sizeDelta.y / canvasScaler.referenceResolution.y;
                }
            }
            else
            {
                if (canvasRect.sizeDelta.x * 1.5 > canvasRect.sizeDelta.y)
                {
                    //가로 세로 길이 별차이 없으면 그냥 1로 함
                    sizeMultiple = 1;
                }
                else
                {
                    // 그렇지 않으면, 캔버스의 가로 크기를 참조 해상도의 가로 크기로 나누어 sizeMultiple을 계산.
                    sizeMultiple = canvasRect.sizeDelta.x / canvasScaler.referenceResolution.x;
                }
            }
            transform.localScale = new Vector3(keepScale.x * sizeMultiple, keepScale.y * sizeMultiple, keepScale.z * sizeMultiple);

            if (_isFirst)
            {
                _isFirst = false;
                AutoLocalScaleFloat = keepScale.x * sizeMultiple;
            }
        }
    }
}
