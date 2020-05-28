using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Tweak
{
    public class TaskDaily : ITask
    {
        private readonly Task _task;
    
        public ulong Weight { get; } = 4;

        public bool Active { get; set; }
        
        public TaskDaily(string args)
        {
            try
            {
                _task = Program.TaskService.FindTask(Program.TaskName);
                if (_task != null) return;
                _task = Program.TaskService.AddTask(
                    Program.TaskName,
                    QuickTriggerType.Daily,
                    Application.ExecutablePath,
                    args
                );
            }
            catch
            {
                //
            }
        }

        public void Apply()
        {
            if (_task != null)
                _task.Enabled = Active;
        }

        public override string ToString()
        {
            return "Добавление ежедневного запуска";
        }
    }
}