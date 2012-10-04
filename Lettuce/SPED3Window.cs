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

            GL.Begin(BeginMode.LineStrip);

            bool flicker = random.Next(256) < SPED3.TotalVerticies;

            if (!flicker)
            {
                var verticies = SPED3.Verticies;
                for (int i = 0; i < SPED3.TotalVerticies; i++)
                {
                    if (verticies[i].Color == SPED3Color.Black)
                    {
                        if (verticies[i].Intensity == SPED3Intensity.Dim)
                            GL.Color3(Color.Black);
                        else
                            GL.Color3(Color.DarkSlateGray);
                    }
                    else if (verticies[i].Color == SPED3Color.Green)
                    {
                        if (verticies[i].Intensity == SPED3Intensity.Dim)
                            GL.Color3(Color.Green);
                        else
                            GL.Color3(Color.LightGreen);
                    }
                    else if (verticies[i].Color == SPED3Color.Red)
                    {
                        if (verticies[i].Intensity == SPED3Intensity.Dim)
                            GL.Color3(Color.DarkRed);
                        else
                            GL.Color3(Color.Red);
                    }
                    else if (verticies[i].Color == SPED3Color.Blue)
                    {
                        if (verticies[i].Intensity == SPED3Intensity.Dim)
                            GL.Color3(Color.Blue);
                        else
                            GL.Color3(Color.LightBlue);
                    }

                    Vector3 position = new Vector3((float)(verticies[i].X) / 256 * 2 - 1,
                        (float)(verticies[i].Y) / 256 * 2 - 1,
                        (float)(verticies[i].Z) / 256 * 2 - 1);
                    GL.Vertex3(position);
                }
            }

            GL.End();

            glControl1.SwapBuffers();
        }
    }
}
