using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using d3dfont = Microsoft.DirectX.Direct3D.Font;
using winfont = System.Drawing.Font;

namespace WheelOfLunch
{
	public partial class frmMain : Form
	{
		private Device m_d3ddev;
		private VertexBuffer m_vertices;
		private VertexBuffer m_indicator;
		private int lunchCount;
		private Mesh [] lunchfontMeshes;
		private SizeF [] meshBounds;// = new SizeF ();
		private float [,] mWinningAngles;
		private frmRestaurants RestForm;

		public frmMain ()
		{
			mAngle = 1.6f;
			mInc = 0.0f;
			lunchCount = 15;
			InitializeComponent ();
			RestForm = new frmRestaurants ();
		}

		private void frmMain_Shown (object sender, EventArgs e)
		{
			if (!RestForm.IsLoaded)
				RestForm.ShowDialog ();
//			try
			{
				Caps DevCaps = Manager.GetDeviceCaps (0, DeviceType.Hardware);
				CreateFlags DevFlags = CreateFlags.SoftwareVertexProcessing;
				if (DevCaps.DeviceCaps.SupportsHardwareTransformAndLight)
				{
					DevFlags = CreateFlags.HardwareVertexProcessing;
				}
				PresentParameters pparams = new PresentParameters ();
				pparams.Windowed = true;
				pparams.SwapEffect = SwapEffect.Discard;
				pparams.BackBufferCount = 1;
				pparams.EnableAutoDepthStencil = true;
				pparams.AutoDepthStencilFormat = DepthFormat.D16;
				pparams.BackBufferFormat = Format.Unknown;
				pparams.PresentFlag = PresentFlag.LockableBackBuffer;
				pparams.Windowed = true;
				pparams.SwapEffect = SwapEffect.Discard;
//				pparams.MultiSample = MultiSampleType.TwoSamples;
//				pparams.MultiSampleQuality = 2;

				m_d3ddev = new Device (0, DeviceType.Hardware, this, 
					DevFlags | CreateFlags.FpuPreserve, pparams);

				m_d3ddev.DeviceReset += new EventHandler (m_d3ddev_DeviceReset);
				m_d3ddev.DeviceLost += new EventHandler (m_d3ddev_DeviceLost);

				BuildRenderState ();
			}
//			catch (Exception ex)
			{
//				MessageBox.Show ("Unable to start up DirectX rendering. " + ex.Message);
//				Close ();
			}
		}

		void m_d3ddev_DeviceLost (object sender, EventArgs e)
		{
			if (false == m_d3ddev.CheckCooperativeLevel ())
				Application.Exit ();
		}

		void m_d3ddev_DeviceReset (object sender, EventArgs e)
		{
			BuildRenderState ();
		}

		private void BuildRenderState ()
		{
//			m_d3ddev.RenderState.Ambient = Color.FromArgb (0xf0, 0xf0, 0xf0);
//			m_d3ddev.RenderState.Ambient = Color.FromArgb (0, 0, 0);
			m_d3ddev.RenderState.Ambient = Color.FromArgb (0x80, 0x80, 0x80);
			m_d3ddev.VertexFormat = CustomVertex.PositionNormal.Format;
			m_d3ddev.RenderState.ZBufferEnable = true;
			m_d3ddev.RenderState.SourceBlend = Blend.One;
			m_d3ddev.RenderState.DestinationBlend = Blend.One;

			lunchfontMeshes = new Mesh [32];
			meshBounds = new SizeF [32];

			UpdateRestaurants ();

			rendertimer.Start ();
		}

		private SizeF ComputeMeshBounds (GlyphMetricsFloat [] glyphMetrics)
		{
			float maxx = 0;
			float maxy = 0;
			float offsety = 0;

			foreach (GlyphMetricsFloat gmf in glyphMetrics)
			{
				maxx += gmf.CellIncX;
				float y = offsety + gmf.BlackBoxX;

				if (y > maxy)
					maxy = y;

				offsety += gmf.CellIncY;
			}
			return new SizeF (maxx, maxy);
		}

