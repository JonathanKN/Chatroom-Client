using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatrum
{
    public class UserListController
    {
        private readonly FlowLayoutPanel listPanel;

        public UserListController(FlowLayoutPanel userListPanel)
        {
            listPanel = userListPanel;
        }

        public void AddPerson(string name)
        {
            Label person = new Label
            {
                Text = name,
                Name = $"NameLabel{name}",
                ForeColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 13),
                Margin = new Padding(0, 0, 0, 2),
                AutoSize = true
            };
            listPanel.Controls.Add(person);
        }

        public void RemovePerson(string name)
        {
            // TODO: Kommer til at lave en exception hvis navnet ikke findes.
            listPanel.Controls.Remove(listPanel.Controls.Find($"NameLabel{name}", false)[0]);
        }
    }
}
