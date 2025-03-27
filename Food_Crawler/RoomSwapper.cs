using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Food_Crawler
{
    class RoomSwapper
    {
        private List<Action<TextBox, Button, PictureBox, Image, String>> functions;

        public RoomSwapper() //construct these non static functions after
        {
            functions = new List<Action<TextBox, Button, PictureBox, Image, String>>()
            {
                Room1,
                Room2
            };
        }
        public void Room1(TextBox StartMenuTextBox, Button button, PictureBox StartScreenPictureBox, Image TestImage, String ResourcesPath)
        {   //Self Reflection Room
            String ReflectionPath = ResourcesPath + "/ReflectionOfSelf.png";
            TestImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = TestImage;
            StartMenuTextBox.Text = "Well your not as dashing as you remeber";

        }
        public void Room2(TextBox StartMenuTextBox, Button button, PictureBox StartScreenPictureBox, Image TestImage, String ResourcesPath)
        {
            //Stats Room for inital point investment
            String ReflectionPath = ResourcesPath + "/StatusScreen.png";
            TestImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = TestImage;
            StartMenuTextBox.Text = "Memories surge through your veins";
            Form1? mainForm = FormGrabber();
            
            //make button and set up its properties
            Button healthButton = new Button();
            healthButton.Location = new Point(1184, 987);
            healthButton.Name = "StartMenuButton";
            healthButton.Size = new Size(895, 140);
            healthButton.TabIndex = 1;
            healthButton.Text = "Click to Continue";
            healthButton.UseVisualStyleBackColor = true;
            healthButton.Click += StartMenuButton_Click; //might need to add this to the forms as well as a function unsure as of now

            mainForm.Controls.Add(healthButton);
        }

        public List<Action<TextBox, Button, PictureBox, Image, String>> getFunctionsVector()
        {
            return functions;
        }

    public Form1? FormGrabber()
        { //this function gets the forms object i hope [might need to swap it to be a ptr return rather than just the obj type]
            Form1? mainForm = (Form1?)Application.OpenForms["Form1"]; 
            if (mainForm != null)
            {
                return mainForm;
            }
            return null;
        }
    }
}