		float mAngle;
		float mInc;
		int flicker;
		private void rendertimer_Tick (object sender, EventArgs e)
		{
			if (m_d3ddev == null)
				return;

			m_d3ddev.Clear (ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
			m_d3ddev.BeginScene ();

			m_d3ddev.RenderState.Lighting = true;
			m_d3ddev.RenderState.AlphaBlendEnable = false;

			Material mat = new Material ();
			mat.Diffuse = Color.Red;
			mat.Ambient = Color.Red;

			mAngle += mInc;
			mInc -= 0.001f;
			if (mInc < 0.0f)
				mInc = 0.0f;

			mAngle = NormalizeAngle (mAngle);

			//Text = "Angle: " + mAngle.ToString () + " Inc: " + mInc.ToString ();

			Matrix x = Matrix.Identity;

			float theta = (float)(Math.PI * (2.0 / (double)lunchCount));
			int motionblur = 0;
			int winner = -1;
//			for (motionblur = 0; motionblur < 1; ++motionblur)
			{
				for (int i = 0; i < lunchCount; ++i)
				{
					//detecting current winner
					float hackangle = NormalizeAngle (mAngle + (float)(Math.PI / 8.0));
					if (mWinningAngles [i, 0] <= hackangle &&
						mWinningAngles [i, 1] > hackangle)
						winner = i;

					//triangle
					x = Matrix.Identity;
//					x *= Matrix.Translation (0, 0, 0.01f * motionblur + -0.03f);
					x *= Matrix.Scaling (3.0f, 3.0f, 3.0f);
					x *= Matrix.RotationZ (mAngle + theta * i + (motionblur * -0.05f));
					m_d3ddev.SetTransform (TransformType.World, x);
					Color temp = MakeColor (i);
					//temp = Color.FromArgb ((motionblur + 15) * 255 / 16 - 16, temp);
					mat.Diffuse = temp;
					mat.Ambient = temp;
					m_d3ddev.Material = mat;
					
					m_d3ddev.VertexFormat = CustomVertex.PositionNormal.Format;
					m_d3ddev.SetStreamSource (0, m_vertices, 0);
					m_d3ddev.DrawPrimitives (PrimitiveType.TriangleList, 0, 1);

					//font
					x = Matrix.Scaling (0.35f, 0.35f, 0.75f);
					x *= Matrix.Translation (0.75f, -0.12f, 0.0f);
					x *= Matrix.RotationZ (mAngle + theta * i + (float)Math.PI / 2.0f);// + motionblur * -0.05f);
					m_d3ddev.SetTransform (TransformType.World, x);

					temp = MakeColor (i + 1);
//					temp = Color.FromArgb (motionblur * 255 / 6, MakeColor (i + 1));
					mat.Diffuse = temp;
					mat.Ambient = temp;
					m_d3ddev.Material = mat;
					lunchfontMeshes [i].DrawSubset (0);
				}
			}
			//Text += " current winner is " + winner.ToString ();

			m_d3ddev.RenderState.AlphaBlendEnable = false;

			//indicator
			x = Matrix.Scaling (0.25f, 0.25f, 0.25f);
			x *= Matrix.RotationZ (-(float)Math.PI / 4.0f);
			x *= Matrix.Translation (3.0f, 0.0f, 0.0f);
			m_d3ddev.SetTransform (TransformType.World, x);
			//mat.Diffuse = MakeColor (winner);
			//mat.Ambient = MakeColor (winner);
			mat.Diffuse = MakeColor (0);
			mat.Ambient = MakeColor (0);
			m_d3ddev.Material = mat;
			m_d3ddev.VertexFormat = CustomVertex.PositionNormal.Format;
			m_d3ddev.SetStreamSource (0, m_indicator, 0);
			m_d3ddev.DrawPrimitives (PrimitiveType.TriangleList, 0, 1);

			m_d3ddev.SetTransform (TransformType.World, Matrix.Identity);

			m_d3ddev.Lights [0].Type = LightType.Directional;
			m_d3ddev.Lights [0].Diffuse = Color.White;
			m_d3ddev.Lights [0].Direction = new Vector3 (0, 0, -10);
			m_d3ddev.Lights [0].Direction.Normalize ();
			m_d3ddev.Lights [0].Update ();
			m_d3ddev.Lights [0].Enabled =
				true;
				//flicker % 4 > 2;

			m_d3ddev.Lights [1].Type = LightType.Point;
			m_d3ddev.Lights [1].Diffuse = Color.White;
			m_d3ddev.Lights [1].Specular = Color.White;
			m_d3ddev.Lights [1].Position = new Vector3 (4, 0, -4);
			m_d3ddev.Lights [1].Attenuation0 = 0.0f;
			m_d3ddev.Lights [1].Attenuation1 = 0.75f;
			m_d3ddev.Lights [1].Attenuation2 = 0.0f;
			m_d3ddev.Lights [1].Range = 100;
			m_d3ddev.Lights [1].Enabled = 
				true;
				//flicker % 10 > 5;
			++flicker;

			Matrix matView = Matrix.LookAtLH (
				new Vector3 (0, 0, -10),
				new Vector3 (0, 0, 0),
				new Vector3 (0, 1, 0));
			m_d3ddev.SetTransform (TransformType.View, matView);

			Matrix matProj = Matrix.PerspectiveFovLH (
				(float)Math.PI / 4,
				Width / Height,
				0.1f,
				1000.0f);
			m_d3ddev.SetTransform (TransformType.Projection, matProj);

			try
			{
				m_d3ddev.EndScene ();
				m_d3ddev.Present ();
			}
			catch (Exception ex)
			{
				MessageBox.Show ("An error occured while trying to present the direct3d scene: " + ex.Message);
			}
		}

		private float NormalizeAngle (float angle)
		{
			while (angle >= (float)(Math.PI * 2.0))
				angle -= (float)(Math.PI * 2.0);
			while (angle < 0.0f)
				angle += (float)(Math.PI * 2.0);
			return angle;
		}

		private Color MakeColor (int code)
		{
			switch (code % 8)
			{
				case 0:
					return Color.Red;

				case 1:
					return Color.Blue;

				case 2:
					return Color.Green;

				case 3:
					return Color.Gold;

				case 4:
					return Color.Silver;

				case 5:
					return Color.Aquamarine;

				case 6:
					return Color.Violet;

				case 7:
					return Color.Lime;
			}

			return Color.White;
		}

		private void btnSpin_Click (object sender, EventArgs e)
		{
			Random rnd = new Random ();
			double randomnum = rnd.NextDouble ();

			mInc = 0.3f + (float)((randomnum - 0.5) / 10.0);
		}

		private void btnRestaurants_Click (object sender, EventArgs e)
		{
			RestForm.ShowDialog ();
			UpdateRestaurants ();
		}

		private void UpdateRestaurants ()
		{
			lunchCount = RestForm.restaurantCount;
			string [] restaurants = RestForm.restaurantNames;

			for (int dest = 0, src = 0; dest < lunchCount; ++src, ++dest)
			{
				try
				{
					GlyphMetricsFloat [] glyphMetrics = new GlyphMetricsFloat [restaurants [src].Length];
					lunchfontMeshes [dest] = Mesh.TextFromFont (
						m_d3ddev,
						new winfont (FontFamily.GenericSansSerif, 1),
						restaurants [src],
						0.01f,
						0.25f,
						out glyphMetrics);

					meshBounds [dest] = ComputeMeshBounds (glyphMetrics);
				}
				catch (Exception)
				{
					//ignore exceptions
					--dest;
					--lunchCount;
				}
			}


			//restaurant slices
			m_d3ddev.VertexFormat = CustomVertex.PositionNormal.Format;
			CustomVertex.PositionNormal [] verts = new CustomVertex.PositionNormal [3];
			double theta = (float)((Math.PI * 2.0) / lunchCount) / 2.0f;
			verts [0] = new CustomVertex.PositionNormal (
				0.0f, 0.0f, 0.0f,
				0.0f, 0.0f, 1.0f);
			verts [1] = new CustomVertex.PositionNormal (
				(float)Math.Sin (-theta), (float)Math.Cos (-theta), 0.0f,
				0.0f, 0.0f, 1.0f);
			verts [2] = new CustomVertex.PositionNormal (
				(float)Math.Sin (theta), (float)Math.Cos (theta), 0.0f,
				0.0f, 0.0f, 1.0f);

			m_vertices = new VertexBuffer (
				typeof (CustomVertex.PositionNormal),
				verts.Length,
				m_d3ddev, 0,
				CustomVertex.PositionNormal.Format,
				Pool.Default);

			GraphicsStream stm = m_vertices.Lock (0, 0, 0);
			stm.Write (verts);
			m_vertices.Unlock ();

			//indicator
			CustomVertex.PositionNormal [] indic_verts = new CustomVertex.PositionNormal [3];
			indic_verts [0] = new CustomVertex.PositionNormal (
				0.0f, 0.0f, 0.0f,
				0.0f, 0.0f, 1.0f);
			indic_verts [1] = new CustomVertex.PositionNormal (
				0.0f, 1.0f, 0.0f,
				0.0f, 0.0f, 1.0f);
			indic_verts [2] = new CustomVertex.PositionNormal (
				1.0f, 0.0f, 0.0f,
				0.0f, 0.0f, 1.0f);

			m_indicator = new VertexBuffer (
				typeof (CustomVertex.PositionNormal),
				indic_verts.Length,
				m_d3ddev, 0,
				CustomVertex.PositionNormal.Format,
				Pool.Default);

			GraphicsStream indic_stm = m_indicator.Lock (0, 0, 0);
			indic_stm.Write (indic_verts);
			m_indicator.Unlock ();

			mWinningAngles = new float [lunchCount, 2];
			for (int i = lunchCount - 1; i >= 0; --i)
			{
				mWinningAngles [i, 0] = (float)(theta * (lunchCount - i - 1) * 2);
				mWinningAngles [i, 1] = (float)(theta * (lunchCount - i) * 2);
			}
			//Color x = MakeColor (2);
		}
	}
}