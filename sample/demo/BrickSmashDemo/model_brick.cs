/* PlayStation(R)Mobile SDK 1.21.01
 * Copyright (C) 2013 Sony Computer Entertainment Inc.
 * All Rights Reserved.
 */

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

namespace Demo_BrickSmash
{
	public class ModelBrick
	{
		ShaderProgram program;
		VertexBuffer vertices;
		Texture2D texture;

		public ModelBrick()
		{
			program = new ShaderProgram("/Application/shaders/main.cgx");
			vertices = new VertexBuffer(3*numTriangles_ModelBrick, VertexFormat.Float3, VertexFormat.Float3, VertexFormat.Float2);
			texture = new Texture2D("/Application/data/ball.png", false);
	
			program.SetUniformBinding(0, "projViewMatrix");
			program.SetUniformBinding(1, "lightVector");
			program.SetUniformBinding(2, "vertexColor");
			program.SetAttributeBinding(0, "a_Position");
			program.SetAttributeBinding(1, "a_Normal");
			program.SetAttributeBinding(2, "a_TexCoord");
	
			vertices.SetVertices(0, fVertices_ModelBrick);
			vertices.SetVertices(1, fNormals_ModelBrick);
			vertices.SetVertices(2, fTexcoords_ModelBrick);
		}
	
		public void Dispose()
		{
			program.Dispose();
			vertices.Dispose();
			texture.Dispose();
		}

		public void Render(GraphicsContext graphics, ref Matrix4 matrix, ref Vector3 vector, ref Vector4 color)
		{
			program.SetUniformValue(0, ref matrix);
			program.SetUniformValue(1, ref vector);
			program.SetUniformValue(2, ref color);
	
			graphics.SetShaderProgram(program);
			graphics.SetVertexBuffer(0, vertices);
	
			graphics.SetTexture(0, texture);
			graphics.DrawArrays(DrawMode.Triangles, 0, 3*numTriangles_ModelBrick);
		}

		static int numTriangles_ModelBrick = 68;

