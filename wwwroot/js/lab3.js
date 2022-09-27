const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/messages", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();

connection.on('Send', (message) => {
    appendMessage(message.sender, message.text, 'black');
});

connection.onclose(error => {
    console.log('Connection closed. ', error)
});

connection.onreconnecting(error => {
    console.log('Connection reconnecting. ', error);
});

connection.onreconnected(connectionId => {
    console.log('Connectin reconnected with id: ', connectionId);
});

function appendMessage(sender, message, color) {
    document.querySelector('#messages-content').insertAdjacentHTML("beforeend", `<div style="color:${color}"><p>Sender: ${sender}</p><p>Action: ${message}</p></div><br>`);
}

async function connect() {
    if (connection.state === 'Disconnected') {
        try {
            await connection.start();
            setMyName();
        }
        catch (error) {
            console.log(error);
        }
        if (connection.state === 'Connected') {
            document.querySelector('#conState').textContent = 'Connected';
            document.querySelector('#conState').style.color = 'green';
            document.querySelector('#connectButton').textContent = 'Disconnect';
        }
    } else if (connection.state === 'Connected') {
        await connection.stop();
        document.querySelector('#conState').textContent = 'Disconnected';
        document.querySelector('#conState').style.color = 'red';
        document.querySelector('#connectButton').textContent = 'Connect';
    }
};

async function sendMessage(toDo) {
    if (connection.state === 'Connected') {
        const message = { text: toDo };
        try {
            await connection.send('SendToOthers', message);
            appendMessage('Me', message.text, 'green');
        }
        catch (error) {
            console.log(error);
        }
        document.querySelector('#message').value = '';
    }
};

async function setMyName() {
    if (connection.state === 'Connected') {
        try {
            const select = document.getElementById('role');
            await connection.send('SetMyName', select.value);
        }
        catch (error) {
            console.log(error);
        }
    }
};