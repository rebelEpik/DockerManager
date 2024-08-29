using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerManager
{
    public class DockerInfo
    {
        public DockerInfo(string containerName, string containerID, string cPUUsage, string memUsage, string netIO, string blockIO, string pID)
        {
            ContainerName = containerName;
            ContainerID = containerID;
            CPUUsage = cPUUsage;
            MemUsage = memUsage;
            NetIO = netIO;
            BlockIO = blockIO;
            PID = pID;
        }

        public string ContainerName { get; set; }
        public string ContainerID { get; set; }
        public string CPUUsage { get; set; }
        public string MemUsage { get; set; }
        public string NetIO { get; set; }
        public string BlockIO { get; set; }
        public string PID { get; set; }
    }

}