		static float[] fVertices_ModelBrick = {
			1.00000000f, -0.44822800f, 0.37501201f,
			1.00000000f, -0.44822800f, -0.44822800f,
			1.00000000f, 0.37501201f, -0.44822800f,
			0.94822800f, -0.44822800f, -0.50000000f,
			-0.78069198f, -0.44822800f, -0.50000000f,
			0.94822800f, 0.41623199f, -0.50000000f,
			-0.94822800f, -0.41623199f, -0.50000000f,
			-0.94822800f, 0.44822800f, -0.50000000f,
			0.78069198f, 0.44822800f, -0.50000000f,
			-0.78069198f, 0.50000000f, -0.44822800f,
			0.94822800f, 0.50000000f, 0.41623199f,
			0.94822800f, 0.50000000f, -0.44822800f,
			1.00000000f, 0.44822800f, 0.44822800f,
			1.00000000f, -0.37501201f, 0.44822800f,
			1.00000000f, 0.44822800f, -0.37501201f,
			-0.94822800f, -0.50000000f, 0.41623199f,
			-0.94822800f, -0.50000000f, -0.44822800f,
			0.78069198f, -0.50000000f, -0.44822800f,
			0.94822800f, -0.50000000f, 0.44822800f,
			-0.78069198f, -0.50000000f, 0.44822800f,
			0.94822800f, -0.50000000f, -0.41623199f,
			-1.00000000f, 0.44822800f, 0.37501201f,
			-1.00000000f, 0.44822800f, -0.44822800f,
			-1.00000000f, -0.37501201f, -0.44822800f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-1.00000000f, 0.37501201f, 0.44822800f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-0.94822800f, 0.50000000f, 0.44822800f,
			0.78069198f, 0.50000000f, 0.44822800f,
			-0.94822800f, 0.50000000f, -0.41623199f,
			-0.94822800f, 0.44822800f, 0.50000000f,
			-0.94822800f, -0.41623199f, 0.50000000f,
			0.78069198f, 0.44822800f, 0.50000000f,
			-0.78069198f, -0.44822800f, 0.50000000f,
			0.94822800f, -0.44822800f, 0.50000000f,
			0.94822800f, 0.41623199f, 0.50000000f,
			1.00000000f, 0.37501201f, -0.44822800f,
			1.00000000f, 0.44822800f, -0.37501201f,
			1.00000000f, -0.37501201f, 0.44822800f,
			1.00000000f, -0.37501201f, 0.44822800f,
			1.00000000f, -0.44822800f, 0.37501201f,
			1.00000000f, 0.37501201f, -0.44822800f,
			0.94822800f, 0.41623199f, -0.50000000f,
			1.00000000f, 0.37501201f, -0.44822800f,
			1.00000000f, -0.44822800f, -0.44822800f,
			1.00000000f, -0.44822800f, -0.44822800f,
			0.94822800f, -0.44822800f, -0.50000000f,
			0.94822800f, 0.41623199f, -0.50000000f,
			0.78069198f, 0.44822800f, -0.50000000f,
			0.94822800f, 0.41623199f, -0.50000000f,
			-0.78069198f, -0.44822800f, -0.50000000f,
			-0.78069198f, -0.44822800f, -0.50000000f,
			-0.94822800f, -0.41623199f, -0.50000000f,
			0.78069198f, 0.44822800f, -0.50000000f,
			0.94822800f, 0.50000000f, -0.44822800f,
			0.78069198f, 0.44822800f, -0.50000000f,
			-0.94822800f, 0.44822800f, -0.50000000f,
			-0.94822800f, 0.44822800f, -0.50000000f,
			-0.78069198f, 0.50000000f, -0.44822800f,
			0.94822800f, 0.50000000f, -0.44822800f,
			1.00000000f, 0.44822800f, -0.37501201f,
			0.94822800f, 0.50000000f, -0.44822800f,
			0.94822800f, 0.50000000f, 0.41623199f,
			0.94822800f, 0.50000000f, 0.41623199f,
			1.00000000f, 0.44822800f, 0.44822800f,
			1.00000000f, 0.44822800f, -0.37501201f,
			0.78069198f, -0.50000000f, -0.44822800f,
			0.94822800f, -0.50000000f, -0.41623199f,
			-0.78069198f, -0.50000000f, 0.44822800f,
			-0.78069198f, -0.50000000f, 0.44822800f,
			-0.94822800f, -0.50000000f, 0.41623199f,
			0.78069198f, -0.50000000f, -0.44822800f,
			0.94822800f, -0.44822800f, -0.50000000f,
			0.78069198f, -0.50000000f, -0.44822800f,
			-0.94822800f, -0.50000000f, -0.44822800f,
			-0.94822800f, -0.50000000f, -0.44822800f,
			-0.78069198f, -0.44822800f, -0.50000000f,
			0.94822800f, -0.44822800f, -0.50000000f,
			0.94822800f, -0.50000000f, -0.41623199f,
			1.00000000f, -0.44822800f, -0.44822800f,
			1.00000000f, -0.44822800f, 0.37501201f,
			1.00000000f, -0.44822800f, 0.37501201f,
			0.94822800f, -0.50000000f, 0.44822800f,
			0.94822800f, -0.50000000f, -0.41623199f,
			-1.00000000f, -0.37501201f, -0.44822800f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-1.00000000f, 0.37501201f, 0.44822800f,
			-1.00000000f, 0.37501201f, 0.44822800f,
			-1.00000000f, 0.44822800f, 0.37501201f,
			-1.00000000f, -0.37501201f, -0.44822800f,
			-0.94822800f, -0.41623199f, -0.50000000f,
			-1.00000000f, -0.37501201f, -0.44822800f,
			-1.00000000f, 0.44822800f, -0.44822800f,
			-1.00000000f, 0.44822800f, -0.44822800f,
			-0.94822800f, 0.44822800f, -0.50000000f,
			-0.94822800f, -0.41623199f, -0.50000000f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-0.94822800f, -0.50000000f, -0.44822800f,
			-0.94822800f, -0.50000000f, 0.41623199f,
			-0.94822800f, -0.50000000f, 0.41623199f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-0.78069198f, 0.50000000f, -0.44822800f,
			-0.94822800f, 0.50000000f, -0.41623199f,
			0.78069198f, 0.50000000f, 0.44822800f,
			0.78069198f, 0.50000000f, 0.44822800f,
			0.94822800f, 0.50000000f, 0.41623199f,
			-0.78069198f, 0.50000000f, -0.44822800f,
			-0.94822800f, 0.50000000f, -0.41623199f,
			-1.00000000f, 0.44822800f, -0.44822800f,
			-1.00000000f, 0.44822800f, 0.37501201f,
			-1.00000000f, 0.44822800f, 0.37501201f,
			-0.94822800f, 0.50000000f, 0.44822800f,
			-0.94822800f, 0.50000000f, -0.41623199f,
			0.78069198f, 0.44822800f, 0.50000000f,
			0.78069198f, 0.50000000f, 0.44822800f,
			-0.94822800f, 0.50000000f, 0.44822800f,
			-0.94822800f, 0.50000000f, 0.44822800f,
			-0.94822800f, 0.44822800f, 0.50000000f,
			0.78069198f, 0.44822800f, 0.50000000f,
			0.94822800f, 0.41623199f, 0.50000000f,
			0.78069198f, 0.44822800f, 0.50000000f,
			-0.94822800f, -0.41623199f, 0.50000000f,
			-0.94822800f, -0.41623199f, 0.50000000f,
			-0.78069198f, -0.44822800f, 0.50000000f,
			0.94822800f, 0.41623199f, 0.50000000f,
			1.00000000f, 0.44822800f, 0.44822800f,
			0.94822800f, 0.41623199f, 0.50000000f,
			0.94822800f, -0.44822800f, 0.50000000f,
			0.94822800f, -0.44822800f, 0.50000000f,
			1.00000000f, -0.37501201f, 0.44822800f,
			1.00000000f, 0.44822800f, 0.44822800f,
			-0.94822800f, 0.44822800f, 0.50000000f,
			-1.00000000f, 0.37501201f, 0.44822800f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-0.94822800f, -0.41623199f, 0.50000000f,
			-0.94822800f, 0.44822800f, 0.50000000f,
			-0.78069198f, -0.44822800f, 0.50000000f,
			-0.78069198f, -0.50000000f, 0.44822800f,
			0.94822800f, -0.50000000f, 0.44822800f,
			0.94822800f, -0.50000000f, 0.44822800f,
			0.94822800f, -0.44822800f, 0.50000000f,
			-0.78069198f, -0.44822800f, 0.50000000f,
			1.00000000f, 0.44822800f, -0.37501201f,
			1.00000000f, 0.37501201f, -0.44822800f,
			0.94822800f, 0.41623199f, -0.50000000f,
			0.94822800f, 0.41623199f, -0.50000000f,
			0.78069198f, 0.44822800f, -0.50000000f,
			1.00000000f, 0.44822800f, -0.37501201f,
			1.00000000f, 0.44822800f, -0.37501201f,
			0.78069198f, 0.44822800f, -0.50000000f,
			0.94822800f, 0.50000000f, -0.44822800f,
			0.94822800f, -0.50000000f, -0.41623199f,
			0.78069198f, -0.50000000f, -0.44822800f,
			0.94822800f, -0.44822800f, -0.50000000f,
			0.94822800f, -0.44822800f, -0.50000000f,
			1.00000000f, -0.44822800f, -0.44822800f,
			0.94822800f, -0.50000000f, -0.41623199f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-1.00000000f, -0.37501201f, -0.44822800f,
			-0.94822800f, -0.41623199f, -0.50000000f,
			-0.94822800f, -0.41623199f, -0.50000000f,
			-0.78069198f, -0.44822800f, -0.50000000f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-1.00000000f, -0.44822800f, -0.37501201f,
			-0.78069198f, -0.44822800f, -0.50000000f,
			-0.94822800f, -0.50000000f, -0.44822800f,
			-0.94822800f, 0.50000000f, -0.41623199f,
			-0.78069198f, 0.50000000f, -0.44822800f,
			-0.94822800f, 0.44822800f, -0.50000000f,
			-0.94822800f, 0.44822800f, -0.50000000f,
			-1.00000000f, 0.44822800f, -0.44822800f,
			-0.94822800f, 0.50000000f, -0.41623199f,
			0.94822800f, 0.50000000f, 0.41623199f,
			0.78069198f, 0.50000000f, 0.44822800f,
			0.78069198f, 0.44822800f, 0.50000000f,
			0.78069198f, 0.44822800f, 0.50000000f,
			0.94822800f, 0.41623199f, 0.50000000f,
			0.94822800f, 0.50000000f, 0.41623199f,
			0.94822800f, 0.50000000f, 0.41623199f,
			0.94822800f, 0.41623199f, 0.50000000f,
			1.00000000f, 0.44822800f, 0.44822800f,
			-0.94822800f, 0.50000000f, 0.44822800f,
			-1.00000000f, 0.44822800f, 0.37501201f,
			-1.00000000f, 0.37501201f, 0.44822800f,
			-1.00000000f, 0.37501201f, 0.44822800f,
			-0.94822800f, 0.44822800f, 0.50000000f,
			-0.94822800f, 0.50000000f, 0.44822800f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-0.94822800f, -0.50000000f, 0.41623199f,
			-0.78069198f, -0.50000000f, 0.44822800f,
			-0.78069198f, -0.50000000f, 0.44822800f,
			-0.78069198f, -0.44822800f, 0.50000000f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-1.00000000f, -0.44822800f, 0.44822800f,
			-0.78069198f, -0.44822800f, 0.50000000f,
			-0.94822800f, -0.41623199f, 0.50000000f,
			0.94822800f, -0.50000000f, 0.44822800f,
			1.00000000f, -0.44822800f, 0.37501201f,
			1.00000000f, -0.37501201f, 0.44822800f,
			1.00000000f, -0.37501201f, 0.44822800f,
			0.94822800f, -0.44822800f, 0.50000000f,
			0.94822800f, -0.50000000f, 0.44822800f,
		};

