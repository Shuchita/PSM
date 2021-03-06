﻿/* PlayStation(R)Mobile SDK 1.21.01
 * Copyright (C) 2013 Sony Computer Entertainment Inc.
 * All Rights Reserved.
 */


//
// The way to use sleep status and wakeup status
//

// [How to set up the simulation scene]
//
// (1) Make an simulation scene
// (2) Arrange coefficients for contact solver or gravity etc...
// (3) Prepare collision shapes for rigid sceneBodies
// (4) Make the rigid body instances by specifying collision shapes and masses 
// (5) Set the position, rotation, velocity and angular velocity based on the scene
//
// Recommendation of scales for dynamic rigid body
//	
// mass : 0.2[Kg] - 20.0[Kg] for dynamic rigid body
// length : 0.2[m] - 20.0[m] for dynamic rigid body
//
// 1.0[Kg] x 1[m] is a typical mass & length of rigid body for dynamic rigid body 
//
// Please notice that the object has infinite mass while user is picking it 
//


// [Tips and notice]
//
// Sleep status is useful to reduce the calculation cost.
// Sometimes you also may think that you want to make objects
// not to move by the start of some kind of the event.
// For those purposes sleep status is one of soluations.
// 


// use direct access to structure of simulation data to set up initial scene
#define USE_OLD_API

using System;
using System.Text;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;

// Include 2D Physics Framework
using Sce.PlayStation.HighLevel.Physics2D;

namespace Physics2DSample
{
    // To create a simulation scene, please inherit from PhysicsScene class
    public class SleepWakeupScene : PhysicsScene
	{	
        // Vertex Buffer for Body Rendering
        private VertexBuffer[] vertices = new VertexBuffer[100];

        // Vertex Buffer for Debug Rendering
        private VertexBuffer colVert = null;
        
		int start_index = 0;
		int end_index = 0;

		public SleepWakeupScene()
        {
            // Simulation Scene Set Up
            InitScene();

            // Setup for Rendering Object
            for (int i = 0; i < numShape; i++)
            {
                if (sceneShapes[i].numVert == 0)
                {
                    vertices[i] = new VertexBuffer(37, VertexFormat.Float3);
                }
                else
                {
                    vertices[i] = new VertexBuffer(sceneShapes[i].numVert + 1, VertexFormat.Float3);
                }

                MakeLineListConvex(sceneShapes[i], vertices[i]);
            }

            // VertexBuffer for contact points debug rendering
            {
                colVert = new VertexBuffer(4, VertexFormat.Float3);

                const float scale = 0.2f;

                float[] vertex = new float[]
                {
                    -1.0f, -1.0f, 0.0f,
                    1.0f, -1.0f, 0.0f,
                    1.0f, 1.0f, 0.0f,
                    -1.0f, 1.0f, 0.0f
                };

                for (int i = 0; i < 12; i++)
                    vertex[i] = vertex[i] * scale;

                colVert.SetVertices(0, vertex);
            }
        }

        ~SleepWakeupScene()
        {
            ReleaseScene();
        }

        public override void ReleaseScene()
        {
            for (int i = 0; i < numShape; i++)
                if(vertices[i] != null)
                    vertices[i].Dispose();

            if(colVert != null) colVert.Dispose();
        }
		
#if USE_OLD_API
		
