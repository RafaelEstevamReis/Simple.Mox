namespace Simple.Mox.Models;

using System;
using System.Collections.Generic;

public record VMStatus
{
    public long maxmem { get; set; }
    public Ha ha { get; set; }
    public int shares { get; set; }
    public float cpu { get; set; }
    public long freemem { get; set; }
    public string runningqemu { get; set; }
    public int pid { get; set; }
    public ProxmoxSupport proxmoxsupport { get; set; }
    public Ballooninfo ballooninfo { get; set; }
    public int uptime { get; set; }
    public string name { get; set; }
    public int disk { get; set; }
    public long maxdisk { get; set; }
    public long diskwrite { get; set; }
    public long netout { get; set; }
    public string qmpstatus { get; set; }
    public long balloon_min { get; set; }
    public long balloon { get; set; }
    public int cpus { get; set; }
    public Dictionary<string, NicInfo> nics { get; set; }
    public long netin { get; set; }
    public Blockstat blockstat { get; set; }
    public long diskread { get; set; }
    public int vmid { get; set; }
    public long mem { get; set; }
    public string status { get; set; }
    public string runningmachine { get; set; }

    public class Ha
    {
        public int managed { get; set; }
    }

    public class ProxmoxSupport
    {
        public bool pbsdirtybitmapmigration { get; set; }
        public bool querybitmapinfo { get; set; }
        public bool backupmaxworkers { get; set; }
        public bool pbsmasterkey { get; set; }
        public bool pbsdirtybitmapsavevm { get; set; }
        public string pbslibraryversion { get; set; }
        public bool pbsdirtybitmap { get; set; }
    }

    public class Ballooninfo
    {
        public long actual { get; set; }
        public long total_mem { get; set; }
        public long mem_swapped_in { get; set; }
        public long free_mem { get; set; }
        public int major_page_faults { get; set; }
        public long max_mem { get; set; }
        public int last_update { get; set; }
        public long mem_swapped_out { get; set; }
    }

    public class NicInfo
    {
        public long netin { get; set; }
        public long netout { get; set; }
    }

    public class Blockstat
    {
        public Pflash0 pflash0 { get; set; }
        public Ide0 ide0 { get; set; }
        public Ide2 ide2 { get; set; }
        public Efidisk0 efidisk0 { get; set; }
    }

    public class Pflash0
    {
        public int failed_unmap_operations { get; set; }
        public int wr_merged { get; set; }
        public int unmap_bytes { get; set; }
        public int rd_operations { get; set; }
        public int flush_total_time_ns { get; set; }
        public int wr_bytes { get; set; }
        public int unmap_total_time_ns { get; set; }
        public int wr_highest_offset { get; set; }
        public int invalid_rd_operations { get; set; }
        public int wr_total_time_ns { get; set; }
        public int invalid_flush_operations { get; set; }
        public int rd_total_time_ns { get; set; }
        public int zone_append_operations { get; set; }
        public int zone_append_bytes { get; set; }
        public int flush_operations { get; set; }
        public int rd_bytes { get; set; }
        public bool account_failed { get; set; }
        public int zone_append_total_time_ns { get; set; }
        public object[] timed_stats { get; set; }
        public int invalid_zone_append_operations { get; set; }
        public int wr_operations { get; set; }
        public int zone_append_merged { get; set; }
        public int unmap_operations { get; set; }
        public bool account_invalid { get; set; }
        public int invalid_wr_operations { get; set; }
        public int unmap_merged { get; set; }
        public int rd_merged { get; set; }
        public int failed_rd_operations { get; set; }
        public int failed_wr_operations { get; set; }
        public int failed_flush_operations { get; set; }
        public int failed_zone_append_operations { get; set; }
        public int invalid_unmap_operations { get; set; }
    }

