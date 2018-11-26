using System;
using System.Windows.Forms;
using SharpGL.SceneGraph.Core;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;

namespace GettingStartedWithSharpGL
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();

            //  Create a sphere.
            //Sphere sphere = new Sphere();
            //sphere.Transformation.TranslateX = 2;
            //sphere.Transformation.TranslateY = 2;

            //  Create a cone.
            Cylinder cone = new Cylinder
            {
                Name = "Cone", BaseRadius = 1.5, TopRadius = 0, Height = 2
            };
            cone.Transformation.TranslateX = -2;
            cone.Transformation.TranslateY = -2;

            //  Create a cylinder.
            Cylinder cylinder = new Cylinder
            {
                Name = "Cylinder",
                BaseRadius = 0.8,
                TopRadius = 0.8,
                Height = 3,
                Transformation =
                {
                    TranslateX = -2,
                    TranslateY = -2,
                    TranslateZ = 1
                },
                QuadricDrawStyle = DrawStyle.Fill
            };

            Cylinder cylinderJoin = new Cylinder
            {
                Name = "CylinderJoin",
                BaseRadius = 0.6,
                TopRadius = 0.6,
                Height = 1.5,
                Transformation =
                {
                    TranslateX = -3,
                    TranslateY = -2,
                    TranslateZ = 5.0f,
                    RotateX = 90
                },
                QuadricDrawStyle = DrawStyle.Fill
            };

            //  Create a cube.
            Cylinder topBone = new Cylinder
            {
                Name = "TopBone",
                BaseRadius = 0.6,
                TopRadius = 0.6,
                Height = 4,
                Transformation =
                {
                    TranslateX = -2.8f,
                    TranslateY = -2.5f,
                    TranslateZ = 5.0f,
                    RotateY = 45
                },
                QuadricDrawStyle = DrawStyle.Fill
            };

            Cylinder topJoin = new Cylinder
            {
                Name = "topJoin",
                BaseRadius = 0.4,
                TopRadius = 0.4,
                Height = 2.0,
                Transformation =
                {
                    TranslateX = -0.1f,
                    TranslateY = -2.0f,
                    TranslateZ = 8.0f,
                    RotateX = 90
                },
                QuadricDrawStyle = DrawStyle.Fill
            };

            Cylinder mildeBone = new Cylinder
            {
                Name = "mildeBone",
                BaseRadius = 0.4,
                TopRadius = 0.4,
                Height = 3,
                Transformation =
                {
                    TranslateX = -0.1f,
                    TranslateY = -3.5f,
                    TranslateZ = 5.0f,
                  
                },
                QuadricDrawStyle = DrawStyle.Fill
            };

            Cylinder lastJoin = new Cylinder
            {
                Name = "lastJoin",
                BaseRadius = 0.4,
                TopRadius = 0.4,
                Height = 1,
                Transformation =
                {
                    TranslateX = -0.1f,
                    TranslateY = -3.0f,
                    TranslateZ = 5.0f,
                    RotateX = 90

                },
                QuadricDrawStyle = DrawStyle.Fill
            };
            Cylinder platform = new Cylinder
            {
                Name = "platform",
                BaseRadius = 1,
                TopRadius = 0.2,
                Height = 0.5,
                Transformation =
                {
                    TranslateX = 0.1f,
                    TranslateY = -3.4f,
                    TranslateZ = 4.5f,           
                },
                QuadricDrawStyle = DrawStyle.Fill,
                NormalGeneration = Normals.None
            };

            Cylinder platform2 = new Cylinder
            {
                Name = "platform2",
                BaseRadius = 1,
                TopRadius = 1,
                Height = 0.5,
                Transformation =
                {
                    TranslateX = 0.1f,
                    TranslateY = -3.4f,
                    TranslateZ = 4.0f,
                },
                QuadricDrawStyle = DrawStyle.Fill
            };

            //Cube cube = new Cube
            //{
            //    Transformation =
            //    {
            //        TranslateX = -2,
            //        TranslateY = -3,
            //        TranslateZ = 6
            //    }
            //};


            //  Add them.
            sceneControl1.Scene.SceneContainer.AddChild(topJoin);
            sceneControl1.Scene.SceneContainer.AddChild(topBone);
            sceneControl1.Scene.SceneContainer.AddChild(cone);
            sceneControl1.Scene.SceneContainer.AddChild(cylinder);
            sceneControl1.Scene.SceneContainer.AddChild(cylinderJoin);
            sceneControl1.Scene.SceneContainer.AddChild(mildeBone);
            sceneControl1.Scene.SceneContainer.AddChild(lastJoin);
            sceneControl1.Scene.SceneContainer.AddChild(platform);
            sceneControl1.Scene.SceneContainer.AddChild(platform2);

        }

        /// <summary>
        /// Called when [selected scene element changed].
        /// </summary>
        private void OnSelectedSceneElementChanged()
        {
            propertyGrid1.SelectedObject = SelectedSceneElement;
        }

        /// <summary>
        /// The selected scene element.
        /// </summary>
        private SceneElement selectedSceneElement;

        /// <summary>
        /// Gets or sets the selected scene element.
        /// </summary>
        /// <value>
        /// The selected scene element.
        /// </value>
        public SceneElement SelectedSceneElement
        {
            get { return selectedSceneElement; }
            set
            {
                selectedSceneElement = value;
                OnSelectedSceneElementChanged();
            }
        }

        private void toolStripButtonShowBoundingVolumes_Click(object sender, EventArgs e)
        {
            sceneControl1.Scene.RenderBoundingVolumes = !sceneControl1.Scene.RenderBoundingVolumes;
            toolStripButtonShowBoundingVolumes.Checked = !toolStripButtonShowBoundingVolumes.Checked;
        }

        private void sceneControl1_MouseClick(object sender, MouseEventArgs e)
        {
            //  Do a hit test.
            SelectedSceneElement = null;
            listBox1.Items.Clear();
            var itemsHit = sceneControl1.Scene.DoHitTest(e.X, e.Y);
            foreach (var item in itemsHit)
                listBox1.Items.Add(item);
            if (listBox1.Items.Count > 0)
            {
                listBox1.SetSelected(0, true);
                // listBox1_SelectedIndexChanged(this, null);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSceneElement = listBox1.SelectedItem as SceneElement;
        }
    }
}
