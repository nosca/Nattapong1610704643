var websocket = require('ws');

var callbackInitServer = () =>{
    console.log("Jack Server is running.");
}

var wss = new websocket.Server({port : 5500}, callbackInitServer);

var wsList = [];

wss.on("connection", (ws)=>{

    console.log("client connected");
    wsList.push(ws);

    ws.on("message" , (data)=>{
        console.log("send from client :"+ data);
        Boardcast(data);

    });
    
    ws.on("close" , ()=>{
        console.log("cilient disconnected")
        wsList = ArrayRemove(wsList , ws);
    })
})

function ArrayRemove(arr , value)
{
    return arr.filter((elememt)=>{
        return elememt != value;

    });
}

function Boardcast(data)
{
    for(var i =0;i< wsList.length ; i++)
    {
        wsList[i].send(data);
    }
}