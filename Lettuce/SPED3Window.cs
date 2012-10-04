using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Tomato.Hardware;
using Tomato;

namespace Lettuce
{
    public partial class SPED3Window : DeviceHostForm
    {
        public SPED3 SPED3;
        public DCPU CPU;

        private Device[] managedDevices;
        public override Device[] ManagedDevices
        {
            get { return managedDevices; }
        }

        System.Threading.Timer timer;
        public SPED3Window(SPED3 SPED3, DCPU CPU)
        {
            InitializeComponent();
            timer = new System.Threading.Timer(delegate(object o)
                {
                    InvalidateAsync();
                }, null, 16, 16); // 60 Hz
            this.Text = "SPED-3 Display #" + CPU.Devices.IndexOf(SPED3);
            managedDevices = new Device[] { SPED3 };
            this.CPU = CPU;
            this.SPED3 = SPED3;
        }

        private delegate void InvalidateAsyncDelegate();
        private void InvalidateAsync()
        {
            if (this.InvokeRequired)
            {
                try
                {
                    InvalidateAsyncDelegate iad = new InvalidateAsyncDelegate(InvalidateAsync);
                    this.Invoke(iad);
                }
                catch { }
            }
            else
            {
                this.Invalidate(true);
                this.Update();
            }
        }

        bool glControlLoaded = false;

        private void glControl1_Load(object sender, EventArgs e)
        {
            glControlLoaded = true;
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            GL.ClearColor(Color4.Black);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!glControlLoaded)
                return;
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            GL.ClearColor(Color4.Black);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        Random random = new Random();
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!glControlLoaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(new Vector3(0, -4, 0), Vector3.Zero, Vector3.UnitZ);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            GL.Rotate(SPED3.CurrentRotation, Vector3.UnitZ);
            // Flicker
            double flicker = random.NextDouble() * (SPED3.TotalVerticies / 1024f);
            if (SPED3.EnableFlickering)
                GL.Translate(flicker, flicker, flicker);

            bool flickerModel = random.Next(256) < SPED3.TotalVerticies && SPED3.EnableFlickering;

            if (SPED3.TotalVerticies > 0 && !flickerModel)
            {
                GL.Begin(BeginMode.LineStrip);
                var verticies = SPED3.Verticies;
                Vector3 position;

                for (int i = 0; i < SPED3.TotalVerticies && i < 128; i++)
                {
                    GL.Color3(GetColor(verticies[i]));

                    position = new Vector3((float)(verticies[i].X) / 256 * 2 - 1,
                        (float)(verticies[i].Y) / 256 * 2 - 1,
                        (float)(verticies[i].Z) / 256 * 2 - 1);
                    GL.Vertex3(position);
                }

                GL.End();

                if (SPED3.EnableFlickering)
                {
                    GL.Begin(BeginMode.Quads);
                    int vertex = random.Next(SPED3.TotalVerticies);
                    position = new Vector3((float)(verticies[vertex].X) / 256 * 2 - 1,
                                           (float)(verticies[vertex].Y) / 256 * 2 - 1,
                                           (float)(verticies[vertex].Z) / 256 * 2 - 1);
                    GL.Color3(GetColor(verticies[vertex]));
                    foreach (var point in cubeVerticies)
                        GL.Vertex3(point + position);
                    GL.End();
                }
            }

            glControl1.SwapBuffers();
        }

        private Vector3 GetColor(SPED3Vertex vertex)
        {
            Vector3 color = new Vector3(0, 0, 0);
            if (vertex.Color == SPED3Color.Black)
                color = new Vector3(0.25f, 0.25f, 0.25f);
            else if (vertex.Color == SPED3Color.Green)
                color = new Vector3(0, 1, 0);
            else if (vertex.Color == SPED3Color.Red)
                color = new Vector3(1, 0, 0);
            else if (vertex.Color == SPED3Color.Blue)
                color = new Vector3(0, 0, 1);
            if (vertex.Intensity == SPED3Intensity.Dim)
                color = Vector3.Multiply(color, new Vector3(0.5f, 0.5f, 0.5f));
            return color;
        }

        static SPED3Window()
        {
            for (int i = 0; i < cubeVerticies.Length; i++)
                cubeVerticies[i] = Vector3.Multiply(new Vector3(0.25f, 0.25f, 0.25f), cubeVerticies[i]);
        }

        private static Vector3[] cubeVerticies = new Vector3[]
            {
                // near
                new Vector3(0.1f, 0.1f, 0.1f), new Vector3(-0.1f, 0.1f, 0.1f), new Vector3(-0.1f, 0.1f, -0.1f), new Vector3(0.1f, 0.1f, -0.1f), 
                // left
                new Vector3(-0.1f, 0.1f, 0.1f), new Vector3(-0.1f, -0.1f, 0.1f), new Vector3(-0.1f, -0.1f, -0.1f), new Vector3(-0.1f, 0.1f, 0.1f),
                // far
                new Vector3(0.1f, -0.1f, 0.1f), new Vector3(-0.1f, -0.1f, 0.1f), new Vector3(-0.1f, -0.1f, -0.1f), new Vector3(0.1f, -0.1f, -0.1f), 
                // right
                new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.1f, -0.1f, 0.1f), new Vector3(0.1f, -0.1f, -0.1f), new Vector3(0.1f, 0.1f, 0.1f),
                // top
                new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.1f, -0.1f, 0.1f), new Vector3(-0.1f, -0.1f, 0.1f), new Vector3(-0.1f, 0.1f, 0.1f),
                // bottom
                new Vector3(0.1f, 0.1f, -0.1f), new Vector3(0.1f, -0.1f, -0.1f), new Vector3(-0.1f, -0.1f, -0.1f), new Vector3(-0.1f, 0.1f, -0.1f)
            };
    }
}