		public override void InitScene ()
        {
            // Create an empty simulation scene 
            base.InitScene();
			sceneName = "SleepWakeupScene";
			
            // Before making the rigid sceneBodies, setup collision shapes data
          
            // Box Shape Setting PhysicsShape( "width", "height" )
            Vector2 wall_width = new Vector2(50, 8);
            sceneShapes[0] = new PhysicsShape(wall_width);

            Vector2 wall_height = new Vector2(8, 30);
            sceneShapes[1] = new PhysicsShape(wall_height);

            Vector2 box_width = new Vector2(1.0f, 4.0f);
            sceneShapes[2] = new PhysicsShape(box_width);
			
			Vector2 box_width2 = new Vector2(15.0f, 1.0f);
            sceneShapes[3] = new PhysicsShape(box_width2);
				
			float sphere_width = 3.0f;
            sceneShapes[4] = new PhysicsShape(sphere_width);
			
            numShape = 5;

            // Create static walls to limit the range of action of active rigid sceneBodies
            {
                // new PhysicsBody( "shape of the body",  "mass of the body(kg)" ) 
                sceneBodies[numBody] = new PhysicsBody(sceneShapes[0], PhysicsUtility.FltMax);

                // Set the position & the rotation
                sceneBodies[numBody].position = new Vector2(0, -wall_height.Y);
                sceneBodies[numBody].rotation = 0;

                // Make shapeIndex consistent with what we set as convex shape
                sceneBodies[numBody].shapeIndex = 0;
                numBody++;

                sceneBodies[numBody] = new PhysicsBody(sceneShapes[1], PhysicsUtility.FltMax);
                sceneBodies[numBody].position = new Vector2(wall_width.X, 0);
                sceneBodies[numBody].rotation = 0;
                sceneBodies[numBody].shapeIndex = 1;
                numBody++;

                sceneBodies[numBody] = new PhysicsBody(sceneShapes[1], PhysicsUtility.FltMax);
                sceneBodies[numBody].position = new Vector2(-wall_width.X, 0);
                sceneBodies[numBody].rotation = 0;
                sceneBodies[numBody].shapeIndex = 1;
                numBody++;

                sceneBodies[numBody] = new PhysicsBody(sceneShapes[0], PhysicsUtility.FltMax);
                sceneBodies[numBody].position = new Vector2(0, wall_height.Y);
                sceneBodies[numBody].rotation = 0;
                sceneBodies[numBody].shapeIndex = 0;
                numBody++;
            }

            // Create an unstable tower
			// Without sleep status, it will collapse immediately
			{
				start_index = numBody;
				
				for(int i=0; i<2; i++)
                {
                    sceneBodies[numBody] = new PhysicsBody(sceneShapes[2], 1.0f);
                    sceneBodies[numBody].position = new Vector2(10.0f, -wall_height.Y + wall_width.Y + 0.005f + box_width.Y);
					sceneBodies[numBody].position += new Vector2(0, (box_width.Y * 2.0f + 0.005f)* i);
                    sceneBodies[numBody].shapeIndex = 2;
                    numBody++;
                }

               	for(int i=0; i<2; i++)
                {
                    sceneBodies[numBody] = new PhysicsBody(sceneShapes[2], 1.0f);
                    sceneBodies[numBody].position = new Vector2(20.0f, -wall_height.Y + wall_width.Y + 0.005f + box_width.Y);
					sceneBodies[numBody].position += new Vector2(0, (box_width.Y * 2.0f + 0.005f)* i);
					sceneBodies[numBody].shapeIndex =2;
                    numBody++;
                }
				
				sceneBodies[numBody] = new PhysicsBody(sceneShapes[3], 1.0f);
                sceneBodies[numBody].position = new Vector2(20.0f, -wall_height.Y + wall_width.Y + 0.005f + box_width.Y);
				sceneBodies[numBody].position += new Vector2(0, (box_width.Y * 2.0f + 0.005f));
				sceneBodies[numBody].position += new Vector2(0, box_width.Y + 0.005f + box_width2.Y);
				sceneBodies[numBody].shapeIndex =3;
                numBody++;			
				
				// Put the sphere to make the tower unstable for test
				sceneBodies[numBody] = new PhysicsBody(sceneShapes[4], 3.0f);
                sceneBodies[numBody].position = new Vector2(30.0f, -wall_height.Y + wall_width.Y + 0.005f);
				sceneBodies[numBody].position += new Vector2(0, (box_width.Y * 2.0f + 0.005f)*2);
				sceneBodies[numBody].position += new Vector2(0, (box_width2.Y* 2.0f + 0.005f));
				sceneBodies[numBody].position += new Vector2(0, sceneShapes[4].vertList[0].X);
				sceneBodies[numBody].shapeIndex =4;
                numBody++;		
						
				end_index = numBody;
				
				for(int i=start_index; i<end_index; i++)
				{
					sceneBodies[i].sleep = true;
				}
			}

			// Shoot the sphere to wake up rigid sceneBodies of the tower
			// When this sphere touch with the tower, all sleep status of the tower are disabled
			sceneBodies[numBody] = new PhysicsBody(sceneShapes[4], 3.0f);
			sceneBodies[numBody].position = new Vector2(-30.0f, -10.0f);
			sceneBodies[numBody].velocity = new Vector2(10, 10);
			sceneBodies[numBody].shapeIndex =4;
			numBody++;

        }
#else
		public override void InitScene ()
        {
            // Create an empty simulation scene 
            base.InitScene();
			SceneName = "SleepWakeupScene";
			
			// Before making the rigid sceneBodies, setup collision shapes data

            // Box Shape Setting AddBoxShape(new Vector2("width", "height"))
            Vector2 wall_width = new Vector2(50, 8);
            AddBoxShape(wall_width);

            Vector2 wall_height = new Vector2(8, 30);
			AddBoxShape(wall_height);

            Vector2 box_width = new Vector2(1.0f, 4.0f);
            AddBoxShape(box_width);
			
			Vector2 box_width2 = new Vector2(15.0f, 1.0f);
            AddBoxShape(box_width2);
				
			float sphere_width = 3.0f;
            AddSphereShape(sphere_width);


            // Create static walls to limit the range of action of active rigid sceneBodies
            {
				PhysicsBody body = null;
                // AddBody( "shape of the body",  "mass of the body(kg)" ) 
                body = AddBody(SceneShapes[0], PhysicsUtility.FltMax);

                // Set the position & the rotation
                body.Position = new Vector2(0, -wall_height.Y);
                body.Rotation = 0;

                body = AddBody(SceneShapes[1], PhysicsUtility.FltMax);
                body.Position = new Vector2(wall_width.X, 0);
                body.Rotation = 0;

                body = AddBody(SceneShapes[1], PhysicsUtility.FltMax);
                body.Position = new Vector2(-wall_width.X, 0);
                body.Rotation = 0;

                body = AddBody(SceneShapes[0], PhysicsUtility.FltMax);
                body.Position = new Vector2(0, wall_height.Y);
                body.Rotation = 0;
            }

            // Create an unstable tower
			// Without sleep status, it will collapse immediately
			{
				start_index = NumBody;
				
				PhysicsBody body = null;
				
				for(int i=0; i<2; i++)
                {
                    body = AddBody(SceneShapes[2], 1.0f);
                    body.Position = new Vector2(10.0f, -wall_height.Y + wall_width.Y + 0.005f + box_width.Y);
					body.Position += new Vector2(0, (box_width.Y * 2.0f + 0.005f)* i);
                }

               	for(int i=0; i<2; i++)
                {
                    body = AddBody(SceneShapes[2], 1.0f);
                    body.Position = new Vector2(20.0f, -wall_height.Y + wall_width.Y + 0.005f + box_width.Y);
					body.Position += new Vector2(0, (box_width.Y * 2.0f + 0.005f)* i);
                }
				
				body = AddBody(SceneShapes[3], 1.0f);
                body.Position = new Vector2(20.0f, -wall_height.Y + wall_width.Y + 0.005f + box_width.Y);
				body.Position += new Vector2(0, (box_width.Y * 2.0f + 0.005f));
				body.Position += new Vector2(0, box_width.Y + 0.005f + box_width2.Y);
				
				// Put the sphere to make the tower unstable for test
				body = AddBody(SceneShapes[4], 3.0f);
                body.Position = new Vector2(30.0f, -wall_height.Y + wall_width.Y + 0.005f);
				body.Position += new Vector2(0, (box_width.Y * 2.0f + 0.005f)*2);
				body.Position += new Vector2(0, (box_width2.Y* 2.0f + 0.005f));
				body.Position += new Vector2(0, sceneShapes[4].vertList[0].X);	
						
				end_index = NumBody;
				
				for(int i=start_index; i<end_index; i++)
				{
					SceneBodies[i].Sleep = true;
				}
			}

			// Shoot the sphere to wake up rigid sceneBodies of the tower
			// When this sphere touch with the tower, all sleep status of the tower are disabled
			{
				PhysicsBody body = AddBody(SceneShapes[4], 3.0f);
				body.Position = new Vector2(-30.0f, -10.0f);
				body.Velocity = new Vector2(10, 10);
			}

        }	
#endif
		
