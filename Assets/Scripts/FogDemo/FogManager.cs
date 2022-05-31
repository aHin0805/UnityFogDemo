using System;
using UnityEngine;

public class FogManager : MonoBehaviour
{
	public GameObject[] m_bgObjs;

	private float m_linearFogStart = 0;
	private float m_linearFogEnd = 0;

	private float m_expFogDensity = 0;

	private bool m_showBG = false;

	// Start is called before the first frame update
	void Start()
	{
		RenderSettings.fog = false;
		m_linearFogStart = RenderSettings.fogStartDistance;
		m_linearFogEnd = RenderSettings.fogEndDistance;
		m_expFogDensity = RenderSettings.fogDensity;
		foreach (var obj in m_bgObjs)
		{
			obj.SetActive(m_showBG);
		}
	}

	private void OnGUI()
	{
		DrawFogControl();
	}

	private void DrawFogControl()
	{
		GUILayout.BeginArea(new Rect(10, 10, 200, 200));
		if (GUILayout.Button(FogButton()))
		{
			RenderSettings.fog = !RenderSettings.fog;
		}
		if (GUILayout.Button(BgButton()))
		{
			m_showBG = !m_showBG;
			foreach (var obj in m_bgObjs)
			{
				obj.SetActive(m_showBG);
			}
		}
		if (RenderSettings.fog)
		{
			GUILayout.Label(FogModeName());
			if (GUILayout.Button("线性雾"))
			{
				RenderSettings.fogMode = FogMode.Linear;
			}
			if (GUILayout.Button("指数雾"))
			{
				RenderSettings.fogMode = FogMode.Exponential;
			}
			if (GUILayout.Button("指数平方雾"))
			{
				RenderSettings.fogMode = FogMode.ExponentialSquared;
			}
			DrawLinearFogGUI();
			DrawExpFogGUI();
			DrawExp2FogGUI();
		}
		GUILayout.EndArea();
	}

	private string FogButton()
	{
		if (RenderSettings.fog)
		{
			return "关闭雾效";
		}
		else
		{
			return "开启雾效";
		}
	}

	private string BgButton()
	{
		if (m_showBG)
		{
			return "隐藏背景";
		}
		else
		{
			return "显示背景";
		}
	}

	private string FogModeName()
	{
		switch (RenderSettings.fogMode)
		{
			case UnityEngine.FogMode.Linear:
				return "线性雾";
			case UnityEngine.FogMode.Exponential:
				return "指数";
			case UnityEngine.FogMode.ExponentialSquared:
				return "指数平方";
		}
		return "";
	}

	private void DrawLinearFogGUI()
	{
		if (RenderSettings.fog && RenderSettings.fogMode == FogMode.Linear)
		{
			// 可调整距离
			DrawGUIVerticalLayout(() =>
			{
				DrawGUIHorizonLayout(() =>
				{
					GUILayout.Label("开始");
					float.TryParse(GUILayout.TextField(m_linearFogStart.ToString()), out m_linearFogStart);
				});
				DrawGUIHorizonLayout(() =>
				{
					GUILayout.Label("结束");
					float.TryParse(GUILayout.TextField(m_linearFogEnd.ToString()), out m_linearFogEnd);
				});
			});
			m_linearFogStart = Mathf.Max(0, m_linearFogStart);
			m_linearFogEnd = Mathf.Max(m_linearFogStart, m_linearFogEnd);
			RenderSettings.fogStartDistance = m_linearFogStart;
			RenderSettings.fogEndDistance = m_linearFogEnd;
		}
	}

	private void DrawExpFogGUI()
	{
		if (RenderSettings.fog && RenderSettings.fogMode == FogMode.Exponential)
		{
			DrawGUIHorizonLayout(() =>
			{
				GUILayout.Label("Density");
				float.TryParse(GUILayout.TextField(m_expFogDensity.ToString()), out m_expFogDensity);
			});
			m_expFogDensity = Mathf.Clamp01(m_expFogDensity);
			RenderSettings.fogDensity = m_expFogDensity;
		}
	}

	private void DrawExp2FogGUI()
	{
		if (RenderSettings.fog && RenderSettings.fogMode == FogMode.ExponentialSquared)
		{
			DrawGUIHorizonLayout(() =>
			{
				GUILayout.Label("Density");
				float.TryParse(GUILayout.TextField(m_expFogDensity.ToString()), out m_expFogDensity);
			});
			m_expFogDensity = Mathf.Clamp01(m_expFogDensity);
			RenderSettings.fogDensity = m_expFogDensity;
		}
	}

	private void DrawGUIHorizonLayout(Action action)
	{
		if (action != null)
		{
			GUILayout.BeginHorizontal();
			action();
			GUILayout.EndHorizontal();
		}
	}

	private void DrawGUIVerticalLayout(Action action)
	{
		if (action != null)
		{
			GUILayout.BeginVertical();
			action();
			GUILayout.EndVertical();
		}
	}

	/*
	private void FogSettings()
	{
		// 开启/关闭雾效
		RenderSettings.fog = true;
		// 雾效颜色
		RenderSettings.fogColor = Color.red;
		// 选择雾效模式
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogMode = FogMode.Exponential;
		RenderSettings.fogMode = FogMode.ExponentialSquared;

		// 雾效开始、结束的摄像机距离，线性模式下使用
		RenderSettings.fogStartDistance = 0;
		RenderSettings.fogEndDistance = 100;

		// 雾效浓度，指数和指数平方两种模式下使用，范围为0~1的浮点值，数值越大，雾效浓度越强
		RenderSettings.fogDensity = 1;
	}
	*/
}