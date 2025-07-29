using UnityEngine;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public static class lilToonShaders
    {
        static Shader _opaqueShader;
        static Shader _cutoutShader;
        static Shader _transparentShader;

        static Shader _opaqueOutlineShader;
        static Shader _cutoutOutlineShader;
        static Shader _transparentOutlineShader;

        public static Shader OpaqueShader
        {
            get
            {
                if (_opaqueShader == null)
                {
                    _opaqueShader = Shader.Find(lilToonShaderNames.OpaqueShader);
                }
                return _opaqueShader;
            }
        }

        public static Shader CutoutShader
        {
            get
            {
                if (_cutoutShader == null)
                {
                    _cutoutShader = Shader.Find(lilToonShaderNames.CutoutShader);
                }
                return _cutoutShader;
            }
        }

        public static Shader TransparentShader
        {
            get
            {
                if (_transparentShader == null)
                {
                    _transparentShader = Shader.Find(lilToonShaderNames.TransparentShader);
                }
                return _transparentShader;
            }
        }

        public static Shader OpaqueOutlineShader
        {
            get
            {
                if (_opaqueOutlineShader == null)
                {
                    _opaqueOutlineShader = Shader.Find(lilToonShaderNames.OpaqueOutlineShader);
                }
                return _opaqueOutlineShader;
            }
        }

        public static Shader CutoutOutlineShader
        {
            get
            {
                if (_cutoutOutlineShader == null)
                {
                    _cutoutOutlineShader = Shader.Find(lilToonShaderNames.CutoutOutlineShader);
                }
                return _cutoutOutlineShader;
            }
        }

        public static Shader TransparentOutlineShader
        {
            get
            {
                if (_transparentOutlineShader == null)
                {
                    _transparentOutlineShader = Shader.Find(lilToonShaderNames.TransparentOutlineShader);
                }
                return _transparentOutlineShader;
            }
        }
    }
}
