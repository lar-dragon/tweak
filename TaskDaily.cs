

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
            _task = Program.TaskService.FindTask(Program.TaskName);
            if (_task != null) return;
            var taskDefinition = Program.TaskService.NewTask();
            taskDefinition.RegistrationInfo.Description = Program.TaskName;
            taskDefinition.Triggers.Add(new DailyTrigger { DaysInterval = 1 });
            taskDefinition.Actions.Add(new ExecAction(Application.ExecutablePath, args));
            _task = Program.TaskService.RootFolder.RegisterTaskDefinition(Program.TaskName, taskDefinition);
        }

        public void Apply()
        {
            _task.Enabled = Active;
        }

        public override string ToString()
        {
            return "Добавление ежедневного запуска";
        }
    }
}