using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//图表
namespace UI
{
    public enum Draw2DUILineType
    {
        Immediate,
    }

    public struct PixelInfo
    {
        public int index;
        public Color32 color;

        public PixelInfo(int _index, Color32 _color)
        {
            this.index = _index;
            this.color = _color;
        }
    }

    public class Draw2DUILine : MonoBehaviour
    {

        [SerializeField]
        public List<Vector2> m_ListPoints = new List<Vector2>();
        public List<Vector2> ListPoints
        {
            set { m_ListPoints = value; }
        }

        public Rigidbody2D rg;
        [SerializeField]
        private RawImage m_BgImage;
        public RawImage BgImage
        {
            set { m_BgImage = value; }
        }

        [Header("主线条颜色")]
        public Color MainLineColor = Color.white;

        [Header("背景色")]
        public Color32 BgColor = Color.white;

        [Header("基准线")]
        public Color32 BaseLineColor = Color.black;

        [Header("背景贴图_宽")]
        [SerializeField]
        private int widthPixels = 500;

        [Header("背景贴图_高")]
        [SerializeField]
        private int heightPixels = 500;

        [Header("绘制线条类型")]
        [SerializeField]
        public Draw2DUILineType DrawLineType = Draw2DUILineType.Immediate;

        [Header("是否需要基线")]
        public bool NeedBaseLine;

        private Texture2D m_BgTexture;

        private Color32[] m_PixelsBg;
        private Color32[] m_PixelsDrawLine;


        public int X = 0;
        void Start()
        {

            Init(new Rect(Vector2.zero, new Vector2(widthPixels, heightPixels)));
            GetComponent<RectTransform>().sizeDelta = new Vector2(widthPixels, heightPixels);

        }

        //主要控制
        private void FixedUpdate()
        {
            if(rg != null)
            {
                X += 1;
                Draw2DLine(m_ListPoints, DrawLineType, NeedBaseLine);
                m_ListPoints.Add(new Vector2(X, rg.velocity.magnitude * 5));
                if(m_ListPoints.Count > 1000)
                {
                    m_ListPoints.RemoveAt(0);
                }

            }
        }

        public void Clear()
        {
            X = 0;
            m_ListPoints.RemoveAll(it => true);

        }

        void Init(Rect pixelSize)
        {
            m_BgTexture = new Texture2D(widthPixels, heightPixels);

            if (m_BgImage == null) {
                m_BgImage = this.transform.GetComponent<RawImage>();
            }
            if (m_BgImage == null) {
                GameObject newObj = transform.Find("Draw Line").gameObject;
                newObj.name = "Draw Line";
                newObj.transform.SetParent(this.transform);
                newObj.transform.localPosition = Vector3.zero;
                m_BgImage = newObj.AddComponent<RawImage>();
            }
            m_BgImage.texture = m_BgTexture;
            m_BgImage.SetNativeSize();

            m_PixelsDrawLine = new Color32[widthPixels * heightPixels];
            m_PixelsBg = new Color32[widthPixels * heightPixels];

            for (int i = 0; i < m_PixelsBg.Length; ++i)
            {
                m_PixelsBg[i] = BgColor;
            }
        }

        /// <summary>
        /// 绘制 2D 线条
        /// </summary>
        /// <param name="type">绘制类型</param>
        /// <param name="isNeedBaseLine">是否需要基线</param>
        void Draw2DLine(List<Vector2> data, Draw2DUILineType type, bool isNeedBaseLine) {

            // 不绘制，显示默认的背景图
            if (data == null || data.Count < 2) {
                m_BgTexture.SetPixels32(m_PixelsBg);
                m_BgTexture.Apply();
            }

            ImmediaDraw(NeedBaseLine);

            switch (type) {
                case Draw2DUILineType.Immediate:
                    break;
            }
        }

        /// <summary>
        /// 直接绘制线条
        /// </summary>
        /// <param name="isNeedBaseLine">是否需要基线</param>
        void ImmediaDraw(bool isNeedBaseLine)
        {
            List<PixelInfo> allLinePixelIndex = new List<PixelInfo>();

            // Clear.
            Array.Copy(m_PixelsBg, m_PixelsDrawLine, m_PixelsBg.Length);

            // 基准线
            if (isNeedBaseLine) {
                allLinePixelIndex.AddRange(DrawLine(new Vector2(0f, heightPixels * 0.5f), new Vector2(widthPixels, heightPixels * 0.5f), BaseLineColor));
            }

            for (int i = 0; i < m_ListPoints.Count - 1; i++)
            {
                Vector2 from = m_ListPoints[i];
                Vector2 to = m_ListPoints[i + 1];
                allLinePixelIndex.AddRange(DrawLine(from, to, MainLineColor));
            }

            for (int i = 0, len = allLinePixelIndex.Count; i < len; ++i)
            {
                m_PixelsDrawLine[allLinePixelIndex[i].index] = allLinePixelIndex[i].color;
            }

            m_BgTexture.SetPixels32(m_PixelsDrawLine);
            m_BgTexture.Apply();
        }

        /// <summary>
        /// 绘制一条线段
        /// </summary>
        /// <param name="from">开始点</param>
        /// <param name="to">结束点</param>
        /// <param name="color">线条颜色</param>
        /// <returns></returns>
        List<PixelInfo> DrawLine(Vector2 from, Vector2 to, Color32 color)
        {
            int i;
            int j;
            List<PixelInfo> retIndexList = new List<PixelInfo>();

            if (Mathf.Abs(to.x - from.x) > Mathf.Abs(to.y - from.y))
            {
                // Horizontal line.
                i = 0;
                j = 1;
            }
            else
            {
                // Vertical line.
                i = 1;
                j = 0;
            }

            int x = (int)from[i];
            int delta = (int)Mathf.Sign(to[i] - from[i]);
            while (x != (int)to[i])
            {
                int y = (int)Mathf.Round(from[j] + (x - from[i]) * (to[j] - from[j]) / (to[i] - from[i]));

                int index;
                if (i == 0)
                    index = y * widthPixels + x;
                else
                    index = x * widthPixels + y;

                index = Mathf.Clamp(index, 0, m_PixelsDrawLine.Length - 1);
                //pixelsDrawLine[index] = color;
                retIndexList.Add(new PixelInfo(index, color));

                x += delta;
            }

            return retIndexList;
        }
    }
}