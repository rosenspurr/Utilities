using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Utilities.Rendering
{
	public static class RenderingUtils
	{
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
			foreach (Transform child in p)
			{
				MaskableGraphic mg = child.GetComponent<MaskableGraphic>();
				if (mg != null)
				{
					mg.color = color;
				}

				SetRecursiveColor(child, color);
			}
		}
	}
}

