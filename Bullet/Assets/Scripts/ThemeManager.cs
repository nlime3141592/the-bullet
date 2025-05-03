using UnityEngine;

namespace Unchord
{
    public sealed class ThemeManager : Singleton<ThemeManager>
    {
        private const int c_THEME_COLOR_COUNT = 7;

        public _Theme CurrentTheme { get; private set; }

        #region Inspector Properties
        public float skyboxColorMixingSpeed = 0.2f;
        #endregion

        private int _skyboxColorIndex0;
        private int _skyboxColorIndex1;
        private Color _skyboxColor0;
        private Color _skyboxColor1;
        private float _skyboxColorWeight;

        public void LoadTheme(string themeName)
        {
            // TODO: should fix resource path after creating theme resource folder.
            string path = themeName;

            _Theme themeResource = Resources.Load<_Theme>(path);
            _Theme themeInstance = UnityEngine.Object.Instantiate<_Theme>(themeResource);

            CurrentTheme = themeInstance;

            InitSkyboxColorSet();

            // TODO: write changing bgm code here.
        }

        private void Update()
        {
            MixSkyboxColor();
        }

        private void InitSkyboxColorSet()
        {
            int count = c_THEME_COLOR_COUNT;
            int[] index = new int[count];

            for (int i = 0; i < count; ++i)
            {
                int j = Random.Range(0, i + 1);

                index[i] = index[j];
                index[j] = i;
            }

            _skyboxColorIndex0 = index[0];
            _skyboxColorIndex1 = index[1];

            _skyboxColor0 = GetSkyboxColorByIndex(0);
            _skyboxColor1 = GetSkyboxColorByIndex(1);

            _skyboxColorWeight = 0.0f;
        }

        private void MixSkyboxColor()
        {
            Color mixedColor = Color.Lerp(_skyboxColor0, _skyboxColor1, _skyboxColorWeight);
            RenderSettings.skybox.SetColor("_Tint", mixedColor);

            float nextWeight = (_skyboxColorWeight + skyboxColorMixingSpeed * Time.unscaledDeltaTime) % 1.0f;

            if (nextWeight < _skyboxColorWeight)
            {
                ChangeSkyboxColorSet();
            }
        }

        private void ChangeSkyboxColorSet()
        {
            int index = -1;

            do
            {
                index = Random.Range(0, c_THEME_COLOR_COUNT);
            }
            while (index != _skyboxColorIndex0 && index != _skyboxColorIndex1);

            _skyboxColorIndex0 = _skyboxColorIndex1;
            _skyboxColorIndex1 = index;

            _skyboxColor0 = _skyboxColor1;
            _skyboxColor1 = GetSkyboxColorByIndex(index);
        }

        private Color GetSkyboxColorByIndex(int index)
        {
            switch (index)
            {
                case 0: return CurrentTheme.color0;
                case 1: return CurrentTheme.color1;
                case 2: return CurrentTheme.color2;
                case 3: return CurrentTheme.color3;
                case 4: return CurrentTheme.color4;
                case 5: return CurrentTheme.color5;
                case 6: return CurrentTheme.color6;
                default:
                    UnityEngine.Debug.Assert(false);
                    return Color.white;
            }
        }
    }
}