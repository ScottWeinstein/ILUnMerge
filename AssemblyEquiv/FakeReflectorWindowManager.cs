using System;
using Reflector;
using System.Windows.Forms;

namespace ACATool.Tasks
{
    internal class FakeReflectorWindowManager : IWindowManager
    {
        public FakeReflectorWindowManager()
        {
            Closed += (sender, e) =>
            {
            };
            Load += (sender, e) =>
            {
            };
        }

        public void Activate()
        {
        }
        public void Close()
        {
        }
        public event EventHandler Closed;
        public event EventHandler Load;
        public Control CommandBarManager { get; set; }
        public Control Content { get; set; }
        public IStatusBar StatusBar { get; private set; }
        public bool Visible { get; set; }
        public IWindowCollection Windows { get; private set; }
        public void ShowMessage(string message)
        {
        }
    }
}
