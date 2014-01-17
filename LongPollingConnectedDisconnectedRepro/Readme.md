## JS Client falls back from SSE to LongPolling on Exception in Hub's OnConnected and enters Connected state, followed quickly by Disconnected. ##

1. Client (Chrome 32) tries to connect using transport auto, uses SSE
1. OnConnected method in the hub class throws exception
1. Client initializes long polling connection with the server
1. "Longpolling connected."
1. "connecting => connected"
1. "EventSource timed out trying to connect"
1. "Polling xhr requests already exists, aborting"
1. "Stopping connection."
1. "SignalR: connected => disconnected"

Since I'm trying to recover from a Disconnect my client ends up in a loop, because I somehow do get into the "connected" state, but I'm never actually connected. Is this by design?

Client-Log:

- [11:17:46 GMT+0100] SignalR: disconnected => connecting
- [11:17:46 GMT+0100] SignalR: Client subscribed to hub 'testhub'. jquery.signalR-1.2.0.js:60
- [11:17:46 GMT+0100] SignalR: Negotiating with '/signalr/negotiate?lbid=1336696723056&connectionData=%5B%7B%22name%22%3A%22testhub%22%7D%5D'. jquery.signalR-1.2.0.js:60
- [11:17:46 GMT+0100] SignalR: Attempting to connect to SSE endpoint 'http://development/signalr/connect?transport=serverSentEvents&con…336696723056&connectionData=%5B%7B%22name%22%3A%22testhub%22%7D%5D&tid=3'. jquery.signalR-1.2.0.js:60
- [11:17:46 GMT+0100] SignalR: This browser supports SSE, skipping Forever Frame. jquery.signalR-1.2.0.js:60
- [11:17:46 GMT+0100] SignalR: Initializing long polling connection with server. jquery.signalR-1.2.0.js:60
- [11:17:46 GMT+0100] SignalR: Opening long polling request to 'http://development/signalr/connect?transport=longPolling&connecti…336696723056&connectionData=%5B%7B%22name%22%3A%22testhub%22%7D%5D&tid=3'. jquery.signalR-1.2.0.js:60
- [11:17:47 GMT+0100] SignalR: Longpolling connected. jquery.signalR-1.2.0.js:60
- [11:17:47 GMT+0100] SignalR: connecting => connected
- [11:17:49 GMT+0100] SignalR: EventSource timed out trying to connect. jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: EventSource readyState: 2. jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: EventSource calling close(). jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: This browser supports SSE, skipping Forever Frame. jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: Polling xhr requests already exists, aborting. jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: Stopping connection. jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: connected => disconnected
- [11:17:49 GMT+0100] SignalR: Fired ajax abort async = true. jquery.signalR-1.2.0.js:60
- [11:17:49 GMT+0100] SignalR: Aborted xhr requst. jquery.signalR-1.2.0.js:60 
