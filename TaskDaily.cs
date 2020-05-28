using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Tweak
{
    public class TaskDaily : ITask
    {
        private readonly string _args; 
        
        public ulong Weight { get; } = 4;

        public bool Active { get; set; }
        
        public TaskDaily(string args)
        {
            _args = args;
        }

        public void Apply()
        {
            new Process
            {
                EnableRaisingEvents = false,
                StartInfo =
                {
                    FileName = "schtasks.exe",
                    Arguments = "/delete /tn " + Program.TaskName + " /f",
                    UseShellExecute = true
                }
            }.Start();
            
            if (Active)
            {
                var f = new FileInfo(Application.ExecutablePath);
                var p = new Process
                {
                    EnableRaisingEvents = false,
                    StartInfo =
                    {
                        FileName = "schtasks.exe",
                        Arguments = "/create /sc daily /tn "
                                    + Program.TaskName
                                    + " /tr \""
                                    + f.Name
                                    + " "
                                    + _args
                                    + "\"",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    }
                }.Start();
            }
        }

        public override string ToString()
        {
            return "Добавление ежедневного запуска";
        }
    }
}