       // Game controller handling
        public override void KeyboardFunc(GamePadButtons button)
        {
            switch (button)
            {
				// wake up rigid sceneBodies of the tower
                case GamePadButtons.Square:
            	
					for(int i=start_index; i<end_index; i++)
					{
						sceneBodies[i].sleep = false;
						sceneBodies[i].SleepCount = 0;
					}
				
                    break;
                default:
                    break;
			}
		}
		
		// Line Rendering for Object
        private void MakeLineListConvex(PhysicsShape con, VertexBuffer vertices)
        {

            if (con.numVert == 0)
            {
                float[] vertex = new float[3 * 37];

                int i = 0;
                float rad = con.vertList[0].X;

                for (float th1 = 0.0f; th1 < 360.0f; th1 = th1 + 10.0f)
                {
                    float th1_rad = th1 / 180.0f * PhysicsUtility.Pi;

                    float x1 = rad * (float)Math.Cos(th1_rad);
                    float y1 = rad * (float)Math.Sin(th1_rad);

                    vertex[3 * i + 0] = x1;
                    vertex[3 * i + 1] = y1;
                    vertex[3 * i + 2] = 0.0f;
                    i++;
                }

                vertex[3 * i + 0] = vertex[3 * 0 + 0];
                vertex[3 * i + 1] = vertex[3 * 0 + 1];
                vertex[3 * i + 2] = vertex[3 * 0 + 2];

                vertices.SetVertices(0, vertex);

            }
            else
            {
                float[] vertex = new float[3 * (con.numVert + 1)];

                int i;

                for (i = 0; i < con.numVert; i++)
                {
                    Vector2 v1;
                    v1 = con.vertList[i];

                    vertex[3 * i + 0] = v1.X;
                    vertex[3 * i + 1] = v1.Y;
                    vertex[3 * i + 2] = 0.0f;
                }

                vertex[3 * i + 0] = vertex[3 * 0 + 0];
                vertex[3 * i + 1] = vertex[3 * 0 + 1];
                vertex[3 * i + 2] = vertex[3 * 0 + 2];

                vertices.SetVertices(0, vertex);
            }
        }


