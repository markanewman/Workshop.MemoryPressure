# Workshop.MemoryPressure
Workshop to understand how an Azure deployed website responds to a creeping memory load.

## Problem statment
I want to see what happens in the case of memory exaustion in azure as described [here][1].

## Features
1. I should be able to see the current memory set size.
1. I should be able to increse it in 50mb blocks.
1. I should see server restarts in some log.
1. I want the server to self heal as described [here][4].
1. I should be able to deploy automaticaly to Azure as described [here][2].
1. I should have 2 servers in round robin form.

[//]: Refrences
[1]: http://stackoverflow.com/questions/35989437/azure-memory-resource-exhausted
[2]: https://azure.microsoft.com/en-us/blog/deploy-to-azure-button-for-azure-websites-2/
[3]: https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet
[4]: https://azure.microsoft.com/en-us/blog/auto-healing-windows-azure-web-sites/