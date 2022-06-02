using UnityEngine;

public class PostRenderFog : MonoBehaviour
{
	public Material m_depthFogMat;
	public Color m_fogColor;
	public float m_fogStart;
	public float m_fogEnd;

	private Camera _camera;
	private RenderTexture m_cameraRenderTex;

	private int MatHash_Ray;
	private int MatHash_FogColor;
	private int MatHash_FogStart;
	private int MatHash_FogEnd;

	// Start is called before the first frame update
	void Awake()
	{
		_camera = Camera.main;
		if (_camera)
		{
			_camera.depthTextureMode = DepthTextureMode.Depth;
		}
		if (m_depthFogMat)
		{
			MatHash_Ray = Shader.PropertyToID("_Ray");
			MatHash_FogColor = Shader.PropertyToID("_FogColor");
			MatHash_FogStart = Shader.PropertyToID("_FogStart");
			MatHash_FogEnd = Shader.PropertyToID("_FogEnd");
		}
	}

	private void OnPreRender()
	{
		if (!_camera)
			return;
		if (QualitySettings.antiAliasing == 0)
		{
			m_cameraRenderTex = RenderTexture.GetTemporary(Screen.width, Screen.height, 24, RenderTextureFormat.Default, RenderTextureReadWrite.Default);
		}
		else
		{
			m_cameraRenderTex = RenderTexture.GetTemporary(Screen.width, Screen.height, 24, RenderTextureFormat.Default, RenderTextureReadWrite.Default, QualitySettings.antiAliasing);
		}
		_camera.targetTexture = m_cameraRenderTex;
		SetMaterialProperties();
	}

	private void OnPostRender()
	{
		if (m_depthFogMat)
		{
			Graphics.Blit(m_cameraRenderTex, null as RenderTexture, m_depthFogMat);
		}
		else
		{
			Graphics.Blit(m_cameraRenderTex, null as RenderTexture);
		}

		RenderTexture.ReleaseTemporary(m_cameraRenderTex);
		_camera.targetTexture = null;
	}

	/// <summary>
	/// 设置材质球需要的属性值
	/// </summary>
	private void SetMaterialProperties()
	{
		if (_camera)
		{
			var aspect = _camera.aspect;        // 屏幕宽高比
			var far = _camera.farClipPlane;     // 摄像机裁剪最远距离
			var trans = _camera.transform;
			var upDir = trans.up;
			var forwardDir = trans.forward;
			var rightDir = trans.right;

			var halfOfHeight = Mathf.Tan(_camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * far;
			var halfOfWidth = halfOfHeight * aspect;
			var upVec = upDir * halfOfHeight;
			var forwardVec = forwardDir * far;
			var rightVec = rightDir * halfOfWidth;

			var bl = forwardVec - upVec - rightVec;     // 裁剪空间远端左下角顶点
			var tl = forwardVec + upVec - rightVec;     // 裁剪空间远端左上角顶点
			var tr = forwardVec + upVec + rightVec;     // 裁剪空间远端右上角顶点
			var br = forwardVec - upVec - rightVec;     // 裁剪空间远端右下角顶点

			var ray = Matrix4x4.identity;
			ray.SetRow(0, bl);
			ray.SetRow(1, tl);
			ray.SetRow(2, tr);
			ray.SetRow(3, br);

			if (m_depthFogMat != null)
			{
				m_depthFogMat.SetMatrix(MatHash_Ray, ray);
				m_depthFogMat.SetColor(MatHash_FogColor, m_fogColor);
				m_depthFogMat.SetFloat(MatHash_FogStart, m_fogStart);
				m_depthFogMat.SetFloat(MatHash_FogEnd, m_fogEnd);
			}
		}
	}
}