        // Draw objects
        public override void DrawAllBody(ref GraphicsContext graphics, ref ShaderProgram program, Matrix4 renderMatrix, int click_index)
        {
            for (int j = 0; j < numShape; j++)
            {
                graphics.SetVertexBuffer(0, vertices[j]);

                for (int i = 0; i < numBody; i++)
                {
                    uint index = sceneBodies[i].shapeIndex;

                    if (j != index) continue;

                    Matrix4 rotationMatrix = Matrix4.RotationZ(sceneBodies[i].rotation);

                    Matrix4 transMatrix = Matrix4.Translation(
                        new Vector3(sceneBodies[i].position.X, sceneBodies[i].position.Y, 0.0f));

                    Matrix4 local_rotationMatrix = Matrix4.RotationZ(sceneBodies[i].localRotation);

                    Matrix4 local_transMatrix = Matrix4.Translation(
                        new Vector3(sceneBodies[i].localPosition.X, sceneBodies[i].localPosition.Y, 0.0f));

                    Matrix4 WorldMatrix = renderMatrix * transMatrix * rotationMatrix * local_transMatrix * local_rotationMatrix;

                    program.SetUniformValue(0, ref WorldMatrix);

                    if (i == click_index)
                    {
                        Vector3 color = new Vector3(1.0f, 0.0f, 0.0f);
                        program.SetUniformValue(1, ref color);
                    }
                    else
                    {
						Vector3 color;
						
						if(sceneBodies[i].sleep == true)
							color = new Vector3(1.0f, 1.0f, 0.0f);
						else
							color = new Vector3(0.0f, 1.0f, 1.0f);
						
                        program.SetUniformValue(1, ref color);
                    }

                    if (sceneShapes[index].numVert == 0)
                        graphics.DrawArrays(DrawMode.LineStrip, 0, 37);
                    else
                        graphics.DrawArrays(DrawMode.LineStrip, 0, sceneShapes[index].numVert + 1);

                }

            }
        }

        // Debug rendering for contact points(RigidBody A <=> RigidBody B) and AABB(Axis Aligned Bounding Box)
        public override void DrawAdditionalInfo(ref GraphicsContext graphics, ref ShaderProgram program, Matrix4 renderMatrix)
        {
            // Draw contact points
            graphics.SetVertexBuffer(0, colVert);

            for (uint i = 0; i < numPhysicsSolverPair; i++)
            {
                // Collision point for RigidBody A 
                {
                    Matrix4 transMatrix = Matrix4.Translation(
                        new Vector3(solverPair[i].resA.X, solverPair[i].resA.Y, 0.0f));

                    Matrix4 WorldMatrix = renderMatrix * transMatrix;
                    program.SetUniformValue(0, ref WorldMatrix);

                    Vector3 color = new Vector3(1.0f, 0.0f, 0.0f);
                    program.SetUniformValue(1, ref color);

                    graphics.DrawArrays(DrawMode.TriangleFan, 0, 4);
                }

                // Collision point for RigidBody B 
                {
                    Matrix4 transMatrix = Matrix4.Translation(
                        new Vector3(solverPair[i].resB.X, solverPair[i].resB.Y, 0.0f));

                    Matrix4 WorldMatrix = renderMatrix * transMatrix;
                    program.SetUniformValue(0, ref WorldMatrix);

                    Vector3 color = new Vector3(1.0f, 0.0f, 0.0f);
                    program.SetUniformValue(1, ref color);

                    graphics.DrawArrays(DrawMode.TriangleFan, 0, 4);
                }
            }
        }
	}
}


		
		

		

		