		static float[] fNormals_ModelBrick = {
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			1.00000000f, 0.00000000f, 0.00000000f,
			0.64489198f, 0.24507700f, -0.72391403f,
			0.64489198f, 0.24507700f, -0.72391403f,
			0.70710701f, 0.00000000f, -0.70710701f,
			0.70710701f, 0.00000000f, -0.70710701f,
			0.70710701f, 0.00000000f, -0.70710701f,
			0.64489198f, 0.24507700f, -0.72391403f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.00000000f, -1.00000000f,
			0.00000000f, 0.70710599f, -0.70710701f,
			0.00000000f, 0.70710599f, -0.70710701f,
			-0.09958700f, 0.77953100f, -0.61839598f,
			-0.09958700f, 0.77953100f, -0.61839598f,
			-0.09958700f, 0.77953100f, -0.61839598f,
			0.00000000f, 0.70710599f, -0.70710701f,
			0.70710599f, 0.70710802f, 0.00000000f,
			0.70710599f, 0.70710802f, 0.00000000f,
			0.70710599f, 0.70710802f, 0.00000000f,
			0.70710599f, 0.70710802f, 0.00000000f,
			0.70710599f, 0.70710802f, 0.00000000f,
			0.70710599f, 0.70710802f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.00000000f, -1.00000000f, 0.00000000f,
			0.09958700f, -0.77953100f, -0.61839598f,
			0.09958700f, -0.77953100f, -0.61839598f,
			0.00000000f, -0.70710701f, -0.70710701f,
			0.00000000f, -0.70710701f, -0.70710701f,
			0.00000000f, -0.70710701f, -0.70710701f,
			0.09958700f, -0.77953100f, -0.61839598f,
			0.70710701f, -0.70710701f, 0.00000000f,
			0.70710701f, -0.70710701f, 0.00000000f,
			0.70710701f, -0.70710701f, 0.00000000f,
			0.70710701f, -0.70710701f, 0.00000000f,
			0.70710701f, -0.70710701f, 0.00000000f,
			0.70710701f, -0.70710701f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-1.00000000f, 0.00000000f, 0.00000000f,
			-0.64489198f, -0.24507700f, -0.72391403f,
			-0.64489198f, -0.24507700f, -0.72391403f,
			-0.70710701f, 0.00000000f, -0.70710701f,
			-0.70710701f, 0.00000000f, -0.70710701f,
			-0.70710701f, 0.00000000f, -0.70710701f,
			-0.64489198f, -0.24507700f, -0.72391403f,
			-0.70710599f, -0.70710802f, 0.00000000f,
			-0.70710599f, -0.70710802f, 0.00000000f,
			-0.70710599f, -0.70710802f, 0.00000000f,
			-0.70710599f, -0.70710802f, 0.00000000f,
			-0.70710599f, -0.70710802f, 0.00000000f,
			-0.70710599f, -0.70710802f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			0.00000000f, 1.00000000f, 0.00000000f,
			-0.70710701f, 0.70710701f, 0.00000000f,
			-0.70710701f, 0.70710701f, 0.00000000f,
			-0.70710701f, 0.70710701f, 0.00000000f,
			-0.70710701f, 0.70710701f, 0.00000000f,
			-0.70710701f, 0.70710701f, 0.00000000f,
			-0.70710701f, 0.70710701f, 0.00000000f,
			0.07764000f, 0.70497203f, 0.70497203f,
			0.07764000f, 0.70497203f, 0.70497203f,
			0.00000000f, 0.70710701f, 0.70710701f,
			0.00000000f, 0.70710701f, 0.70710701f,
			0.00000000f, 0.70710701f, 0.70710701f,
			0.07764000f, 0.70497203f, 0.70497203f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.00000000f, 0.00000000f, 1.00000000f,
			0.70710701f, 0.00000000f, 0.70710701f,
			0.70710701f, 0.00000000f, 0.70710701f,
			0.70710701f, 0.00000000f, 0.70710701f,
			0.70710701f, 0.00000000f, 0.70710701f,
			0.70710701f, 0.00000000f, 0.70710701f,
			0.70710701f, 0.00000000f, 0.70710701f,
			-0.70710701f, 0.00000000f, 0.70710701f,
			-0.70710701f, 0.00000000f, 0.70710701f,
			-0.70710701f, 0.00000000f, 0.70710701f,
			-0.70710701f, 0.00000000f, 0.70710701f,
			-0.70710701f, 0.00000000f, 0.70710701f,
			-0.70710701f, 0.00000000f, 0.70710701f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			0.00000000f, -0.70710701f, 0.70710701f,
			0.00000000f, -0.70710701f, 0.70710701f,
			0.00000000f, -0.70710701f, 0.70710701f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			0.54126602f, 0.47441599f, -0.69423401f,
			0.64489198f, 0.24507700f, -0.72391403f,
			0.64489198f, 0.24507700f, -0.72391403f,
			0.64489198f, 0.24507700f, -0.72391403f,
			0.54126602f, 0.47441599f, -0.69423401f,
			0.54126602f, 0.47441599f, -0.69423401f,
			0.54126602f, 0.47441599f, -0.69423401f,
			0.54126602f, 0.47441599f, -0.69423401f,
			0.54126602f, 0.47441599f, -0.69423401f,
			0.19688100f, -0.83400100f, -0.51544201f,
			0.09958700f, -0.77953100f, -0.61839598f,
			0.09958700f, -0.77953100f, -0.61839598f,
			0.09958700f, -0.77953100f, -0.61839598f,
			0.19688100f, -0.83400100f, -0.51544201f,
			0.19688100f, -0.83400100f, -0.51544201f,
			-0.54126602f, -0.47441599f, -0.69423401f,
			-0.64489198f, -0.24507700f, -0.72391403f,
			-0.64489198f, -0.24507700f, -0.72391403f,
			-0.64489198f, -0.24507700f, -0.72391403f,
			-0.54126602f, -0.47441599f, -0.69423401f,
			-0.54126602f, -0.47441599f, -0.69423401f,
			-0.54126602f, -0.47441599f, -0.69423401f,
			-0.54126602f, -0.47441599f, -0.69423401f,
			-0.54126602f, -0.47441599f, -0.69423401f,
			-0.19688100f, 0.83400100f, -0.51544201f,
			-0.09958700f, 0.77953100f, -0.61839598f,
			-0.09958700f, 0.77953100f, -0.61839598f,
			-0.09958700f, 0.77953100f, -0.61839598f,
			-0.19688100f, 0.83400100f, -0.51544201f,
			-0.19688100f, 0.83400100f, -0.51544201f,
			0.15481199f, 0.69858199f, 0.69858199f,
			0.07764000f, 0.70497203f, 0.70497203f,
			0.07764000f, 0.70497203f, 0.70497203f,
			0.07764000f, 0.70497203f, 0.70497203f,
			0.15481199f, 0.69858199f, 0.69858199f,
			0.15481199f, 0.69858199f, 0.69858199f,
			0.15481199f, 0.69858199f, 0.69858199f,
			0.15481199f, 0.69858199f, 0.69858199f,
			0.15481199f, 0.69858199f, 0.69858199f,
			-0.86285597f, 0.35740700f, 0.35740700f,
			-0.86285597f, 0.35740700f, 0.35740700f,
			-0.86285597f, 0.35740700f, 0.35740700f,
			-0.86285597f, 0.35740700f, 0.35740700f,
			-0.86285597f, 0.35740700f, 0.35740700f,
			-0.86285597f, 0.35740700f, 0.35740700f,
			-0.15481199f, -0.69858199f, 0.69858199f,
			-0.15481199f, -0.69858199f, 0.69858199f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			-0.15481199f, -0.69858199f, 0.69858199f,
			-0.15481199f, -0.69858199f, 0.69858199f,
			-0.07764000f, -0.70497203f, 0.70497203f,
			-0.15481199f, -0.69858199f, 0.69858199f,
			0.86285597f, -0.35740700f, 0.35740700f,
			0.86285597f, -0.35740700f, 0.35740700f,
			0.86285597f, -0.35740700f, 0.35740700f,
			0.86285597f, -0.35740700f, 0.35740700f,
			0.86285597f, -0.35740700f, 0.35740700f,
			0.86285597f, -0.35740700f, 0.35740700f,
		};

