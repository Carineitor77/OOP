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
    document.getElementById('messages-content')
        .insertAdjacentHTML(
            "beforeend",
            `<div style="color:${color}"><p>Sender: ${sender}</p><p>Action: ${message}</p></div><br>`);
}

const conState = document.getElementById('conState');
const connectButton = document.getElementById('connectButton');
const select = document.getElementById('role');

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
            conState.textContent = 'Connected';
            conState.style.color = 'green';
            connectButton.textContent = 'Disconnect';
        }
    } else if (connection.state === 'Connected') {
        await connection.stop();

        conState.textContent = 'Disconnected';
        conState.style.color = 'red';
        connectButton.textContent = 'Connect';
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
    }
};

async function setMyName() {
    if (connection.state === 'Connected') {
        try {
            await connection.send('SetMyName', select.value);
        }
        catch (error) {
            console.log(error);
        }
    }
};