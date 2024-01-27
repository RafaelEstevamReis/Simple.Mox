﻿using Simple.Mox;

//Instance c = new Instance("https://proxmox.local:8006/", "PVEAPIToken=a@b!a=123");
Instance c = new Instance("https://proxmox.local:8006/", new AuthParams
{
    User = "username",
    Realm = "pam", // default
    TokenName = "monitoring",
    TokenSecret = "aaaaaaaaa-bbb-cccc-dddd-ef0123456789",
});

// Get Proxmox instance info
var info = await c.GetInfoAsync();
var firstNodeInfo = info.Nodes[0];
// get node by info, index or name
var node = await c.GetNodeAsync(firstNodeInfo); // await c.GetNodeAsync("pve");
// Node info
var nodeStatus = await node.GetStatusAsync();
var nodeReport = await node.GenerateReportAsync();
var nodeStatistcs = await node.GetStatisticsAsync(Simple.Mox.Models.NodeRRD.TimeFrame.day);
var pngBytes = await node.GetStatisticsImageAsync(Simple.Mox.Models.NodeRRD.TimeFrame.day, Simple.Mox.Models.NodeRRD.DataSet.loadavg);

// Get node LXC
var nodeAllLxcs = await node.GetLXCsAsync();
var lxc100 = await node.GetLXCAsync(100);
// Get node VMs
var nodeAllVMs = await node.GetVMsAsync();
var vm300 = await node.GetVMAsync(300);

// Enumerate all VMs e LXCs
var items = await c.GetItemsAsync();
// get VM 123
var vm123 = await items[123].AsVMAsync();
// get LXC 123
var ct321 = await items[321].AsVMAsync();

// Get VM information
var vm_status = await vm300.GetStatusAsync();
var vm_cfg = await vm300.GetConfigAsync();
var vm_stats = await vm300.GetStatisticsAsync(Simple.Mox.Models.NodeRRD.TimeFrame.day);
var vm_bytes = await vm300.GetStatisticsImageAsync(Simple.Mox.Models.NodeRRD.TimeFrame.day, Simple.Mox.Models.VMRRD.DataSet.cpu);
System.IO.File.WriteAllBytes("vm300.png", vm_bytes);

// Get LXC information
var lxc_status = await lxc100.GetStatusAsync();
var lxc_cfg = await lxc100.GetConfigAsync();
var lxc_stats = await lxc100.GetStatisticsAsync(Simple.Mox.Models.NodeRRD.TimeFrame.day);
var lxc_bytes = await lxc100.GetStatisticsImageAsync(Simple.Mox.Models.NodeRRD.TimeFrame.day, Simple.Mox.Models.LXCRRD.DataSet.cpu);
System.IO.File.WriteAllBytes("lxc100.png", lxc_bytes);

