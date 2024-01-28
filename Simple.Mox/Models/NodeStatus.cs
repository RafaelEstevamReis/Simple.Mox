namespace Simple.Mox.Models;

using System;

public record NodeStatus
{
    public float wait { get; set; }
    public Memory memory { get; set; }
    public float cpu { get; set; }
    public Rootfs rootfs { get; set; }
    public string pveversion { get; set; }
    public Memory swap { get; set; }
    public BootInfo bootinfo { get; set; }
    public int idle { get; set; }
    public float[] loadavg { get; set; }
    public int uptime { get; set; }
    public Cpuinfo cpuinfo { get; set; }
    public CurrentKernel currentkernel { get; set; }
    public string kversion { get; set; }
    public Ksm ksm { get; set; }


    public record Memory
    {
        public long free { get; set; }
        public long used { get; set; }
        public long total { get; set; }

        public float percent => (100f * used) / total;
    }

    public record Rootfs
    {
        public long avail { get; set; }
        public long free { get; set; }
        public long total { get; set; }
        public long used { get; set; }

        public float percent => (100f * used) / total;
    }

    public record BootInfo
    {
        public string mode { get; set; }
        public int secureboot { get; set; }
    }

    public record Cpuinfo
    {
        public string hvm { get; set; }
        public string flags { get; set; }
        public string model { get; set; }
        public string mhz { get; set; }
        public int sockets { get; set; }
        public int user_hz { get; set; }
        public int cores { get; set; }
        public int cpus { get; set; }
    }

    public record CurrentKernel
    {
        public string release { get; set; }
        public string sysname { get; set; }
        public string version { get; set; }
        public string machine { get; set; }
    }

    public record Ksm
    {
        public int shared { get; set; }
    }
}