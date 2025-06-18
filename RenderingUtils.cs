using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Utilities.Rendering
{
	public static class RenderingUtils
	{

		public static void SetLayerRecursive(Transform root, int layer)
		{
			if (root == null) return;

			root.gameObject.layer = layer;

			foreach (Transform child in root)
			{
				SetLayerRecursive(child, layer);
			}
		}


        public static void ToggleMeshRendererRecursive(Transform p, bool enable)
        {
            MeshRenderer meshRenderer = p.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
                meshRenderer.enabled = enable;

            SkinnedMeshRenderer skinnedRenderer = p.GetComponent<SkinnedMeshRenderer>();
            if (skinnedRenderer != null)
                skinnedRenderer.enabled = enable;

            foreach (Transform child in p)
            {
                ToggleMeshRendererRecursive(child, enable);
            }
        }

        public static bool IsMeshRendererEnabled(Transform p)
        {
            MeshRenderer meshRenderer = p.GetComponent<MeshRenderer>();
            if (meshRenderer != null && !meshRenderer.enabled)
                return false;

            SkinnedMeshRenderer skinnedRenderer = p.GetComponent<SkinnedMeshRenderer>();
            if (skinnedRenderer != null && !skinnedRenderer.enabled)
                return false;

            foreach (Transform child in p)
            {
                if (!IsMeshRendererEnabled(child))
                    return false;
            }

            return true;
        }

        public static void SetAlphaRecursive(Transform p, float alpha)
        {
            foreach (Transform child in p)
            {
                MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    foreach (Material mat in meshRenderer.materials)
                    {
                        Color color = mat.color;
                        color.a = alpha;
                        mat.color = color;
                    }
                }

                SetAlphaRecursive(child, alpha);
            }
        }

        public static void SetRecursiveColor(Transform p, Color color)
        {
            // Apply color to the parent (this transform) if it has a MaskableGraphic
            MaskableGraphic mg = p.GetComponent<MaskableGraphic>();
            if (mg != null)
            {
                mg.color = color;
            }

            foreach (Transform child in p)
            {
                SetRecursiveColor(child, color);
            }
        }
    }
}
