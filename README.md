# Real-Time Data Updates and ICMP Check Web Application

This web application is a personal project that demonstrates the implementation of SignalR with ASP.NET and Angular. It allows clients to establish a real-time connection with the server, enabling live data updates every second. Additionally, the application provides ICMP checks on specified domains, reporting the success of the ping.

## Features

### Real-Time Data Updates

- **SignalR Implementation**: The application utilizes SignalR, a real-time web communication library, to establish a bidirectional connection between the client and the server. This enables the server to push live data updates to connected clients in real-time.

- **Live Data Updates**: Once the connection is established, the server will continuously send date updates to all connected clients every second. This serves as an example to demonstrate real-time data streaming and rendering on the client-side.

- **Angular Pipes for Rendering**: The received date updates from the server are rendered on the client-side using Angular pipes to format and display the data efficiently.

### ICMP Check on Domains

- **ICMP Check Functionality**: The web application allows users to perform ICMP (Internet Control Message Protocol) checks on some domains.

- **Ping Success and Delay**: Upon performing the ICMP check, the application reports back whether the ping to a domain was successful or not. Additionally, it displays the corresponding time delay in milliseconds when a successful ping response is received.

## License

This project is licensed under the [MIT License](LICENSE).
