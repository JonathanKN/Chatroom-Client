using System.Drawing;
using System.Windows.Forms;

namespace Bonfire.LogicControllers
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
                Margin = new Padding(0, 0, 0, 5),
                AutoSize = true
            };
            listPanel.Controls.Add(person);
        }

        public void Clear()
        {
            listPanel.Controls.Clear();
        }

        public void RemovePerson(string name)
        {
            Control[] controls = listPanel.Controls.Find($"NameLabel{name}", false);

            if (controls.Length == 0)
            {
                return;
            }

            listPanel.Controls.Remove(controls[0]);
        }
    }
}
