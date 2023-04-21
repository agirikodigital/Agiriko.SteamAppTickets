# Agiriko.SteamAppTickets

A simple C# wrapper for talking with the Steamworks Encrypted App Ticket API.

## Requirements

- You need to get the steamworks encrypted app ticket library binaries yourself, from the **steamworks_sdk.zip** bundle.
- An encrypted app ticket decryption key, obtainable from the Steamworks partner page.

## Usage

Firstly, create an encrypted app ticket factory:

```cs
var factory = new EncryptedAppTicketFactory("[your api key goes here]");
```

Then, when you receive an app ticket from a client, decode it using:

```cs
var ticket = factory.Decrypt(/* ticket byte array */);
```
