# Workshop.MemoryPressure
Workshop to understand how an Azure deployed website responds to a creeping memory load.

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

## Problem statment
I want to see what happens in the case of memory exhaustion in Azure as described [here][1].

## Features
1. I should be able to see the current memory set size.
1. I should be able to increase it in 13mb blocks.
1. I should see server restarts in some log.
1. I want the server to self heal as described [here][4].
1. I should be able to deploy automatically to Azure as described [here][2].
1. I should have 3 servers in round robin form as described [here][9].

## Observations
1. Site -> Tools -> Process Explorer best matches GC.GetTotalMemory. The "Memory Working set" and the "Memory Percentage" graphs seem to be one instance only. Same with Kudu.
1. Logs are found in Kudu -> LogFiles -> {ShortId}-{pid}-xxx
1. Recycle actualy kills and restarts. This means Global.Application_End is never called
1. "type": "sourcecontrols" is not part of ARM Templates as [described][5], but is actualy a part of [Slingshot][10].
1. There are a lot of [examples][7], but making the resources manually then using the [resources preview site][11] seems simpler.
1. [Deploy to Azure][2] does not work on subscriptions where your permission is "co-admin".

[//]: Refrences
[1]: http://stackoverflow.com/questions/35989437/azure-memory-resource-exhausted
[2]: https://azure.microsoft.com/en-us/blog/deploy-to-azure-button-for-azure-websites-2/
[3]: https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet
[4]: https://azure.microsoft.com/en-us/blog/auto-healing-windows-azure-web-sites/
[5]: https://channel9.msdn.com/Series/Windows-Azure-Web-Sites-Tutorials/Auto-Healing-an-Azure-App-Service
[6]: https://github.com/Azure/azure-quickstart-templates
[7]: https://github.com/davidebbo/AzureWebsitesSamples/tree/master/ARMTemplates
[8]: https://azure.microsoft.com/en-us/documentation/articles/resource-group-portal/#deploying-a-custom-template
[9]: http://microsoftazurewebsitescheatsheet.info/
[10]: https://github.com/projectkudu/slingshot
[11]: https://resources.azure.com/
