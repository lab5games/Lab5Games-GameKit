using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lab5Games.UI
{
    // https://qiita.com/rarudonet/items/52de2fd3a47b6e0a2b1f

    [ExecuteAlways, DisallowMultipleComponent]
    [RequireComponent(typeof(Graphic))]
    public class UISaturation : UIBehaviour, IMaterialModifier
    {
        [SerializeField]
        private float m_saturation = 1f;
        public float saturation
        {
            get => m_saturation;
            set => m_saturation = value;
        }

        
        private Graphic m_graphic = null;
        public Graphic graphic
        {
            get
            {
                if (m_graphic == null)
                    m_graphic = GetComponent<Graphic>();

                return m_graphic;
            }
        }

        private Material m_saturationMaterial = null;

        public readonly int SaturationPropertyId = Shader.PropertyToID("_Saturation");

        protected override void OnEnable()
        {
            base.OnEnable();
            
            graphic.SetMaterialDirty();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            if (m_saturationMaterial != null)
                DestroyImmediate(m_saturationMaterial);

            m_saturationMaterial = null;

            graphic.SetMaterialDirty();
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            if(IsActive())
            {
                graphic.SetMaterialDirty();
            }
        }
#endif

        protected override void OnDidApplyAnimationProperties()
        {
            base.OnDidApplyAnimationProperties();

            if(IsActive())
            {
                graphic.SetMaterialDirty();
            }
        }

        public Material GetModifiedMaterial(Material baseMaterial)
        {
            if (IsActive() == false || m_graphic == null || !baseMaterial.HasProperty(SaturationPropertyId))
                return baseMaterial;


            // copy material
            if(m_saturationMaterial == null)
            {
                m_saturationMaterial = new Material(baseMaterial);
                m_saturationMaterial.hideFlags = HideFlags.HideAndDontSave;
            }

            m_saturationMaterial.CopyPropertiesFromMaterial(baseMaterial);
            m_saturationMaterial.SetFloat(SaturationPropertyId, m_saturation);

            return m_saturationMaterial;
        }
    }
}