    public class Ide0
    {
        public object[] timed_stats { get; set; }
        public int flush_operations { get; set; }
        public long rd_bytes { get; set; }
        public int zone_append_total_time_ns { get; set; }
        public bool account_failed { get; set; }
        public int idle_time_ns { get; set; }
        public int zone_append_bytes { get; set; }
        public int zone_append_operations { get; set; }
        public long rd_total_time_ns { get; set; }
        public int failed_zone_append_operations { get; set; }
        public int failed_flush_operations { get; set; }
        public int failed_wr_operations { get; set; }
        public int failed_rd_operations { get; set; }
        public int invalid_unmap_operations { get; set; }
        public int rd_merged { get; set; }
        public int unmap_merged { get; set; }
        public int invalid_wr_operations { get; set; }
        public int zone_append_merged { get; set; }
        public int unmap_operations { get; set; }
        public int invalid_zone_append_operations { get; set; }
        public int wr_operations { get; set; }
        public bool account_invalid { get; set; }
        public int rd_operations { get; set; }
        public long flush_total_time_ns { get; set; }
        public long unmap_bytes { get; set; }
        public int wr_merged { get; set; }
        public int failed_unmap_operations { get; set; }
        public long wr_total_time_ns { get; set; }
        public int invalid_flush_operations { get; set; }
        public int invalid_rd_operations { get; set; }
        public long wr_highest_offset { get; set; }
        public long wr_bytes { get; set; }
        public int unmap_total_time_ns { get; set; }
    }

    public class Ide2
    {
        public int unmap_merged { get; set; }
        public int invalid_wr_operations { get; set; }
        public bool account_invalid { get; set; }
        public int invalid_zone_append_operations { get; set; }
        public int wr_operations { get; set; }
        public int unmap_operations { get; set; }
        public int zone_append_merged { get; set; }
        public int invalid_unmap_operations { get; set; }
        public int failed_wr_operations { get; set; }
        public int failed_rd_operations { get; set; }
        public int failed_flush_operations { get; set; }
        public int failed_zone_append_operations { get; set; }
        public int rd_merged { get; set; }
        public int zone_append_bytes { get; set; }
        public int zone_append_operations { get; set; }
        public int rd_total_time_ns { get; set; }
        public object[] timed_stats { get; set; }
        public bool account_failed { get; set; }
        public int zone_append_total_time_ns { get; set; }
        public int rd_bytes { get; set; }
        public int flush_operations { get; set; }
        public int wr_highest_offset { get; set; }
        public int invalid_rd_operations { get; set; }
        public int unmap_total_time_ns { get; set; }
        public int wr_bytes { get; set; }
        public int invalid_flush_operations { get; set; }
        public int wr_total_time_ns { get; set; }
        public int unmap_bytes { get; set; }
        public int failed_unmap_operations { get; set; }
        public int wr_merged { get; set; }
        public int flush_total_time_ns { get; set; }
        public int rd_operations { get; set; }
    }

    public class Efidisk0
    {
        public int wr_total_time_ns { get; set; }
        public int invalid_flush_operations { get; set; }
        public int wr_bytes { get; set; }
        public int unmap_total_time_ns { get; set; }
        public int invalid_rd_operations { get; set; }
        public int wr_highest_offset { get; set; }
        public int rd_operations { get; set; }
        public int flush_total_time_ns { get; set; }
        public int failed_unmap_operations { get; set; }
        public int wr_merged { get; set; }
        public int unmap_bytes { get; set; }
        public int rd_merged { get; set; }
        public int failed_wr_operations { get; set; }
        public int failed_rd_operations { get; set; }
        public int failed_flush_operations { get; set; }
        public int failed_zone_append_operations { get; set; }
        public int invalid_unmap_operations { get; set; }
        public int wr_operations { get; set; }
        public int invalid_zone_append_operations { get; set; }
        public int unmap_operations { get; set; }
        public int zone_append_merged { get; set; }
        public bool account_invalid { get; set; }
        public int unmap_merged { get; set; }
        public int invalid_wr_operations { get; set; }
        public int rd_bytes { get; set; }
        public int flush_operations { get; set; }
        public bool account_failed { get; set; }
        public int zone_append_total_time_ns { get; set; }
        public object[] timed_stats { get; set; }
        public int zone_append_operations { get; set; }
        public int rd_total_time_ns { get; set; }
        public int zone_append_bytes { get; set; }
    }
}