		static float[] fTexcoords_ModelBrick = {
			0.87501299f, 0.94822800f,
			0.05177200f, 0.94822800f,
			0.05177200f, 0.12498800f,
			0.94822800f, 0.02588600f,
			0.94822800f, 0.89034599f,
			0.08376800f, 0.02588600f,
			0.91623199f, 0.97411400f,
			0.05177200f, 0.97411400f,
			0.05177200f, 0.10965400f,
			0.94822800f, 0.89034599f,
			0.08376800f, 0.02588600f,
			0.94822800f, 0.02588600f,
			0.94822800f, 0.05177200f,
			0.94822800f, 0.87501299f,
			0.12498700f, 0.05177200f,
			0.91623199f, 0.97411400f,
			0.05177200f, 0.97411400f,
			0.05177200f, 0.10965400f,
			0.94822800f, 0.02588600f,
			0.94822800f, 0.89034599f,
			0.08376800f, 0.02588600f,
			0.87501299f, 0.94822800f,
			0.05177200f, 0.94822800f,
			0.05177200f, 0.12498800f,
			0.94822800f, 0.05177200f,
			0.94822800f, 0.87501299f,
			0.12498700f, 0.05177200f,
			0.05177200f, 0.97411400f,
			0.05177200f, 0.10965400f,
			0.91623199f, 0.97411400f,
			0.97411400f, 0.05177200f,
			0.97411400f, 0.91623199f,
			0.10965400f, 0.05177200f,
			0.89034599f, 0.94822800f,
			0.02588600f, 0.94822800f,
			0.02588600f, 0.08376800f,
			0.11646100f, 0.11646100f,
			0.12498700f, 0.05177200f,
			0.94822800f, 0.87501299f,
			0.94822800f, 0.87501299f,
			0.88353902f, 0.88353902f,
			0.11646100f, 0.11646100f,
			0.08376800f, 0.02588600f,
			0.12498700f, 0.00000000f,
			0.94822800f, 0.00000000f,
			0.94822800f, 0.00000000f,
			0.94822800f, 0.02588600f,
			0.08376800f, 0.02588600f,
			0.10365400f, 0.10365400f,
			0.08376800f, 0.02588600f,
			0.94822800f, 0.89034599f,
			0.94822800f, 0.89034599f,
			0.92081499f, 0.92081499f,
			0.10365400f, 0.10365400f,
			0.00000000f, 0.02588600f,
			0.05177200f, 0.10965400f,
			0.05177200f, 0.97411400f,
			0.05177200f, 0.97411400f,
			0.00000000f, 0.89034599f,
			0.00000000f, 0.02588600f,
			0.12498700f, 0.05177200f,
			0.05177200f, 0.00000000f,
			0.91623199f, 0.00000000f,
			0.91623199f, 0.00000000f,
			0.94822800f, 0.05177200f,
			0.12498700f, 0.05177200f,
			0.10365400f, 0.10365400f,
			0.08376800f, 0.02588600f,
			0.94822800f, 0.89034599f,
			0.94822800f, 0.89034599f,
			0.92081499f, 0.92081499f,
			0.10365400f, 0.10365400f,
			0.94822800f, 0.02588600f,
			1.00000000f, 0.10965400f,
			1.00000000f, 0.97411400f,
			1.00000000f, 0.97411400f,
			0.94822800f, 0.89034599f,
			0.94822800f, 0.02588600f,
			0.08376800f, 1.00000000f,
			0.05177200f, 0.94822800f,
			0.87501299f, 0.94822800f,
			0.87501299f, 0.94822800f,
			0.94822800f, 1.00000000f,
			0.08376800f, 1.00000000f,
			0.11646100f, 0.11646100f,
			0.12498700f, 0.05177200f,
			0.94822800f, 0.87501299f,
			0.94822800f, 0.87501299f,
			0.88353902f, 0.88353902f,
			0.11646100f, 0.11646100f,
			0.91623199f, 0.97411400f,
			0.87501299f, 1.00000000f,
			0.05177200f, 1.00000000f,
			0.05177200f, 1.00000000f,
			0.05177200f, 0.97411400f,
			0.91623199f, 0.97411400f,
			0.12498700f, 1.00000000f,
			0.05177200f, 0.97411400f,
			0.91623199f, 0.97411400f,
			0.91623199f, 0.97411400f,
			0.94822800f, 1.00000000f,
			0.12498700f, 1.00000000f,
			0.94822800f, 0.89034599f,
			0.92081499f, 0.92081499f,
			0.10365400f, 0.10365400f,
			0.10365400f, 0.10365400f,
			0.08376800f, 0.02588600f,
			0.94822800f, 0.89034599f,
			0.08376800f, 1.00000000f,
			0.05177200f, 0.94822800f,
			0.87501299f, 0.94822800f,
			0.87501299f, 0.94822800f,
			0.94822800f, 1.00000000f,
			0.08376800f, 1.00000000f,
			0.10965400f, 0.05177200f,
			0.10965400f, 0.00000000f,
			0.97411400f, 0.00000000f,
			0.97411400f, 0.00000000f,
			0.97411400f, 0.05177200f,
			0.10965400f, 0.05177200f,
			0.07918500f, 0.07918500f,
			0.10965400f, 0.05177200f,
			0.97411400f, 0.91623199f,
			0.97411400f, 0.91623199f,
			0.89634597f, 0.89634597f,
			0.07918500f, 0.07918500f,
			0.00000000f, 0.05177200f,
			0.02588600f, 0.08376800f,
			0.02588600f, 0.94822800f,
			0.02588600f, 0.94822800f,
			0.00000000f, 0.87501299f,
			0.00000000f, 0.05177200f,
			0.97411400f, 0.05177200f,
			1.00000000f, 0.12498700f,
			1.00000000f, 0.94822800f,
			1.00000000f, 0.94822800f,
			0.97411400f, 0.91623199f,
			0.97411400f, 0.05177200f,
			0.89034599f, 0.94822800f,
			0.89034599f, 1.00000000f,
			0.02588600f, 1.00000000f,
			0.02588600f, 1.00000000f,
			0.02588600f, 0.94822800f,
			0.89034599f, 0.94822800f,
			0.05177200f, 0.00000000f,
			0.12498700f, 0.00000000f,
			0.08376800f, 0.02588600f,
			0.08376800f, 0.02588600f,
			0.10365400f, 0.10365400f,
			0.05177200f, 0.00000000f,
			0.05177200f, 0.00000000f,
			0.10365400f, 0.10365400f,
			0.02523300f, 0.02523300f,
			1.00000000f, 0.02588600f,
			1.00000000f, 0.10965400f,
			0.94822800f, 0.02588600f,
			0.94822800f, 0.02588600f,
			0.94822800f, 0.00000000f,
			1.00000000f, 0.02588600f,
			0.95077699f, 0.95077699f,
			0.88889903f, 0.88889903f,
			0.92081499f, 0.92081499f,
			0.92081499f, 0.92081499f,
			0.94822800f, 0.89034599f,
			0.95077699f, 0.95077699f,
			0.95077699f, 0.95077699f,
			0.94822800f, 0.89034599f,
			1.00000000f, 0.97411400f,
			0.00000000f, 0.97411400f,
			0.00000000f, 0.89034599f,
			0.05177200f, 0.97411400f,
			0.05177200f, 0.97411400f,
			0.05177200f, 1.00000000f,
			0.00000000f, 0.97411400f,
			0.02588600f, 0.00000000f,
			0.10965400f, 0.00000000f,
			0.10965400f, 0.05177200f,
			0.10965400f, 0.05177200f,
			0.07918500f, 0.07918500f,
			0.02588600f, 0.00000000f,
			0.02588600f, 0.00000000f,
			0.07918500f, 0.07918500f,
			0.04922300f, 0.04922300f,
			0.97411400f, 0.00000000f,
			1.00000000f, 0.05177200f,
			1.00000000f, 0.12498700f,
			1.00000000f, 0.12498700f,
			0.97411400f, 0.05177200f,
			0.97411400f, 0.00000000f,
			1.00000000f, 0.94822800f,
			0.97476703f, 0.97476703f,
			0.90118200f, 0.90118200f,
			0.90118200f, 0.90118200f,
			0.89634597f, 0.89634597f,
			1.00000000f, 0.94822800f,
			1.00000000f, 0.94822800f,
			0.89634597f, 0.89634597f,
			0.97411400f, 0.91623199f,
			0.02588600f, 1.00000000f,
			0.00000000f, 0.94822800f,
			0.00000000f, 0.87501299f,
			0.00000000f, 0.87501299f,
			0.02588600f, 0.94822800f,
			0.02588600f, 1.00000000f,
		};
    }
}